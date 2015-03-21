namespace JSLintNet.Abstractions
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using JSLintNet.Properties;

    internal class BrowserContext : IBrowserContext
    {
        private WebBrowser browser;

        private Thread thread;

        private bool initialized;

        public BrowserContext()
        {
            if (!this.Initialize())
            {
                throw new Exception(Resources.BrowserContextFailedError);
            }
        }

        public object InvokeFunction(string function, params object[] args)
        {
            return this.browser.Invoke(new Func<object>(() =>
            {
                var document = this.browser.Document;

                return document.InvokeScript(function, args);
            }));
        }

        public void SetExternal(object external)
        {
            this.browser.Invoke(new Action(() =>
            {
                this.browser.ObjectForScripting = external;
            }));
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool managed)
        {
            if (managed)
            {
                if (this.browser != null && !this.browser.IsDisposed)
                {
                    this.browser.Invoke(new Action(() =>
                    {
                        this.browser.Dispose();

                        if (this.thread != null)
                        {
                            // Exit the message loop
                            Application.ExitThread();
                        }
                    }));

                    this.browser = null;
                }

                if (this.thread != null)
                {
                    this.thread.Join(1000);
                    this.thread = null;
                }
            }
        }

        private bool Initialize()
        {
            var reset = new AutoResetEvent(false);

            WebBrowserDocumentCompletedEventHandler handler = (object sender, WebBrowserDocumentCompletedEventArgs e) =>
            {
                reset.Set();
            };

            this.thread = new Thread(() =>
            {
                this.browser = new WebBrowser()
                {
                    ScriptErrorsSuppressed = true,
                    DocumentText = Resources.BrowserContext
                };

                this.browser.DocumentCompleted += handler;

                // Start the message loop on this thread
                Application.Run();
            });

            this.thread.IsBackground = true;
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start();

            var completed = reset.WaitOne(TimeSpan.FromSeconds(1));

            this.browser.DocumentCompleted -= handler;

            return completed;
        }
    }
}
