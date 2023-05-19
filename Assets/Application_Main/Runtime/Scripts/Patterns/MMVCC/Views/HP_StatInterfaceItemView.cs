namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using UnityEngine;
    using UnityEngine.UI;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Views/HP Stat Interface Item View")]
    public class HP_StatInterfaceItemView : MonoBehaviour
    {
        public enum ItemState
        {
            Full,
            Empty
        }

        #region Variables

        #region Protected Variables

        [SerializeField] protected Image statIMG;
        [SerializeField] protected Sprite fullSprite, emptySprite;
        protected ItemState itemState;
        
        #endregion

        #region Public Variables

        public ItemState GetItemState => itemState;

        #endregion
        
        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Enables the item.
        /// </summary>
        public void Enable()
        {
            itemState = ItemState.Full;
            statIMG.sprite = fullSprite;
        }
        
        /// <summary>
        /// Disables the item.
        /// </summary>
        public void Disable()
        {
            itemState = ItemState.Empty;
            statIMG.sprite = emptySprite;
        }

        #endregion

        #endregion
    }
}