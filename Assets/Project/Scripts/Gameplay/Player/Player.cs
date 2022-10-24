using System;

using UnityEngine;

using static Core.GameEvents;

namespace Gameplay.Player
{
    [SelectionBase]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour, IPlayer
    {
        [SerializeField]
        private PlayerInputController playerInput;

        [SerializeField]
        private PlayerMovementController playerMovement;

        [SerializeField]
        private PlayerShooterController playerShooterController;

        [SerializeField]
        private GameObject graphicHolder;

        private Rigidbody2D _playerRigidbody2D;

        #region Momobeh

        private void Awake()
        {
            _playerRigidbody2D = GetComponent<Rigidbody2D>();
            graphicHolder.SetActive(false);
            Init();
        }

        private void OnEnable()
        {
            RespawnPlayer += Respawn;
        }

        private void OnDisable()
        {
            RespawnPlayer -= Respawn;
        }

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        #endregion Momobeh

        #region Events & Callbacks

        public static Action<Vector2> RespawnPlayer { get; private set; }

        #endregion Events & Callbacks

        private void Init()
        {
            _ = playerInput.Init();
            playerMovement.Init(playerInput, _playerRigidbody2D);
        }

        #region player's methods

        public void Respawn(Vector2 spawnPoint)
        {
            transform.position = spawnPoint;

            graphicHolder.SetActive(true);

            playerInput.SetEnable(true);
            playerMovement.SetEnable(true);

            playerShooterController.ShootToggle(true);

            OnPlayerRespawned?.Invoke();
        }

        public void Die()
        {
            graphicHolder.SetActive(false);

            playerInput.SetEnable(false);
            playerMovement.SetEnable(false);

            playerShooterController.ShootToggle(false);

            OnPlayerDied?.Invoke();
        }

        #endregion player's methods
    }
}