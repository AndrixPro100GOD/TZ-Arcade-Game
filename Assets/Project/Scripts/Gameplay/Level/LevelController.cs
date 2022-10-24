using Gameplay.Level.Socre;
using Gameplay.Obstacles;

using System.Linq;

using UnityEngine;

using static Core.GameEvents;

namespace Gameplay.Level
{
    public class LevelController : MonoBehaviour
    {
        [Header("References")]
        [SerializeReference]
        private Obstacles.ObstaclesSpawner obstaclesSpawner;

        [SerializeField]
        private Transform SpawnPoint;

        [Header("Config")]
        [SerializeField]
        private int playerLifesCount = 3;

        private readonly ScoreMaster _scoreMaster = new();

        private bool _isGameOver = true;
        public bool IsGameOver
        { get => _isGameOver; private set { OnGameOver?.Invoke(value); _isGameOver = value; } }

        private int PlayerLifes { get; set; }

        #region MonoBeh

        private void OnEnable()
        {
            OnPlayerDied += PlayerDied;
            OnPlayerPressedPlayButton += StartGame;
            //score
            OnKillGiveScore += GivePointsForKill;
            GetCurrentScore += GetCurrentPlayerScore;
            GetMaxScore += GetMaxPlayerScore;
        }

        private void OnDisable()
        {
            OnPlayerDied -= PlayerDied;
            OnPlayerPressedPlayButton -= StartGame;
            //score
            OnKillGiveScore -= GivePointsForKill;
            GetCurrentScore -= GetCurrentPlayerScore;
            GetMaxScore -= GetMaxPlayerScore;
        }

        private void Awake()
        {
            Init();
        }

        #endregion MonoBeh

        public void Init()
        {
        }

        public void StartGame()
        {
            if (IsGameOver)
            {
                IsGameOver = false;

                FindObjectsOfType<BaseObstacle>().ToList().ForEach(obstacle => Destroy(obstacle.gameObject));// TODO: do Implement poolObject

                Player.Player.RespawnPlayer?.Invoke(SpawnPoint.position);

                (obstaclesSpawner as ISpawner).StartSpawn();

                ResetCurrentScore();

                PlayerLifes = playerLifesCount;
            }
        }

        private void PlayerDied()
        {
            PlayerLifes -= 1;

            if (PlayerLifes < 1)
            {
                GameOver();
            }
            else
            {
                Player.Player.RespawnPlayer?.Invoke(SpawnPoint.position);
            }
        }

        private void GameOver()
        {
            (obstaclesSpawner as ISpawner).StopSpawn();

            PlayerFinishGettingPoints();

            IsGameOver = true;

            //TODO: showBestScore
            //TODO: show lose Screen
        }

        #region Score

        private void GivePointsForKill(int points)
        {
            _scoreMaster.AddPoints(points);
        }

        private void ResetCurrentScore()
        {
            _scoreMaster.ResetCurrentScore();
        }

        private void PlayerFinishGettingPoints()
        {
            _scoreMaster.PlayerFinishGettingPoints();
        }

        private int GetCurrentPlayerScore()
        {
            return _scoreMaster.GetCurrentScore;
        }

        private int GetMaxPlayerScore()
        {
            return _scoreMaster.GetMaxScore;
        }

        #endregion Score
    }
}