namespace HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    using Internal;
    using Input = Structures.Extensions.InputExtensions;
    
    public class HP_GenericRangedAttackView : RangedCombatView
    {
        #region Methods

        #region Protected Methods

        protected override void ShootWithMouse(BulletView instance)
        {
            Physics.Raycast(Input.GetMouseRayPosition(), out var hit);
            if (hit.collider == null) return;
            var bulletPosition = bulletSpawn.position;
            var hitPosition = hit.point;
            instance.Move((new Vector3(hitPosition.x, hitPosition.y + (bulletPosition.y - hitPosition.y), hitPosition.z - (bulletPosition.y - hitPosition.y + 2.5f)) - bulletPosition).normalized);
        }
        protected override void ShootWithoutMouse(BulletView instance)
        {
            
        }

        #endregion

        #endregion
    }
}