namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using System.Collections;
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Controllers;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views.Internal;

    public class HP_RoutineControllerWithClock : RoutineController
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected GameObject clockArrowGameObject;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected override IEnumerator AdvanceMinutes(LightningDataView lightningDataView)
        {
            var rotationDelta = clockArrowGameObject.transform.rotation.eulerAngles.z + minuteDuration;
            LeanTween.rotateZ(clockArrowGameObject, rotationDelta, minuteDuration).setEaseLinear();
            return base.AdvanceMinutes(lightningDataView);
        }

        #endregion

        #endregion
    }
}