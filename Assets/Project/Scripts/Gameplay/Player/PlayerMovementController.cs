using UnityEngine;

namespace Gameplay.Player
{
    [System.Serializable]
    public class PlayerMovementController : IPlayerController
    {
        [SerializeField]
        [Range(0.1f, 100f)]
        private float maxSpeed = 1.0f;

        private bool _isEnable;
        private Rigidbody2D _playerRigidbody2D;
        private IPlayerInputLisener _playerInput;
        private Vector2 _lastPoint = Vector2.zero;

        bool IPlayerController.IsEnable { get => _isEnable; set => SetEnable(value); }

        public void Init(IPlayerInputLisener playerInput, Rigidbody2D playerRb2D)
        {
            _playerInput = playerInput;

            _playerRigidbody2D = playerRb2D;
            _playerRigidbody2D.gravityScale = 0;
            _playerRigidbody2D.freezeRotation = true;
        }

        public void SetEnable(bool value)
        {
            if (_isEnable == value)
            {
                return;
            }

            _isEnable = value;

            if (_isEnable)
            {
                _playerInput.PlayerMove += Move;
                _playerInput.PlayerMoveEnd += MoveEnd;
            }
            else
            {
                _playerInput.PlayerMove -= Move;
                _playerInput.PlayerMoveEnd -= MoveEnd;
            }
        }

        public void Move(Vector2 vectorDir)
        {
            if (!_isEnable)
            {
                return;
            }

            MoveToPoint(vectorDir);

            _playerRigidbody2D.velocity = Vector3.ClampMagnitude(_playerRigidbody2D.velocity, maxSpeed);
        }

        private void MoveEnd(Vector2 vectorDir)
        {
            _lastPoint = default;
        }

        private void MoveToPoint(in Vector2 point)
        {
            if (_lastPoint != Vector2.zero && _lastPoint != point)
            {
                Vector2 offset = _lastPoint - point;

                _playerRigidbody2D.MovePosition(_playerRigidbody2D.position - offset);
            }

            _lastPoint = point;
        }

        private void MoveDelta(in Vector2 delta)
        {
            _playerRigidbody2D.AddForce(delta, ForceMode2D.Impulse);
        }
    }
}