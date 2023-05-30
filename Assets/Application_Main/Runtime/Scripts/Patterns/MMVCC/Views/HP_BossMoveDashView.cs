namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using System.Collections;
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views.Internal;
    using HiscomEngine.Runtime.Scripts.Structures.Extensions;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Models;
    using HiscomEngine.Runtime.Scripts.Structures.Enums;
    using Internal;

    public class HP_BossMoveDashView : HP_BossMovesetView
   {
       #region Variables

       #region Protected Variables

       [SerializeField] protected float cooldownBetweenDashes, dashForce, mainLightMaxIntensity, bossLightMaxForce;
       [SerializeField] private PlayerView playerReference;
       [SerializeField] protected Rigidbody rigidbody3d;
       [SerializeField] protected Light mainLight, bossLight;

       #endregion

       #endregion

       #region Methods

       #region Protected Methods

       protected virtual void OnEnable()
       {
           bool MainLightIsNull()
           {
               return Identifier.IdentifyIncident(() => mainLight == null, IncidentType.Warning, "", gameObject);
           }
           
           LeanTween.value(1, 0, 1).setOnUpdate((value) =>
           {
               if (!MainLightIsNull()) 
                   mainLight.intensity = value;
           }).setOnComplete(() =>
           {
               Attack();
           });
       }
       protected virtual void OnDisable()
       {
           bool MainLightIsNull()
           {
               return Identifier.IdentifyIncident(() => mainLight == null, IncidentType.Warning, "", gameObject);
           }
           
           LeanTween.value(0, 1, 1).setOnUpdate((value) =>
           {
               if (!MainLightIsNull()) 
                   mainLight.intensity = value;
           }).setOnComplete(() =>
           {
               LeanTween.cancelAll();
               StopAllCoroutines();
           });
       }

       protected virtual IEnumerator RestartAttack()
       {
           do
           {
               yield return new WaitForSeconds(0.01f);
           } while (rigidbody3d.velocity.magnitude > 5f);
           rigidbody3d.Halt();
           
           bool IsAnimatorNull()
           {
               return Identifier.IdentifyIncident(() => animator == null, IncidentType.Warning, "", gameObject);
           }
           bool IsDefaultAnimationClipNull()
           {
               return Identifier.IdentifyIncident(() => defaultAnimationClip == null, IncidentType.Warning, "", gameObject);
           }
           if (!IsAnimatorNull() && !IsDefaultAnimationClipNull())
               animator.Play(defaultAnimationClip.name);

           do
           {
               yield return new WaitForSeconds(0.01f);
           } while (rigidbody3d.velocity.magnitude > 0.1f);
           
           Attack();
       }
       protected override void Attack()
       {
           bool IsAnimatorNull()
           {
               return Identifier.IdentifyIncident(() => animator == null, IncidentType.Warning, "", gameObject);
           }
           bool BossLightIsNull()
           {
               return Identifier.IdentifyIncident(() => bossLight == null, IncidentType.Warning, "", gameObject);
           }

           LeanTween.value(0, 1, cooldownBetweenDashes).setOnComplete(() =>
           {
               if (!BossLightIsNull()) 
                   bossLight.intensity = 0;

               LeanTween.value(0, bossLightMaxForce, .5f).setOnUpdate((value) =>
               {
                   if (!BossLightIsNull()) 
                       bossLight.intensity = value;
                   
               }).setOnComplete(() =>
               {
                   if (!BossLightIsNull()) 
                       bossLight.intensity = 0;

                   bool IsMovementAnimationClipNull()
                   {
                       return Identifier.IdentifyIncident(() => movementAnimationClip == null, IncidentType.Warning, "", gameObject);
                   }
                   if (!IsAnimatorNull() && !IsMovementAnimationClipNull())
                       animator.Play(movementAnimationClip.name);
                   
                   var direction = playerReference.transform.position - rigidbody3d.transform.position;
                   direction.Normalize();

                   LeanTween.value(0, 1, 0.09f).setOnComplete(() =>
                   {
                       rigidbody3d.AddForce(direction * dashForce, ForceMode.Impulse);
                   });
                   StartCoroutine(RestartAttack());
               });
           });
       }

       #endregion

       #endregion
   }
}