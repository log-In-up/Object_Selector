using UnityEngine;

namespace Data
{
    public class Sender<T> where T : Object
    {
        #region Fields
        private readonly Container<T> _container = null;
        private readonly Loader<T> _loader = null;
        #endregion

        #region Properties
        public bool CanLoadNext => _loader.CanLoadNext();
        public bool CanLoadPrevious => _loader.CanLoadPrevious();
        #endregion

        public Sender(string folderPath)
        {
            _loader = new Loader<T>(folderPath);
            _container = new Container<T>();

            _container.SetObject(_loader.Load());
        }

        #region Public API
        public void LoadNext() => _container.SetObject(_loader.LoadNext());

        public void LoadPrevious() => _container.SetObject(_loader.LoadPrevious());

        public T GetObject() => _container.GetObject();
        #endregion
    }
}