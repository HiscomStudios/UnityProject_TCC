namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using System.Linq;
    using UnityEngine;
    using Managers;
    using Connectors;

    public class HP_NPCLifeController : MonoBehaviour
    {
        #region Methods

        #region Public Methods

        public void OnLoadSuccess()
        {
            foreach (var npc in FindObjectsOfType<HP_NPCConnector>())
            {
                npc.gameObject.SetActive(false);
                if (!HP_NPCSpawnManager.Instance.GetAvailableNpcs.Any(spawnedNPC => spawnedNPC.GetID == npc.GetID)) continue;
                npc.gameObject.SetActive(true);
            }
        }
        public void OnLoadFail()
        {
            foreach (var npc in FindObjectsOfType<HP_NPCConnector>())
            {
                npc.gameObject.SetActive(true);
            }
        }

        #endregion

        #endregion
    }
}