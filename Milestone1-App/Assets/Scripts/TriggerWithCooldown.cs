using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TriggerWithCooldown : MonoBehaviour
{
    [SerializeField] private float cooldownTime;
    [SerializeField] private string compareTag;
    [SerializeField] private UnityEvent OnTriggered;
    
    private bool isOnCooldown;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(compareTag) && !isOnCooldown)
        {
            OnTriggered.Invoke();
            StartCoroutine(CoolDown());
        }
    }

    private IEnumerator CoolDown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }
}
