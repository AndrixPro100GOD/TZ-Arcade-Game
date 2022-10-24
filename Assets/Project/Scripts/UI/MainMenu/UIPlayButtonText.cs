using TMPro;

using UnityEngine;

namespace UI.MainMenu
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class UIPlayButtonText : UI.BaseTextMesh<TextMeshProUGUI>
    {
        public void SetTextForButton(string text)
        {
            base.SetText(text);
        }
    }
}