using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PowerSlider : MonoBehaviour
{

    private Slider _slider;

    private bool IsSliderIncreast = true;

    private Coroutine m_Coroutine;

    private float _addValue = 0.015f;

    private float _multiplayerAdd = 2f;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = 0.5f;

        m_Coroutine = StartCoroutine(ChooseSliderValue());
    }
    private IEnumerator ChooseSliderValue()
    {
        while (true)
        {
            if (IsSliderIncreast)
                _slider.value += _addValue * (_slider.value * _multiplayerAdd + 1);
            else
                _slider.value -= _addValue * (_slider.value * _multiplayerAdd + 1);

            if (_slider.value == 0)
                IsSliderIncreast = true;

            if (_slider.value == 1)
                IsSliderIncreast = false;
            yield return new WaitForSeconds(0.01f);
        }
    }
    public float ReturnSliderValue()
    {
        StopCoroutine(m_Coroutine);
        return _slider.value;
    }
}
