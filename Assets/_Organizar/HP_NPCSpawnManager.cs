namespace HiscomProject.Scripts.Patterns.MMVCC.Managers
{
    using Unity.VisualScripting;
    using System.Collections.Generic;
    using UnityEngine;
    using Views;
    
    public class HP_NPCSpawnManager : MonoBehaviour
    {
        #region Variables

        #region Private Variables
        
        public List<string> availableNPCs;
        public List<string> sessionNPCs;

        #endregion

        #endregion

        #region Methods

        #region Private Methods

        private void Setup()
        {
            sessionNPCs = new List<string>();
            
            foreach (var availableNPC in availableNPCs)
                sessionNPCs.Add(availableNPC);
        }

        #endregion

        #endregion
        
        #region Singleton
        
        private static HP_NPCSpawnManager _instance;
        public static HP_NPCSpawnManager Instance
        {
            get
            {
                if (_instance != null) return _instance;

                var go = Instantiate(Resources.Load("Managers/HP_NPCSpawnManager"));
                go.name = "@HP_NPCSpawnManager";
                _instance = go.GetComponent<HP_NPCSpawnManager>();
                _instance.Setup();
                
                DontDestroyOnLoad(go); 
                return _instance;
            }
        }

        #endregion
    }
}