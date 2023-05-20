using System;
using System.Collections;
using System.Collections.Generic;
using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views.Internal;
using HiscomEngine.Runtime.Scripts.Structures.Extensions;
using UnityEngine;

public class HP_BossMoveDashView : MonoBehaviour
{
    #region Variables

    #region Protected Variables

    [SerializeField] protected float cooldownBetweenDashes, dashForce, mainLightMaxIntensity, bossLightMaxForce;
    [SerializeField] private PlayerView player;
    [SerializeField] protected Rigidbody rigidbody;
    [SerializeField] protected Light mainLight, bossLight;

    #endregion

    #endregion
    
    #region Methods

    #region Protected Methods

    protected void OnEnable()
    {
        var myVar = 0f;
        LeanTween.value(1, 0, 1).setOnUpdate((value) =>
        {
            myVar = value;
            //mainLight.intensity = value;
        }).setOnComplete(Attack);
    }
    protected void OnDisable()
    {
        var myVar = 0f;
        LeanTween.value(0, 1, 1).setOnUpdate((value) =>
        {
            myVar = value;
            //mainLight.intensity = value;
        }).setOnComplete(() =>
        {
            LeanTween.cancelAll();
            StopAllCoroutines();
        });
    }

    protected void Attack()
    {
        var myVar = 0f;

        LeanTween.value(0, 1, cooldownBetweenDashes).setOnComplete(() =>
        {
            //bossLight.intensity = 0;

            LeanTween.value(0, bossLightMaxForce, .5f).setOnUpdate((value) =>
            {
                myVar = value;
                //bossLight.intensity = value;
            }).setOnComplete(() =>
            {
                //bossLight.intensity = 0;
                var direction = player.transform.position - rigidbody.transform.position;
                direction.Normalize();
                rigidbody.AddForce(direction * dashForce, ForceMode.Impulse);
                StartCoroutine(RestartAttack());
            });
        });
    }

    public IEnumerator RestartAttack()
    {
        do
        {
            yield return new WaitForSeconds(0.01f);
        }
        while (rigidbody.velocity.magnitude > 0.1f);
        
        var direction = player.transform.position - rigidbody.transform.position;
        direction.Normalize();
        rigidbody.AddForce(-direction * dashForce / 2, ForceMode.Impulse);
        
        do
        {
            yield return new WaitForSeconds(0.01f);
        }
        while (rigidbody.velocity.magnitude > 0.1f);

        rigidbody.Halt();
        Attack();
    }

    #endregion
    
    #endregion
}