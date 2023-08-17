using Data;
using GameData;
using GameInput;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterSelector
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(InputManager))]
    public sealed class CharacterSelectorUI : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private Button _next, _previous;
        [SerializeField] private TextMeshProUGUI _description;
        #endregion

        #region Fields
        private InputManager _inputManager = null;
        private Sender<CharactersData> _charactersSender = null;
        #endregion

        #region Events
        public delegate void SpawnHandler(GameObject character);
        public event SpawnHandler OnSpawn;
        #endregion

        #region MonoBehaviour API
        private void Awake()
        {
            _inputManager = GetComponent<InputManager>();
            _charactersSender = new Sender<CharactersData>(ConstAppData.CHARACTERS);
        }

        private void OnEnable()
        {
            _next.onClick.AddListener(OnClickNext);
            _previous.onClick.AddListener(OnClickPrevious);
            _inputManager.Right += OnKeyRight;
            _inputManager.Left += OnKeyLeft;
        }        

        private void Start()
        {
            GetNewData();
            CheckInteractability();
        }

        private void OnDisable()
        {
            _next.onClick.RemoveListener(OnClickNext);
            _previous.onClick.RemoveListener(OnClickPrevious);
            _inputManager.Right += OnKeyRight;
            _inputManager.Left += OnKeyLeft;
        }
        #endregion

        #region Methods
        private void CheckInteractability()
        {
            _next.interactable = _charactersSender.CanLoadNext;
            _previous.interactable = _charactersSender.CanLoadPrevious;
        }

        private void GetNewData()
        {
            CharactersData data = _charactersSender.GetObject();
            _description.text = data.Description;
            OnSpawn?.Invoke(data.Object);
        }
        #endregion

        #region Event Handlers
        private void OnClickNext()
        {
            _charactersSender.LoadNext();

            GetNewData();
            CheckInteractability();
        }

        private void OnClickPrevious()
        {
            _charactersSender.LoadPrevious();

            GetNewData();
            CheckInteractability();
        }

        private void OnKeyRight()
        {
            if (!_next.interactable) return;

            _charactersSender.LoadNext();

            GetNewData();
            CheckInteractability();
        }

        private void OnKeyLeft()
        {
            if (!_previous.interactable) return;

            _charactersSender.LoadPrevious();

            GetNewData();
            CheckInteractability();
        }
        #endregion
    }
}