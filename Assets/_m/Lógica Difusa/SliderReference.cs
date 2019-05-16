using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderReference : MonoBehaviour
{
    public Slider input1, input2, agua, jabon, tiempo;

    public float maxWeight, maxDirt, maxWater, maxTime, maxSoap;

    private void Start()
    {
        input1.maxValue = maxWeight;
        input2.maxValue = maxDirt;
        agua.maxValue = maxWater;
        tiempo.maxValue = maxTime;
        jabon.maxValue = maxSoap;
    }

    public void UpdateOutput(float _time, float _soap, float _water)
    {
        agua.value = _water;
        tiempo.value = _time;
        jabon.value = _soap;
    }
}
