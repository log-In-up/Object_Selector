using UnityEngine;

namespace Data
{
    public class Container<T> where T : Object
    {
        #region Fields
        private T _object = null;
        #endregion

        #region Methods
        internal T GetObject() => _object;

        internal void SetObject(T t) => _object = t;
        #endregion
    }
}