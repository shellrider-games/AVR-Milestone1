using System;
using UnityEngine;
using UnityEngine.Events;

public class PreventMovingAboveStartPosition : MonoBehaviour
{
    [SerializeField] private float upLimit;
    [SerializeField] private float downLimit;
    [SerializeField] private UnityEvent onDownLimit;
    [SerializeField] private UnityEvent onUpLimit;
    
    
    private float startY;

    private void Start()
    {
        startY = transform.position.y;
    }
    
    void Update()
    {
        float differenceToStart = startY - transform.position.y;
        if (differenceToStart < -upLimit)
        {
            transform.position = new Vector3(transform.position.x, startY + upLimit, transform.position.z);
            onUpLimit.Invoke();
        }
        if (differenceToStart > downLimit)
        {
            transform.position = new Vector3(transform.position.x, startY - downLimit, transform.position.z);
            onDownLimit.Invoke();
        }
        
    }
}
