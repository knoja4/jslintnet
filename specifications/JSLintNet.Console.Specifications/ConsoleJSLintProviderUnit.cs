﻿namespace JSLintNet.Console.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using JSLintNet.Abstractions;
    using JSLintNet.QualityTools;
    using JSLintNet.QualityTools.Fakes;
    using JSLintNet.Settings;
    using JSLintNet.UI.ViewModels;
    using JSLintNet.UI.Views;
    using Moq;
    using Xunit;
    using CoreResources = JSLintNet.Properties.Resources;

    public class ConsoleJSLintProviderUnit
    {
        public class Lint : UnitBase
        {
            [Fact(DisplayName = "Should stop processing when error limit reached")]
            public void Spec01()
            {
                using (var testable = new LintTestable())
                {
                    testable.SetupFile("some1.js", 2);
                    testable.SetupFile("some2.js", 2);

                    testable.Settings.ErrorLimit = 10;
                    testable.ErrorCount = 11;

                    testable.Instance.Lint(testable.Options);

                    testable.ConsoleWriterMock.Verify(x => x.WriteErrorLine(CoreResources.ErrorLimitReachedFormat, 11));
                    testable.Verify<IFileSystemWrapper>(x => x.ReadAllText(testable.Options.SourceFiles[0], Encoding.UTF8));
                    testable.Verify<IFileSystemWrapper>(x => x.ReadAllText(testable.Options.SourceFiles[1], Encoding.UTF8), Times.Never());
                }
            }

            [Fact(DisplayName = "Should stop processing when file limit reached")]
            public void Spec02()
            {
                using (var testable = new LintTestable())
                {
                    testable.SetupFile("some1.js", 2);
                    testable.SetupFile("some2.js", 2);

                    testable.Settings.FileLimit = 10;
                    testable.ProcessedFileCount = 11;

                    testable.Instance.Lint(testable.Options);

                    testable.ConsoleWriterMock.Verify(x => x.WriteErrorLine(CoreResources.FileLimitReachedFormat, 11));
                    testable.Verify<IFileSystemWrapper>(x => x.ReadAllText(testable.Options.SourceFiles[0], Encoding.UTF8));
                    testable.Verify<IFileSystemWrapper>(x => x.ReadAllText(testable.Options.SourceFiles[1], Encoding.UTF8), Times.Never());
                }
            }

            [Fact(DisplayName = "Should stop processing when exception limit reached")]
            public void Spec03()
            {
                using (var testable = new LintTestable())
                {
                    for (int i = 0; i <= JSLintNetSettings.ExceptionLimit; i++)
                    {
                        var filePath = Path.Combine(testable.Options.SourceDirectory, "file" + i + ".js");
                        testable.Options.SourceFiles.Add(filePath);
                    }

                    testable.JSLintContextMock
                        .Setup(x => x.Lint(It.IsAny<string>(), It.IsAny<JSLintOptions>()))
                        .Throws<Exception>();

                    testable.Instance.Lint(testable.Options);

                    testable.ConsoleWriterMock.Verify(x => x.WriteErrorLine(CoreResources.ExceptionLimitReachedFormat, JSLintNetSettings.ExceptionLimit));
                    testable.Verify<IFileSystemWrapper>(x => x.ReadAllText(testable.Options.SourceFiles[49], Encoding.UTF8));
                    testable.Verify<IFileSystemWrapper>(x => x.ReadAllText(testable.Options.SourceFiles[50], Encoding.UTF8), Times.Never());
                }
            }

            private class LintTestable : ConsoleJSLintProviderTestableBase
            {
                public LintTestable()
                {
                    this.JSLintContextMock = new Mock<IJSLintContext>();
                    this.JSLintReportBuilderMock = new Mock<IJSLintReportBuilder>();

                    this.BeforeInit += this.OnBeforeInit;
                }

                public Mock<IJSLintContext> JSLintContextMock { get; set; }

                public Mock<IJSLintReportBuilder> JSLintReportBuilderMock { get; set; }

                public int ErrorCount { get; set; }

                public int ProcessedFileCount { get; set; }

                public JSLintDataFake SetupFile(string fileName, int errorCount)
                {
                    var filePath = Path.Combine(this.Options.SourceDirectory, fileName);
                    var fake = new JSLintDataFake(fileName, errorCount);
                    var source = fileName + " contents";

                    this.GetMock<IFileSystemWrapper>()
                        .Setup(x => x.ReadAllText(filePath, Encoding.UTF8))
                        .Returns(source);

                    this.JSLintContextMock
                        .Setup(x => x.Lint(source, null))
                        .Returns(fake);

                    this.Options.SourceFiles.Add(filePath);

                    return fake;
                }

                private void OnBeforeInit(object sender, EventArgs e)
                {
                    this.GetMock<IJSLintFactory>()
                        .Setup(x => x.CreateContext())
                        .Returns(this.JSLintContextMock.Object);

                    this.GetMock<IJSLintFactory>()
                        .Setup(x => x.CreateReportBuilder())
                        .Returns(this.JSLintReportBuilderMock.Object);

                    this.JSLintReportBuilderMock
                        .SetupGet(x => x.ErrorCount)
                        .Returns(() => this.ErrorCount);

                    this.JSLintReportBuilderMock
                        .SetupGet(x => x.ProcessedFileCount)
                        .Returns(() => this.ProcessedFileCount);

                    this.JSLintReportBuilderMock
                        .SetupGet(x => x.SettingsFiles)
                        .Returns(new List<string>());
                }
            }
        }

        public class EditSettings : UnitBase
        {
            [Fact(DisplayName = "Should always show editor window")]
            public void Spec01()
            {
                using (var testable = new EditSettingsTestable())
                {
                    testable.Instance.EditSettings(testable.Options);

                    testable.ViewMock.Verify(x => x.ShowDialog());
                }
            }

            [Fact(DisplayName = "Should save results when dialog is OK")]
            public void Spec02()
            {
                using (var testable = new EditSettingsTestable())
                {
                    testable.ViewMock
                        .Setup(x => x.ShowDialog())
                        .Returns(true);

                    testable.Instance.EditSettings(testable.Options);

                    testable.Verify<ISettingsRepository>(x => x.Save(testable.Settings, testable.Options.SettingsFile));
                }
            }

            [Fact(DisplayName = "Should not save results when dialog is canceled")]
            public void Spec03()
            {
                using (var testable = new EditSettingsTestable())
                {
                    testable.ViewMock
                        .Setup(x => x.ShowDialog())
                        .Returns(false);

                    testable.Instance.EditSettings(testable.Options);

                    testable.Verify<IFileSystemWrapper>(x => x.WriteAllText(testable.Options.SettingsFile, It.IsAny<string>(), It.IsAny<Encoding>()), Times.Never());
                }
            }

            private class EditSettingsTestable : ConsoleJSLintProviderTestableBase
            {
                public EditSettingsTestable()
                {
                    this.ViewMock = new Mock<IView>();

                    this.BeforeInit += this.OnBeforeInit;
                }

                public Mock<IView> ViewMock { get; set; }

                private void OnBeforeInit(object sender, EventArgs e)
                {
                    this.GetMock<IViewFactory>()
                        .Setup(x => x.CreateSettings(It.IsAny<SettingsViewModel>()))
                        .Returns(this.ViewMock.Object);
                }
            }
        }

        private abstract class ConsoleJSLintProviderTestableBase : TestableBase<ConsoleJSLintProvider>
        {
            public ConsoleJSLintProviderTestableBase()
            {
                this.ConsoleWriterMock = this.GetMock<IConsoleWriter>();

                this.Options = new ConsoleOptions()
                {
                    SettingsEditor = true,
                    SettingsFile = @"D:\path\to\file.json",
                    SourceDirectory = @"D:\path\to",
                    SourceFiles = new List<string>()
                };

                this.Settings = new JSLintNetSettings();

                this.BeforeInit += this.OnBeforeInit;
            }

            public Mock<IConsoleWriter> ConsoleWriterMock { get; set; }

            public ConsoleOptions Options { get; set; }

            public JSLintNetSettings Settings { get; set; }

            private void OnBeforeInit(object sender, EventArgs e)
            {
                this.ConsoleWriterMock
                    .Setup(x => x.WriteLine())
                    .Returns(this.ConsoleWriterMock.Object);

                this.ConsoleWriterMock
                    .Setup(x => x.WriteLine(It.IsAny<string>(), It.IsAny<object[]>()))
                    .Returns(this.ConsoleWriterMock.Object);

                this.ConsoleWriterMock
                    .Setup(x => x.WriteErrorLine())
                    .Returns(this.ConsoleWriterMock.Object);

                this.ConsoleWriterMock
                    .Setup(x => x.WriteErrorLine(It.IsAny<string>(), It.IsAny<object[]>()))
                    .Returns(this.ConsoleWriterMock.Object);

                this.GetMock<ISettingsRepository>()
                    .Setup(x => x.Load(this.Options.SettingsFile))
                    .Returns(this.Settings);
            }
        }
    }
}
