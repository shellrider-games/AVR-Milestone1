using System;
using UnityEngine;

public class ToggleComponent : MonoBehaviour
{
    [SerializeField] private Behaviour component;

    private void Start()
    {
        Debug.Assert(component != null, "Make sure that component is not null!");
    }

    public void Toggle()
    {
        component.enabled = !component.enabled;
    }
}
