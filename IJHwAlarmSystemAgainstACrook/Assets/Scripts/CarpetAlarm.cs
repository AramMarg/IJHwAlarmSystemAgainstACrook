using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CarpetAlarm : MonoBehaviour
{
    public event Action CarpetTouched;
    public event Action CrookWent;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject .TryGetComponent<Crook>(out _))
        {
            CarpetTouched?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Crook>(out _))
        {
            CrookWent?.Invoke();
        }
    }
}
