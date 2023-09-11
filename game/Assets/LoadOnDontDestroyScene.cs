using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnDontDestroyScene : MonoBehaviour
{
    [SerializeField] private List<GameObject> list = new List<GameObject>();

    private void Awake()
    {
        foreach (GameObject go in list)
        {
            DontDestroyOnLoad(go);
        }
    }
}
