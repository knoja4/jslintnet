﻿namespace JSLintNet.VisualStudio.UI.ViewModels
{
    using System.CodeDom.Compiler;

    [GeneratedCode("TextTemplatingFileGenerator", "")]
    internal partial class SettingsViewModel : ViewModelBase
    {
        public virtual bool? TolerateAssignmentExpressions
        {
            get
            {
                return this.Model.Options.TolerateAssignmentExpressions;
            }

            set
            {
                this.Model.Options.TolerateAssignmentExpressions = value;

                this.RaisePropertyChanged("TolerateAssignmentExpressions");
            }
        }

        public virtual bool? TolerateBitwiseOperators
        {
            get
            {
                return this.Model.Options.TolerateBitwiseOperators;
            }

            set
            {
                this.Model.Options.TolerateBitwiseOperators = value;

                this.RaisePropertyChanged("TolerateBitwiseOperators");
            }
        }

        public virtual bool? AssumeBrowser
        {
            get
            {
                return this.Model.Options.AssumeBrowser;
            }

            set
            {
                this.Model.Options.AssumeBrowser = value;

                this.RaisePropertyChanged("AssumeBrowser");
            }
        }

        public virtual bool? TolerateGoogleClosure
        {
            get
            {
                return this.Model.Options.TolerateGoogleClosure;
            }

            set
            {
                this.Model.Options.TolerateGoogleClosure = value;

                this.RaisePropertyChanged("TolerateGoogleClosure");
            }
        }

        public virtual bool? TolerateContinue
        {
            get
            {
                return this.Model.Options.TolerateContinue;
            }

            set
            {
                this.Model.Options.TolerateContinue = value;

                this.RaisePropertyChanged("TolerateContinue");
            }
        }

        public virtual bool? AssumeCouchDB
        {
            get
            {
                return this.Model.Options.AssumeCouchDB;
            }

            set
            {
                this.Model.Options.AssumeCouchDB = value;

                this.RaisePropertyChanged("AssumeCouchDB");
            }
        }

        public virtual bool? TolerateDebuggerStatements
        {
            get
            {
                return this.Model.Options.TolerateDebuggerStatements;
            }

            set
            {
                this.Model.Options.TolerateDebuggerStatements = value;

                this.RaisePropertyChanged("TolerateDebuggerStatements");
            }
        }

        public virtual bool? AssumeConsole
        {
            get
            {
                return this.Model.Options.AssumeConsole;
            }

            set
            {
                this.Model.Options.AssumeConsole = value;

                this.RaisePropertyChanged("AssumeConsole");
            }
        }

        public virtual bool? TolerateDoubleEquals
        {
            get
            {
                return this.Model.Options.TolerateDoubleEquals;
            }

            set
            {
                this.Model.Options.TolerateDoubleEquals = value;

                this.RaisePropertyChanged("TolerateDoubleEquals");
            }
        }

        public virtual bool? TolerateEval
        {
            get
            {
                return this.Model.Options.TolerateEval;
            }

            set
            {
                this.Model.Options.TolerateEval = value;

                this.RaisePropertyChanged("TolerateEval");
            }
        }

        public virtual bool? TolerateUnfilteredForIn
        {
            get
            {
                return this.Model.Options.TolerateUnfilteredForIn;
            }

            set
            {
                this.Model.Options.TolerateUnfilteredForIn = value;

                this.RaisePropertyChanged("TolerateUnfilteredForIn");
            }
        }

        public virtual string IndentationFactor
        {
            get
            {
                var nullable = this.Model.Options.IndentationFactor;

                return nullable.HasValue ? nullable.ToString() : null;
            }

            set
            {
                this.Model.Options.IndentationFactor = ParseIntFromString(value);

                this.RaisePropertyChanged("IndentationFactor");
            }
        }

        public virtual string MaximumErrors
        {
            get
            {
                var nullable = this.Model.Options.MaximumErrors;

                return nullable.HasValue ? nullable.ToString() : null;
            }

            set
            {
                this.Model.Options.MaximumErrors = ParseIntFromString(value);

                this.RaisePropertyChanged("MaximumErrors");
            }
        }

        public virtual string MaximumLineLength
        {
            get
            {
                var nullable = this.Model.Options.MaximumLineLength;

                return nullable.HasValue ? nullable.ToString() : null;
            }

            set
            {
                this.Model.Options.MaximumLineLength = ParseIntFromString(value);

                this.RaisePropertyChanged("MaximumLineLength");
            }
        }

        public virtual bool? TolerateUncapitalizedConstructors
        {
            get
            {
                return this.Model.Options.TolerateUncapitalizedConstructors;
            }

            set
            {
                this.Model.Options.TolerateUncapitalizedConstructors = value;

                this.RaisePropertyChanged("TolerateUncapitalizedConstructors");
            }
        }

        public virtual bool? AssumeNode
        {
            get
            {
                return this.Model.Options.AssumeNode;
            }

            set
            {
                this.Model.Options.AssumeNode = value;

                this.RaisePropertyChanged("AssumeNode");
            }
        }

        public virtual bool? TolerateDanglingUnderscores
        {
            get
            {
                return this.Model.Options.TolerateDanglingUnderscores;
            }

            set
            {
                this.Model.Options.TolerateDanglingUnderscores = value;

                this.RaisePropertyChanged("TolerateDanglingUnderscores");
            }
        }

        public virtual bool? StopOnFirstError
        {
            get
            {
                return this.Model.Options.StopOnFirstError;
            }

            set
            {
                this.Model.Options.StopOnFirstError = value;

                this.RaisePropertyChanged("StopOnFirstError");
            }
        }

        public virtual bool? TolerateIncrementDecrement
        {
            get
            {
                return this.Model.Options.TolerateIncrementDecrement;
            }

            set
            {
                this.Model.Options.TolerateIncrementDecrement = value;

                this.RaisePropertyChanged("TolerateIncrementDecrement");
            }
        }

        public virtual bool? PropertiesDeclared
        {
            get
            {
                return this.Model.Options.PropertiesDeclared;
            }

            set
            {
                this.Model.Options.PropertiesDeclared = value;

                this.RaisePropertyChanged("PropertiesDeclared");
            }
        }

        public virtual bool? TolerateInsecureRegExp
        {
            get
            {
                return this.Model.Options.TolerateInsecureRegExp;
            }

            set
            {
                this.Model.Options.TolerateInsecureRegExp = value;

                this.RaisePropertyChanged("TolerateInsecureRegExp");
            }
        }

        public virtual bool? AssumeRhino
        {
            get
            {
                return this.Model.Options.AssumeRhino;
            }

            set
            {
                this.Model.Options.AssumeRhino = value;

                this.RaisePropertyChanged("AssumeRhino");
            }
        }

        public virtual bool? TolerateUnusedParameters
        {
            get
            {
                return this.Model.Options.TolerateUnusedParameters;
            }

            set
            {
                this.Model.Options.TolerateUnusedParameters = value;

                this.RaisePropertyChanged("TolerateUnusedParameters");
            }
        }

        public virtual bool? TolerateMissingUseStrict
        {
            get
            {
                return this.Model.Options.TolerateMissingUseStrict;
            }

            set
            {
                this.Model.Options.TolerateMissingUseStrict = value;

                this.RaisePropertyChanged("TolerateMissingUseStrict");
            }
        }

        public virtual bool? TolerateStupidPractices
        {
            get
            {
                return this.Model.Options.TolerateStupidPractices;
            }

            set
            {
                this.Model.Options.TolerateStupidPractices = value;

                this.RaisePropertyChanged("TolerateStupidPractices");
            }
        }

        public virtual bool? TolerateInefficientSubscripting
        {
            get
            {
                return this.Model.Options.TolerateInefficientSubscripting;
            }

            set
            {
                this.Model.Options.TolerateInefficientSubscripting = value;

                this.RaisePropertyChanged("TolerateInefficientSubscripting");
            }
        }

        public virtual bool? TolerateToDoComments
        {
            get
            {
                return this.Model.Options.TolerateToDoComments;
            }

            set
            {
                this.Model.Options.TolerateToDoComments = value;

                this.RaisePropertyChanged("TolerateToDoComments");
            }
        }

        public virtual bool? TolerateManyVarStatements
        {
            get
            {
                return this.Model.Options.TolerateManyVarStatements;
            }

            set
            {
                this.Model.Options.TolerateManyVarStatements = value;

                this.RaisePropertyChanged("TolerateManyVarStatements");
            }
        }

        public virtual bool? TolerateMessyWhitespace
        {
            get
            {
                return this.Model.Options.TolerateMessyWhitespace;
            }

            set
            {
                this.Model.Options.TolerateMessyWhitespace = value;

                this.RaisePropertyChanged("TolerateMessyWhitespace");
            }
        }
    }
}
