using Extensions;

using System;

using UnityEngine;

using static Core.GameEvents;

namespace UI.MainMenu
{
    public class MainMenuUIController : MonoBehaviour
    {
        [SerializeField]
        private MenuUI MenuUI;

        [SerializeField]
        private TitleUIMainMenuText titleMainMenuText;

        [SerializeField]
        private UIPlayButtonText playButtonText;

        [SerializeField]
        private PauseButtonUI pauseButtonUI;

        [Space(5)]
        [Header("Config")]
        [SerializeField]
        private string GameNameInMainMenu = "The game";

        private bool _isMenuShowToggle = true;
        private const string playText = "Play", continueText = "Continue";

        private bool IsMenuShowToggle
        {
            get => _isMenuShowToggle;
            set
            {
                MenuUI.View(value);
                pauseButtonUI.View(!value);

                _isMenuShowToggle = value;
                OnMenuToggleView?.Invoke(value);
            }
        }

        public Action<bool> OnMenuToggleView { get; set; }

        #region MonoBeh

#if DEBUG

        private void OnValidate()
        {
            DebugExtended.AssertNull(titleMainMenuText, typeof(TitleUIMainMenuText));
            SetTitleName(GameNameInMainMenu);
        }

#endif

        private void OnEnable()
        {
            OnGameOver += GameOver;
        }

        private void OnDisable()
        {
            OnGameOver -= GameOver;
        }

        #endregion MonoBeh

        public void Init()
        {
            SetTitleName(GameNameInMainMenu);
            IsMenuShowToggle = true;
            GameOver(true);
        }

        public void SetTitleName(string title)
        {
            titleMainMenuText?.SetTitleName(title);
        }

        public void PlayButton()
        {
            OnPlayerPressedPlayButton?.Invoke();
            IsMenuShowToggle = false;
            Time.timeScale = 1;
        }

        public void PauseButton()
        {
            IsMenuShowToggle = true;
            Time.timeScale = 0;
        }

        private void GameOver(bool value)
        {
            if (value)
            {
                PauseButton();
                playButtonText.SetTextForButton(playText);
            }
            else
            {
                playButtonText.SetTextForButton(continueText);
            }
        }

        public void SettingsButton()
        {
            //hide buttons of main menu
            //open menu
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    }
}