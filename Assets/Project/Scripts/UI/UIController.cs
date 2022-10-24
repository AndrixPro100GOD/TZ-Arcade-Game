using UI.MainMenu;
using UI.Socre;

using UnityEngine;

using static Core.GameEvents;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [Space(5f)]
        [Header("References")]
        [SerializeField]
        private MainMenuUIController mainMenu;

        [SerializeField]
        private ScoreManagerUI scoreManagerUI;

#if DEBUG

        private void OnValidate()
        {
            Extensions.DebugExtended.AssertNull(mainMenu, typeof(MainMenuUIController));
        }

#endif

        #region MonoBeg

        private void OnEnable()
        {
            mainMenu.OnMenuToggleView += MenuViewToggle;
            //score
            OnKillGiveScore += PlayerGetPoints;
        }

        private void OnDisable()
        {
            mainMenu.OnMenuToggleView -= MenuViewToggle;
            //score
            OnKillGiveScore -= PlayerGetPoints;
        }

        private void Start()
        {
            mainMenu.Init();
        }

        #endregion MonoBeg

        public void MenuViewToggle(bool toggle)
        {
            scoreManagerUI.ShowCurrentScore(true);
            scoreManagerUI.ShowMaxScore(toggle);
        }

        public void PlayerGetPoints(int points)
        {
            scoreManagerUI.UpdateCurrentScore();
        }
    }
}