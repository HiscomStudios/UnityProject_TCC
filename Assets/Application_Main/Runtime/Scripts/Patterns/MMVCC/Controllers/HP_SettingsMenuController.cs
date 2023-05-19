namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using UnityEngine;
    using UnityEngine.UI;
    using Settings = Models.HP_Constants.Settings;

    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Controllers/HP Settings Menu Controller")]
    public class HP_SettingsMenuController : MonoBehaviour
    {
        protected enum OpenedPanel
        {
            Audio,
            Controls
        }

        #region Variables

        #region Protected Variables
        
        [SerializeField] protected RectTransform mainMenuPNL, settingsPNL;
        [SerializeField] protected CanvasGroup audioCanvasGroup, controlsCanvasGroup;
        [SerializeField] protected Slider masterVolumeSlider, musicVolumeSlider, sfxVolumeSlider, mouseSensibilitySlider;
        
        protected bool isAnimating;
        protected OpenedPanel openedPanel;
        
        #endregion

        #endregion
        
        #region Methods

        #region Protected Methods

        protected virtual void Start()
        {
            Setup();
            
            if (PlayerPrefs.HasKey(Settings.MasterVolume))
            {
                masterVolumeSlider.value = PlayerPrefs.GetInt(Settings.MasterVolume);
            }
            else
            {
                PlayerPrefs.SetInt(Settings.MasterVolume, -80);
            }
            
            if (PlayerPrefs.HasKey(Settings.MusicVolume))
            {
                musicVolumeSlider.value = PlayerPrefs.GetInt(Settings.MusicVolume);
            }
            else
            {
                PlayerPrefs.SetInt(Settings.MusicVolume, -80);
            }
            
            if (PlayerPrefs.HasKey(Settings.SFXVolume))
            {
                sfxVolumeSlider.value = PlayerPrefs.GetInt(Settings.SFXVolume);
            }
            else
            {
                PlayerPrefs.SetInt(Settings.SFXVolume, -80);
            }
            
            if (PlayerPrefs.HasKey(Settings.MouseSensibility))
            {
                mouseSensibilitySlider.value = PlayerPrefs.GetFloat(Settings.MouseSensibility);
            }
            else
            {
                PlayerPrefs.SetFloat(Settings.MouseSensibility, 1);
            }
        }
        protected void Setup()
        {
            var audioCanvasGroupGameObject = audioCanvasGroup.gameObject;
            var controlsCanvasGroupGameObject = controlsCanvasGroup.gameObject;
            LeanTween.alphaCanvas(audioCanvasGroup, 0, 0).setIgnoreTimeScale(true);
            LeanTween.alphaCanvas(controlsCanvasGroup, 0, 0).setIgnoreTimeScale(true);
            audioCanvasGroupGameObject.SetActive(false);
            controlsCanvasGroupGameObject.SetActive(false);
        }

        #endregion
        
        #region Public Methods

        public virtual void OnMenuOpened()
        {
            Setup();
            openedPanel = OpenedPanel.Controls;
            OnAudioButtonPressed();
        }

        public virtual void OnAudioButtonPressed()
        {
            if (openedPanel == OpenedPanel.Audio || isAnimating) return;
            isAnimating = true;
            openedPanel = OpenedPanel.Audio;

            var controlsCanvasGroupGameObject = controlsCanvasGroup.gameObject;
            controlsCanvasGroupGameObject.SetActive(true);
            
            LeanTween.alphaCanvas(controlsCanvasGroup, 0, .25f).setIgnoreTimeScale(true).setOnComplete(() =>
            {
                var audioCanvasGroupGameObject = audioCanvasGroup.gameObject;
                LeanTween.alphaCanvas(audioCanvasGroup, 0, 0).setIgnoreTimeScale(true);
                audioCanvasGroupGameObject.SetActive(true);
                controlsCanvasGroupGameObject.SetActive(false);
                
                LeanTween.alphaCanvas(audioCanvasGroup, 1, .25f).setIgnoreTimeScale(true).setOnComplete(() => isAnimating = false);
            });
        }
        public virtual void OnMainVolumeSliderValueChanged(float value)
        {
            PlayerPrefs.SetInt(Settings.MasterVolume, (int)value);
        }
        public virtual void OnMusicVolumeSliderValueChanged(float value)
        {
            PlayerPrefs.SetInt(Settings.MusicVolume, (int)value);
        }
        public virtual void OnSFXVolumeSliderValueChanged(float value)
        {
            PlayerPrefs.SetInt(Settings.SFXVolume, (int)value);
        }
        
        public virtual void OnControlsButtonPressed()
        {
            if (openedPanel == OpenedPanel.Controls || isAnimating) return;
            isAnimating = true;
            openedPanel = OpenedPanel.Controls;
            
            var audioCanvasGroupGameObject = audioCanvasGroup.gameObject;
            audioCanvasGroupGameObject.SetActive(true);
            
            LeanTween.alphaCanvas(audioCanvasGroup, 0, .25f).setIgnoreTimeScale(true).setOnComplete(() =>
            {
                var controlsCanvasGroupGameObject = controlsCanvasGroup.gameObject;
                LeanTween.alphaCanvas(controlsCanvasGroup, 0, 0).setIgnoreTimeScale(true);
                controlsCanvasGroupGameObject.SetActive(true);
                audioCanvasGroupGameObject.SetActive(false);
                
                LeanTween.alphaCanvas(controlsCanvasGroup, 1, .25f).setIgnoreTimeScale(true).setOnComplete(() => isAnimating = false);
            });
        }
        public virtual void OnMouseSensibilitySliderValueChanged(float value)
        {
            PlayerPrefs.SetFloat(Settings.MouseSensibility, value);
        }
        
        public virtual void OnBackButtonPressed()
        {
            LeanTween.move(settingsPNL, new Vector2(-Screen.width - 500, 0), 0.5f).setEase(LeanTweenType.easeInOutExpo).setIgnoreTimeScale(true).setOnComplete(() =>
            {
                Setup();
                
                settingsPNL.gameObject.SetActive(false);
                LeanTween.move(mainMenuPNL, new Vector2(-Screen.width - 500, 0), 0f).setIgnoreTimeScale(true);
                mainMenuPNL.gameObject.SetActive(true);

                LeanTween.move(mainMenuPNL, new Vector2(0, 0), 0.55f).setIgnoreTimeScale(true).setEase(LeanTweenType.easeInOutExpo);
            });
        }

        #endregion

        #endregion
    }
}