using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameInput
{
    [DisallowMultipleComponent]
    public sealed class InputManager : MonoBehaviour
    {
        #region Fields
        private const string HORIZONTAL = "Horizontal";
        #endregion

        #region Events
        public delegate void InputHandler();
        public event InputHandler Left, Right;
        #endregion

        #region MonoBehaviour API
        private void Update()
        {
            if (!Input.anyKeyDown) return;

            float horizontal = Input.GetAxis(HORIZONTAL);

            if (horizontal != 0.0f)
            {
                if (horizontal > 0.0f)
                {
                    Right?.Invoke();
                }
                else
                {
                    Left?.Invoke();
                }
            }
        }
        #endregion
    }
}
