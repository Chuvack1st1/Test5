using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPreFlyButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    private void Start()
    {
        _button.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        SaveLoadDataService.SaveDataEvent.Invoke();
        MenuUIManeger.EndMenuProcessEvent.Invoke();
        
        FlyUI.StartFlyProcessEvent.Invoke();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }
}
