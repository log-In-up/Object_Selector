using Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UserInterface
{
    [DisallowMultipleComponent]
    public sealed class Menu : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private Button _characterSelector = null;
        [SerializeField] private Button _potionSelector = null;
        #endregion

        #region MonoBehaviour API
        private void OnEnable()
        {
            _characterSelector.onClick.AddListener(OnClickCharacterSelector);
            _potionSelector.onClick.AddListener(OnClickPotionSelector);
        }

        private void OnDisable()
        {
            _characterSelector.onClick.RemoveListener(OnClickCharacterSelector);
            _potionSelector.onClick.RemoveListener(OnClickPotionSelector);
        }
        #endregion

        #region Event Handlers
        private void OnClickCharacterSelector()
        {
            DeactivateButtons();

            SceneManager.LoadScene((int)GameScenes.CharacterSelector);
        }

        private void OnClickPotionSelector()
        {
            DeactivateButtons();

            SceneManager.LoadScene((int)GameScenes.PotionSelector);
        }
        #endregion

        #region Methods
        private void DeactivateButtons()
        {
            _characterSelector.interactable = false;
            _potionSelector.interactable = false;
        }
        #endregion
    }
}
