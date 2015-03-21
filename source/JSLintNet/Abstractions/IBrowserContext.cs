namespace JSLintNet.Abstractions
{
    using System;

    internal interface IBrowserContext : IDisposable
    {
        void InjectScript(string source);

        object InvokeFunction(string function, params object[] args);

        void SetExternal(object external);
    }
}
