using UnityEngine;
using UnityEngine.UI;

public class StartFlyButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private PowerSlider _slider;
    private void Start()
    {
        _button.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        // Start Fly Point
        _slider.ReturnSliderValue();

        PreFlyUI.EndPreFlyProcessEvent.Invoke();

        FlyUI.StartFlyProcessEvent.Invoke();
    }
}
