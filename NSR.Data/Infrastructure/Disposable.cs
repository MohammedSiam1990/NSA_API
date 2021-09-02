using System;

namespace NSR.Data.Infrastructure
{
    /// <summary>
    /// <history>
    /// [Created] :  by AhmedMustafa: For Disposing the objects
    /// </history>
    /// Class Disposable
    /// </summary>
    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <history>
        /// [Created] :  by AhmedMustafa: For dispose the unused variables and objects
        /// </history>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Disposable"/> class.
        /// </summary>
        /// <history>
        /// [Created] :  by AhmedMustafa: Destructor of class
        /// </history>
        ~Disposable()
        {
            Dispose(false);
        }

        /// <summary>
        /// Disposes the core.
        /// </summary>
        /// <history>
        /// [Created] :  by AhmedMustafa: Implementation in derive class
        /// </history>
        protected virtual void DisposeCore()
        {

        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        /// <history>
        /// [Created] :  by AhmedMustafa: For dispose the unused variables and objects
        /// </history>
        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }

            _isDisposed = true;
        }
    }
}
