namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using Toolbox.Runtime.Scripts;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Scenes = Models.HP_Constants.Scenes;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Controllers/HP Pause Menu Controller")]
    public class HP_PauseMenuController : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected HP_PauseMenuController mainMenuPNL;
        [SerializeField] protected HP_SettingsMenuController settingsPNL;

        #endregion

        #endregion
        
        #region Methods

        #region Public Methods

        /// <summary>
        /// Changes the pause state.
        /// </summary>
        public void OnPauseButtonPressed()
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }
        
        /// <summary>
        /// Go to the settings menu.
        /// </summary>
        public void OnSettingsButtonPressed()
        {
            LeanTween.move(mainMenuPNL.GetComponent<RectTransform>(), new Vector2(-Screen.width - 500, 0), 0.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
            {
                mainMenuPNL.gameObject.SetActive(false);
                LeanTween.move(settingsPNL.GetComponent<RectTransform>(), new Vector2(-Screen.width - 500, 0), 0f);
                settingsPNL.gameObject.SetActive(true);

                LeanTween.move(settingsPNL.GetComponent<RectTransform>(), new Vector2(0, 0), 0.55f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
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