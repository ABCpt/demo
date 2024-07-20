using Core.Player.Model;
using UnityEngine;
using Zenject;

namespace Core.Player.View
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerModel _playerModel;
        
        [Inject]
        public void Construct(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void OnEnable()
        {
            _playerModel.UpdatePosition += OnUpdatePosition;
            OnUpdatePosition();
        }

        public void OnDisable()
        {
            _playerModel.UpdatePosition -= OnUpdatePosition;
        }
        
        private void OnUpdatePosition()
        {
            transform.position = _playerModel.Position;
        }
    }
}
