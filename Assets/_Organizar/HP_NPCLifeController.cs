using System.Linq;
using UnityEngine.SceneManagement;

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
            foreach (var availableNPC in HP_NPCSpawnManager.Instance.sessionNPCs)
            {
                var npc = Instantiate(availableNPC, availableNPC.GetSpawnPosition, Quaternion.Euler(availableNPC.GetSpawnRotation));
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
            Invoke(nameof(Teste), 5);
        }

        public void Teste()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}