using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PreFlyUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> PreFlyUIComponent;

    public static UnityAction StartPreFlyProcessEvent;
    public static UnityAction EndPreFlyProcessEvent;

    private void OnEnable()
    {
        StartPreFlyProcessEvent += StartPreFlyProcess;
        EndPreFlyProcessEvent += EndPreFlyProcess;
    }

    private void StartPreFlyProcess()
    {
        foreach (var component in PreFlyUIComponent)
        {
            component.SetActive(true);
        }
    }
    private void EndPreFlyProcess()
    {
        foreach (var component in PreFlyUIComponent)
        {
            component.SetActive(false);
        }
    }
    private void OnDisable()
    {
        StartPreFlyProcessEvent -= StartPreFlyProcess;

        EndPreFlyProcessEvent -= EndPreFlyProcess;
    }
}
