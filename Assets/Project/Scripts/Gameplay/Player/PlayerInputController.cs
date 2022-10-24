using System;

using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Player
{
    [System.Serializable]
    public class PlayerInputController : IPlayerController, IPlayerInputLisener
    {
        [SerializeField]
        private PlayerInput m_PlayerInput;

        [SerializeField]
        private Camera gameCamera;

        bool IPlayerController.IsEnable { get => _SubState; set => SetEnable(value); }

        public void SetEnable(bool value)
        {
            if (value != _SubState)
            {
                if (value)
                {
                    SubToPlayerInput();
                    u_PlayerInputAction.Player.Enable();
                }
                else
                {
                    UnsubToPlayerInput();
                    u_PlayerInputAction.Player.Disable();
                }
            }
        }

        private PlayerInputAction u_PlayerInputAction;

        #region Init

        public PlayerInputController Init()
        {
            u_PlayerInputAction = new PlayerInputAction();
            return this;
        }

        #endregion Init

        #region Input

        public bool IsEnable => _SubState;

        private bool _SubState = false;

        private void SubToPlayerInput()
        {
            _SubState = true;

            //Move

            u_PlayerInputAction.Player.MovePoint.performed += MovementFromInput;
            u_PlayerInputAction.Player.MovePoint.canceled += MovementCanceledFromInput;

            //Shoot
            u_PlayerInputAction.Player.Fire.performed += ShootFromInput;
        }

        private void UnsubToPlayerInput()
        {
            _SubState = false;

            //Move
            u_PlayerInputAction.Player.MovePoint.performed -= MovementFromInput;
            u_PlayerInputAction.Player.MovePoint.canceled -= MovementCanceledFromInput;

            //Shoot
            u_PlayerInputAction.Player.Fire.performed -= ShootFromInput;
        }

        #endregion Input

        #region IPlayerInput

        public void MovementFromInput(InputAction.CallbackContext context)
        {
            PlayerMove?.Invoke(gameCamera.ScreenToWorldPoint(context.ReadValue<Vector2>()));
        }

        public void MovementCanceledFromInput(InputAction.CallbackContext context)
        {
            PlayerMoveEnd?.Invoke(gameCamera.ScreenToWorldPoint(context.ReadValue<Vector2>()));
        }

        public void ShootFromInput(InputAction.CallbackContext context)
        {
            PlayerShoot?.Invoke(context.ReadValueAsButton());
        }

        public System.Action<Vector2> PlayerMove { get; set; }
        public Action<Vector2> PlayerMoveEnd { get; set; }

        public Action<bool> PlayerShoot { get; set; }

        #endregion IPlayerInput
    }
}