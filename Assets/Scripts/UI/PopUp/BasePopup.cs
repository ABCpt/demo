using GameStates;
using GameStates.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.PopUp
{
    public class BasePopup : MonoBehaviour
    {
        [SerializeField] private Button RestartButton;

        private GameStateService _gameStateService;

        [Inject]
        public void Construct(GameStateService gameStateService)
        {
            _gameStateService = gameStateService;
            _gameStateService.ChangeState += OnChangeState;
        }

        private void OnEnable()
        {
            RestartButton.onClick.AddListener(OnRestartButton);
        }

        private void OnDisable()
        {
            RestartButton.onClick.RemoveListener(OnRestartButton);
        }

        private void OnDestroy()
        {
            _gameStateService.ChangeState -= OnChangeState;
        }

        private void OnRestartButton()
        {
            Debug.Log(_gameStateService);
            _gameStateService.SetState<EnterGameState>();
        }

        protected virtual void OnChangeState(BaseGameState gameState)
        {
            if (gameState is EnterGameState)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
