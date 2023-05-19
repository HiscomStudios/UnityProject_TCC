namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using UnityEngine;
    using UnityEngine.Audio;
    using Settings = Models.HP_Constants.Settings;
    using Input = HiscomEngine.Runtime.Scripts.Structures.Extensions.InputExtensions;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Controllers/HP Settings Controller")]
    public class HP_SettingsController : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected AudioMixer audioMixer;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected void Start()
        {
            UpdateSettings();
        }

        #endregion
    
        #region Public Methods

        public virtual void UpdateSettings()
        {
            audioMixer.SetFloat(Settings.MasterVolume, PlayerPrefs.GetInt(Settings.MasterVolume));
            audioMixer.SetFloat(Settings.MusicVolume, PlayerPrefs.GetInt(Settings.MusicVolume));
            audioMixer.SetFloat(Settings.SFXVolume, PlayerPrefs.GetInt(Settings.SFXVolume));
            Input.mouseSensibility = PlayerPrefs.GetFloat(Settings.MouseSensibility);
            
        }

        #endregion

        #endregion
    }
}