﻿namespace JSLintNet.QualityTools.Fakes
{
    using System.Collections.Generic;
    using JSLintNet.Models;

    public class JSLintDataFake : IJSLintData
    {
        public JSLintDataFake()
        {
        }

        public JSLintDataFake(string fileName, int errorCount)
        {
            this.FileName = fileName;
            this.SetErrors(errorCount);
        }

        public string FileName { get; set; }

        public IList<IJSLintError> Errors { get; set; }

        public IList<IJSLintFunction> Functions { get; set; }

        public IList<string> Global { get; set; }

        public bool Json { get; set; }

        public string ErrorReport { get; set; }

        public bool HasStoppingError { get; set; }

        public void SetErrors(int errorCount)
        {
            var errors = new IJSLintError[errorCount];

            for (int i = 0; i < errorCount; i++)
            {
                var number = i + 1;
                errors[i] = new JSLintErrorFake(this.FileName, number);
            }

            this.Errors = errors;
        }
    }
}
