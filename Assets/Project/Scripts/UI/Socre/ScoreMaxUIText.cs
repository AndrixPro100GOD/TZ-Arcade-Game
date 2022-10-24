using TMPro;

using UnityEngine;

namespace UI.Socre
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreMaxUIText : BaseTextMesh<TextMeshProUGUI>
    {
        private const string _scoreWord = "Best score: ";

        public void SetScore(int score)
        {
            base.SetText(string.Concat(_scoreWord, score));
        }
    }
}