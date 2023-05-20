namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using Toolbox.Runtime.Scripts;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using System;
    using UnityEngine.Events;
    using Scenes = Models.HP_Constants.Scenes;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Controllers/HP Pause Menu Controller")]
    public class HP_PauseMenuController : MonoBehaviour
    {
        protected enum PauseMode
        {
            Unpaused,
            Paused
        }

        #region Variables

        #region Protected Variables

        [SerializeField] protected RectTransform pausePNL;
        [SerializeField] protected HP_PauseMenuController pauseMenuPNL;
        [SerializeField] protected HP_SettingsMenuController settingsPNL;
        [SerializeField] protected UnityEvent eventToExecuteOnPause, eventToExecuteOnUnpause;
        protected PauseMode pauseMode;

        #endregion

        #endregion
        
        #region Methods

        #region Protected Methods

        protected void Start()
        {
            pauseMode = PauseMode.Unpaused;
            LeanTween.move(pausePNL, new Vector2(-Screen.width - 500, 0), 0).setIgnoreTimeScale(true);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Changes the pause state.
        /// </summary>
        public void OnPauseButtonPressed()
        {
            switch (pauseMode)
            {
                case PauseMode.Unpaused:
                    pauseMode = PauseMode.Paused;
                    Time.timeScale = 0;
                    LeanTween.move(pausePNL, new Vector2(0, 0), 0.55f).setEase(LeanTweenType.easeInOutExpo).setIgnoreTimeScale(true).setOnComplete(() =>
                    {
                        eventToExecuteOnPause?.Invoke();
                    });
                    break;
                case PauseMode.Paused:
                    pauseMode = PauseMode.Unpaused;
                    LeanTween.move(pausePNL, new Vector2(-Screen.width - 500, 0), 0.55f).setEase(LeanTweenType.easeInOutExpo).setIgnoreTimeScale(true).setOnComplete(() =>
                    {
                        eventToExecuteOnUnpause?.Invoke();
                    });
                    Time.timeScale = 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        /// <summary>
        /// Go to the settings menu.
        /// </summary>
        public void OnSettingsButtonPressed()
        {
            LeanTween.move(pauseMenuPNL.GetComponent<RectTransform>(), new Vector2(-Screen.width - 500, 0), 0.5f).setEase(LeanTweenType.easeInOutExpo).setIgnoreTimeScale(true).setOnComplete(() =>
            {
                pauseMenuPNL.gameObject.SetActive(false);
                LeanTween.move(settingsPNL.GetComponent<RectTransform>(), new Vector2(-Screen.width - 500, 0), 0f).setIgnoreTimeScale(true);
                settingsPNL.gameObject.SetActive(true);

                LeanTween.move(settingsPNL.GetComponent<RectTransform>(), new Vector2(0, 0), 0.55f).setEase(LeanTweenType.easeInOutExpo).setIgnoreTimeScale(true).setOnComplete(() =>
                {
                    settingsPNL.OnMenuOpened();
                });
            });
        }

        /// <summary>
        /// Go to the main menu.
        /// </summary>
        public void OnQuitButtonPressed()
        {
            Navigator.Navigate(Scenes.MainMenuScene, LoadSceneMode.Single);
        }

        #endregion

        #endregion
    }
}