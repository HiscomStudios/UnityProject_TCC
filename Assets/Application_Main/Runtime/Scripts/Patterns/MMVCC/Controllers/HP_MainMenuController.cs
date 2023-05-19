namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using System.IO;
    using UnityEngine;
    using Toolbox.Runtime.Scripts;
    using UnityEngine.SceneManagement;
    using HiscomEngine.Runtime.Scripts.Structures.ScriptableObjects;
    using Scenes = Models.HP_Constants.Scenes;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Controllers/HP Main Menu Controller")]
    public class HP_MainMenuController : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected string fileName;
        [SerializeField] protected DataRulesScriptableObject dataRules;

        [SerializeField] protected HP_MainMenuController mainMenuPNL;
        [SerializeField] protected HP_SettingsMenuController settingsPNL;

        #endregion

        #endregion
        
        #region Methods

        #region Protected Methods

        protected void Start()
        {
            mainMenuPNL.gameObject.SetActive(true);
            settingsPNL.gameObject.SetActive(false);
        }

        #endregion
        
        #region Public Methods

        /// <summary>
        /// Starts a saved game.
        /// </summary>
        public void OnContinueGameButtonPressed()
        {
            Navigator.Navigate(Scenes.LoadScene, LoadSceneMode.Single);
        }

        /// <summary>
        /// Starts a new game.
        /// </summary>
        public void OnNewGameButtonPressed()
        {
            var savePath = $"{Path.Combine(dataRules.GetDataPath, dataRules.GetSaveFolder, fileName)}{dataRules.GetFileType}";
            
            if (File.Exists(savePath))
                File.Delete(savePath);
            
            Navigator.Navigate(Scenes.LoadScene, LoadSceneMode.Single);
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
        /// Quits the game.
        /// </summary>
        public void OnQuitButtonPressed()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        
            Application.Quit();
        }
    
        #endregion
    
        #endregion
    }
}