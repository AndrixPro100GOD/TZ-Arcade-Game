using TMPro;

using UnityEngine;

namespace UI.Socre
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreCurrentUIText : BaseTextMesh<TextMeshProUGUI>
    {
        private const string _scoreWord = "Score: ";

        public void SetScore(int score)
        {
            base.SetText(string.Concat(_scoreWord, score));
        }
    }
}