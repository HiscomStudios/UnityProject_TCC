namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Managers
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Connectors;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Controllers;
    using Views.Internal;
    
    public class HP_NPCSpawnManager : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected List<HP_NPCView> availableNpcs, sessionNpcs;

        #endregion

        #region Public Variables

        public List<HP_NPCView> GetAvailableNpcs => availableNpcs;
        public List<HP_NPCView> GetSessionNpcs => sessionNpcs;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected virtual void Awake()
        {
            instance = this;
        }

        #endregion

        #region Public Methods

        public virtual void OnLoadSuccess()
        {
            availableNpcs = sessionNpcs;
            sessionNpcs = new List<HP_NPCView>();
            
            foreach (var availableNpc in availableNpcs)
                sessionNpcs.Add(availableNpc);
        }
        public virtual void OnLoadFail()
        {
            sessionNpcs = new List<HP_NPCView>();
            
            foreach (var availableNpc in availableNpcs)
                sessionNpcs.Add(availableNpc);
        }

        #endregion

        #endregion
        
        #region Singleton
        
        protected static HP_NPCSpawnManager instance;
        public static HP_NPCSpawnManager Instance
        {
            get
            {
                if (instance != null) return instance;

                var go = Instantiate(Resources.Load("Managers/HP_NPCSpawnManager") as GameObject);
                go.name = "@HP_NPCSpawnManager";
                instance = go.GetComponent<HP_NPCSpawnManager>();
                instance.OnLoadFail();

                DontDestroyOnLoad(go); 
                return instance;
            }
        }

        #endregion
    }
}