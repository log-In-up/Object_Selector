using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class Loader<T> where T : Object
    {
        #region Fields
        private readonly int _totalObjectsCount;
        private readonly string _folderPath;
        private readonly List<string> _objectsName;

        private int _loadingIndex;
        private T _loadedAsset;
        #endregion

        public Loader(string folderPath)
        {
            _folderPath = folderPath;
            _loadingIndex = 0;
            _loadedAsset = null;

            T[] objects = Resources.LoadAll<T>(folderPath);
            _totalObjectsCount = objects.Length - 1;

            _objectsName = new List<string>();

            foreach (T item in objects)
            {
                _objectsName.Add(item.name);
            }

            Resources.UnloadUnusedAssets();
        }

        #region Public API
        public bool CanLoadNext() => _loadingIndex < _totalObjectsCount;

        public bool CanLoadPrevious() => _loadingIndex > 0;

        public T Load() => GetAsset(_objectsName[_loadingIndex]);

        public T LoadNext()
        {
            Resources.UnloadAsset(_loadedAsset);

            return GetAsset(_objectsName[++_loadingIndex]);
        }

        public T LoadPrevious()
        {
            Resources.UnloadAsset(_loadedAsset);

            return GetAsset(_objectsName[--_loadingIndex]);
        }
        #endregion

        #region Methods
        private T GetAsset(string nameOfObject)
        {
            string path = $"{_folderPath}/{nameOfObject}";
            _loadedAsset = Resources.Load<T>(path);

            return _loadedAsset;
        }
        #endregion
    }
}