using UnityEngine;

namespace CharacterSelector
{
    [DisallowMultipleComponent]
    public sealed class SceneAndUIMediator : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private CharacterSelectorUI _ui = null;
        [SerializeField] private Transform _spawnPoint = null; 
        #endregion

        #region Fields  
        private GameObject _character;
        #endregion

        private void OnEnable()
        {
            _ui.OnSpawn += OnSpawn;
        }

        private void OnDisable()
        {
            _ui.OnSpawn -= OnSpawn;
        }

        private void OnSpawn(GameObject character)
        {
            if(_character != null)
            {
                Destroy(_character);

                _character = null;
            }

            _character = Instantiate(character, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint);
        }
    }
}