namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Managers
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Connectors;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Controllers;
    
    public class HP_NPCSpawnManager : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected List<string> availableNpcs, sessionNpcs;
        protected DataController dataController;
        protected DataConnector dataConnector;
        
        #endregion

        #region Public Variables

        public List<string> GetAvailableNpcs => availableNpcs;
        public List<string> GetSessionNpcs => sessionNpcs;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected void Awake()
        {
            dataController = gameObject.GetComponent<DataController>();
            dataConnector = gameObject.GetComponent<DataConnector>();
        }

        #endregion

        #region Public Methods

        public void Save()
        {
            dataController.QueueToSave(dataConnector);
            dataController.Save();
        }

        public void Load()
        {
            try
            {
                dataController.QueueToLoad(dataConnector);
                dataController.Load(dataConnector);
            }
            catch (Exception) {/* ignored */}
        }

        public void OnLoadSuccess()
        {
            availableNpcs = sessionNpcs;
            sessionNpcs = new List<string>();
            
            foreach (var availableNpc in availableNpcs)
                sessionNpcs.Add(availableNpc);
        }
        public void OnLoadFail()
        {
            sessionNpcs = new List<string>();
            
            foreach (var availableNpc in availableNpcs)
                sessionNpcs.Add(availableNpc);
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

                var go = Instantiate(Resources.Load("Managers/HP_NPCSpawnManager") as GameObject);
                go.name = "@HP_NPCSpawnManager";
                _instance = go.GetComponent<HP_NPCSpawnManager>();

                DontDestroyOnLoad(go); 
                return _instance;
            }
        }

        #endregion
    }
}