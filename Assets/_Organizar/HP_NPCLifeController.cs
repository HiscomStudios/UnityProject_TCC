using System;
using HiscomEngine.Core.Runtime.Scripts.Patterns.MMVCC.Connectors;
using HiscomEngine.Core.Runtime.Scripts.Patterns.MMVCC.Controllers;

namespace HiscomProject.Scripts.Patterns.MMVCC.Controllers
{
    using System.Collections.Generic;
    using UnityEngine;
    using Managers;
    using Views;

    public class HP_NPCLifeController : MonoBehaviour
    {
        #region Variables

        #region Private Variables
        
        private List<HP_NPCView> _spawnedNPCs = new();
        
        private DataController dataController;
        private DataConnector dataConnector;
        
        #endregion

        #endregion

        private void Start()
        {
            dataController = HP_NPCSpawnManager.Instance.gameObject.GetComponent<DataController>();
            dataConnector = HP_NPCSpawnManager.Instance.gameObject.GetComponent<DataConnector>();
        }

        public void SpawnNPC()
        {
            foreach (var npc in FindObjectsOfType<HP_NPCView>())
            {
                npc.gameObject.SetActive(false);
                if (!HP_NPCSpawnManager.Instance.sessionNPCs.Contains(npc.GetID)) continue;
                npc.gameObject.SetActive(true);
                _spawnedNPCs.Add(npc);
            }
        }

        public void KillRandomNPC()
        {
            KillNPC(Random.Range(0, _spawnedNPCs.Count));
        }

        public void KillNPC(int npcToKillID)
        {
            HP_NPCSpawnManager.Instance.sessionNPCs.RemoveAt(npcToKillID);
            Destroy(_spawnedNPCs[npcToKillID].gameObject);
        }
        
        public void SaveNPCs()
        {
            dataController.QueueToSave(dataConnector);
            dataController.Save();
        }
    }
}