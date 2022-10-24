using UnityEngine;

namespace UI.MainMenu
{
    public class PauseButtonUI : MonoBehaviour
    {
        public void View(bool value)
        {
            this.gameObject.SetActive(value);
        }
    }
}