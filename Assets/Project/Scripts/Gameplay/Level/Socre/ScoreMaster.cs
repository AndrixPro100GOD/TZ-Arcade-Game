using UnityEngine;

namespace Gameplay.Level.Socre
{
    public class ScoreMaster
    {
        private int _maxScore = 0;
        private int lastScore = 0;
        private const string _maxScoreKey = "PlayerMaxScore";

        public int GetMaxScore
        {
            get
            {
                if (_maxScore == 0)
                {
                    _maxScore = PlayerPrefs.GetInt(_maxScoreKey);
                }

                return _maxScore;
            }
        }

        public int GetCurrentScore { get; private set; } = 0;

        public void ResetCurrentScore()
        {
            GetCurrentScore = 0;
        }

        public void AddPoints(int points)
        {
            GetCurrentScore += points;
        }

        public void PlayerFinishGettingPoints()
        {
            if (GetCurrentScore > GetMaxScore)
            {
                SetNewMaxScore(GetCurrentScore);
            }

            lastScore = GetCurrentScore;
        }

        private void SetNewMaxScore(int score)
        {
            _maxScore = score;
            PlayerPrefs.SetInt(_maxScoreKey, score);
            PlayerPrefs.Save();
        }
    }
}