using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class menu : MonoBehaviour
{
    public float SliderValue;
    public TextMeshProUGUI SliderValueText;
    public Slider slider;

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void SliderValueChanged(float _value)
    {
        SliderValue = slider.value;

        //SliderValueText.text = _value.ToString();
        SliderValueText.text = SliderValue.ToString();
    }
}