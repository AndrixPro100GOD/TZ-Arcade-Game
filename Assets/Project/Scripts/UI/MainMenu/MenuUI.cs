using UnityEngine;

namespace UI.MainMenu
{
    public class MenuUI : MonoBehaviour
    {
        public void View(bool value)
        {
            this.gameObject.SetActive(value);
        }
    }
}