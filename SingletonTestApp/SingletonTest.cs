using System;

namespace SingletonTestApp
{
    public sealed class SingletonTest : IDisposable
    {
        private bool _disposed;
        private static volatile SingletonTest _instance;
        private static readonly object _instanceLock = new object();
       

        private SingletonTest() {

        }

        public static SingletonTest GetInstance
        {
            get 
            {               

                if (_instance != null) return _instance;

                //Check for multi thread..create instance only one time..
                lock (_instanceLock)
                {
                    if (_instance == null) {
                        _instance = new SingletonTest();
                    }
                        
                }

                return _instance;
            }
        }

        public int Number { get; set; }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _instance = null;
            }

            _disposed = true;

        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }








    }
}
