using System;
using System.Linq;
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

        #endregion

        #endregion

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
            KillNPC(HP_NPCSpawnManager.Instance.sessionNPCs[Random.Range(0, _spawnedNPCs.Count)]);
        }

        public void KillNPC(string npcID)
        {
            foreach (var npc in HP_NPCSpawnManager.Instance.sessionNPCs.Where(npc => npc == npcID))
            {
                HP_NPCSpawnManager.Instance.sessionNPCs.Remove(npc);
                break;
            }
            
            foreach (var npc in _spawnedNPCs.Where(n => n.GetID == npcID))
            {
                if (npc.GetID != npcID) continue;
                npc.gameObject.SetActive(false);
                _spawnedNPCs.Remove(npc);
            }
        }

        public void SaveNPCs()
        {
            HP_NPCSpawnManager.Instance.Save();
        }
        
        public void LoadNPCs()
        {
            HP_NPCSpawnManager.Instance.Load();
        }
    }
}