using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuUIManeger : MonoBehaviour
{
    [SerializeField] private List<GameObject> MenuUIComponent;

    public static UnityAction StartMenuProcessEvent;
    public static UnityAction EndMenuProcessEvent;

    private void OnEnable()
    {
        StartMenuProcessEvent += StartPreFlyProcess;
        StartMenuProcessEvent.Invoke();
        EndMenuProcessEvent += EndPreFlyProcess;
    }

    private void StartPreFlyProcess()
    {
        foreach (var component in MenuUIComponent)
        {
            component.SetActive(true);
        }
    }
    private void EndPreFlyProcess()
    {
        foreach (var component in MenuUIComponent)
        {
            component.SetActive(false);
        }
    }
    private void OnDisable()
    {
        StartMenuProcessEvent -= StartPreFlyProcess;

        EndMenuProcessEvent -= EndPreFlyProcess;
    }
}
