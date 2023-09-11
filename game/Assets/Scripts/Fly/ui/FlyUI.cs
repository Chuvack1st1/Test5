using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlyUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> FlyUIComponent;

    [SerializeField] private GameObject EndMassege;

    public static UnityAction StartFlyProcessEvent;
    public static UnityAction EndFlyProcessEvent;

    private void OnEnable()
    {
        StartFlyProcessEvent += StartFlyProcess;
        EndFlyProcessEvent += EndFlyProcess;

        PlayerManager.PlayerDieAction += OnPlayerDie;
    }

    private void StartFlyProcess()
    {
        foreach (var component in FlyUIComponent)
        {
            component.SetActive(true);
        }
        EndMassege.SetActive(false);
    }
    private void EndFlyProcess()
    {
        foreach (var component in FlyUIComponent)
        {
            component.SetActive(false);
        }
        EndMassege.SetActive(true);
    }

    private void OnPlayerDie()
    {
        EndFlyProcessEvent.Invoke();
    }
    private void OnDisable()
    {
        StartFlyProcessEvent -= StartFlyProcess;
        EndFlyProcessEvent -= EndFlyProcess;

        PlayerManager.PlayerDieAction -= OnPlayerDie;
    }
}
