using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EntryPoint : MonoBehaviour
{
    public static UnityAction LoadEvent;
    public static UnityAction InitEvent;

    private IEnumerator Start()
    {
        LoadEvent.Invoke();
        yield return new WaitForEndOfFrame();
        InitEvent.Invoke();
    }
}
