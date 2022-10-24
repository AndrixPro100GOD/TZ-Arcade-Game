using UnityEngine;

namespace UI.Socre
{
    [System.Serializable]
    public class ScoreManagerUI
    {
        [SerializeField]
        private ScoreMaxUIText scoreMaxUIText;

        [SerializeField]
        private ScoreCurrentUIText scoreCurrentUIText;

        private int GetMaxScore
        {
            get
            {
                int? maxScore = Core.GameEvents.GetMaxScore?.Invoke();
                if (maxScore != null)
                {
                    return maxScore.Value;
                }

                return 0;
            }
        }

        private int GetCurrentScore
        {
            get
            {
                int? currentScore = Core.GameEvents.GetCurrentScore?.Invoke();
                if (currentScore != null)
                {
                    return currentScore.Value;
                }

                return 0;
            }
        }

        public void ShowMaxScore(bool value)
        {
            scoreMaxUIText.gameObject.SetActive(value);

            if (value == false)
                return;

            scoreMaxUIText.SetScore(GetMaxScore);
        }

        public void ShowCurrentScore(bool value)
        {
            scoreCurrentUIText.gameObject.SetActive(value);

            if (value == false)
                return;

            scoreCurrentUIText.SetScore(GetCurrentScore);
        }

        public void UpdateCurrentScore()
        {
            scoreCurrentUIText.SetScore(GetCurrentScore);
        }
    }
}