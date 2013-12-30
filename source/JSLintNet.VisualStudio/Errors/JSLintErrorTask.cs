﻿namespace JSLintNet.VisualStudio.Errors
{
    using JSLintNet.Models;
    using JSLintNet.Properties;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <summary>
    /// A task that handles JSLint errors.
    /// </summary>
    internal class JSLintErrorTask : ErrorTask
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JSLintErrorTask" /> class.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="jsLintError">The JSLint error.</param>
        /// <param name="category">The category.</param>
        /// <param name="hierarchy">The hierarchy.</param>
        public JSLintErrorTask(string document, IJSLintError jsLintError, TaskErrorCategory category, IVsHierarchy hierarchy)
        {
            this.Document = document;
            this.Category = TaskCategory.BuildCompile;
            this.ErrorCategory = category;
            this.Line = jsLintError.Line - 1;
            this.Column = jsLintError.Character - 1;
            this.Text = GetText(jsLintError);
            this.HierarchyItem = hierarchy;
        }

        /// <summary>
        /// Gets a text representation of the specified error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <returns>
        /// A text representation of the error.
        /// </returns>
        private static string GetText(IJSLintError error)
        {
            return string.Concat(Resources.ErrorTextPrefix, error.Reason);
        }
    }
}
