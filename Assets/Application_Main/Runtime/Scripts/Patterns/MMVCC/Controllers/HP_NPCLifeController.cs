namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using System.Linq;
    using System.Collections.Generic;
    using UnityEngine;
    using Managers;
    using Views;

    public class HP_NPCLifeController : MonoBehaviour
    {
        #region Variables

        #region Protected Variables
        
        protected List<HP_NPCView> spawnedNpcs = new();

        #endregion

        #region Public Variables

        public List<HP_NPCView> GetSpawnedNpcs => spawnedNpcs;

        #endregion

        #endregion

        public void SpawnNPC()
        {
            foreach (var npc in FindObjectsOfType<HP_NPCView>())
            {
                npc.gameObject.SetActive(false);
                if (!HP_NPCSpawnManager.Instance.GetAvailableNpcs.Contains(npc.GetID)) continue;
                npc.gameObject.SetActive(true);
                spawnedNpcs.Add(npc);
            }
        }

        public void KillNPC(string id)
        {
            HP_NPCSpawnManager.Instance.GetSessionNpcs.Remove(id);
            foreach (var npc in spawnedNpcs.Where(npc => npc.GetID == id))
            {
                npc.gameObject.SetActive(false);
                spawnedNpcs.Remove(npc);
                break;
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