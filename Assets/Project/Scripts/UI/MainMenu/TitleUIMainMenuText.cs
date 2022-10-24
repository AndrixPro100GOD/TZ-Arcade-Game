using TMPro;

using UnityEngine;

namespace UI.MainMenu
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TitleUIMainMenuText : BaseTextMesh<TextMeshProUGUI>
    {
        public void SetTitleName(string title)
        {
            SetText(title);
        }
    }
}