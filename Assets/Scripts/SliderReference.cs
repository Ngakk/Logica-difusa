using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderReference : MonoBehaviour
{
    public Slider input1, input2, output1, output2, output3;

    public float maxWeight, maxDirt, maxWater, maxTime, maxSoap;

    private void Start()
    {
        input1.maxValue = maxWeight;
        input2.maxValue = maxDirt;
        output1.maxValue = maxWater;
        output2.maxValue = maxTime;
        output3.maxValue = maxSoap;
    }
}
