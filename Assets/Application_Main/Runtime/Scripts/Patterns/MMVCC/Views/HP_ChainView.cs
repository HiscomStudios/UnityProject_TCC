using UnityEngine;

namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    public class HP_ChainView : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected Transform chainParent;
        [SerializeField] protected SpriteRenderer chainSprite;

        #endregion

        #region Public Variables

        public Transform GetChainParent => chainParent;
        public SpriteRenderer GetChainSprite => chainSprite;

        #endregion

        #endregion
    }
}