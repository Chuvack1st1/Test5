using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMassage : MonoBehaviour
{
    
    private void OnEnable()
    {
        IsGameStoped.IsGameCountined = false;
    }
    private void OnDisable()
    {
        IsGameStoped.IsGameCountined = true;
    }
}
