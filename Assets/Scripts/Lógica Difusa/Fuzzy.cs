using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuzzy : MonoBehaviour
{
    public SliderReference sliderReference;

    private void Fuzzyfication()
    {
        float weight = sliderReference.input1.value; //Get the values
        float dirtyness = sliderReference.input2.value;

        weight /= sliderReference.maxWeight;    //Normalization
        dirtyness /= sliderReference.maxDirt;

        float veryLight = InvGrade(weight, 0.0f, 0.25f);
        float light = Triangle(weight, 0.2f, 0.4f, 0.5f);
        float normal = Trapezoid(weight, 0.35f, 0.4f, 0.55f, 0.7f);
        float heavy = Triangle(weight, 0.55f, 0.7f, 0.85f);
        float veryHeavy = Grade(weight, 0.8f, 1.0f);

        float clean = InvBool(weight, 0.05f);
        float dirty = Triangle(weight, 0.0f, 0.6f, 0.8f);
        float nasty = Grade(weight, 0.7f, 1.0f);

        //Si esta muy sucia le pongo mas jabon y mas tiempo
        //Si es mucha le pongo mas de todo xd


    }

    private void Deffuzyfication()
    {
        
    }

    //Curve functions
    private float Bool(float _x, float _x0)
    {
        if (_x <= _x0)
            return 0.0f;
        else 
            return 1.0f;
    }

    private float InvBool(float _x, float _x0)
    {
        if (_x > _x0)
            return 0.0f;
        else
            return 1.0f;
    }

    private float Grade(float _x, float _x0, float _x1)
    {
        if (_x <= _x0)
            return 0.0f;
        else if (_x > _x0 && _x <= _x1)
            return (_x / (_x1 - _x0)) - (_x0 / (_x1 - _x0));
        else
            return 1.0f;
    }

    private float InvGrade(float _x, float _x0, float _x1)
    {
        if (_x < _x0)
            return 1.0f;
        else if (_x >= _x0 && _x < _x1)
            return -(_x / (_x1 - _x0)) + (_x1 / (_x1 - _x0));
        else
            return 0.0f;
    }

    private float Triangle(float _x, float _x0, float _x1, float _x2)
    {
        if (_x <= _x0)
            return 0;
        else if (_x > _x0 && _x <= _x1)
            return (_x / (_x1 - _x0)) - (_x0 / (_x1 - _x0));
        else if (_x > _x1 && _x <= _x2)
            return -(_x / (_x2 - _x1)) + (_x2 / (_x2 - _x1));
        else
            return 1.0f;
    }

    private float InvTriangle(float _x, float _x0, float _x1, float _x2)
    {
        if (_x < _x0)
            return 1.0f;
        else if (_x >= _x0 && _x < _x1)
            return -(_x / (_x1 - _x0)) + (_x1 / (_x1 - _x0));
        else if (_x >= _x1 && _x < _x2)
            return (_x / (_x2 - _x1)) - (_x1 / (_x2 - _x1));
        else
            return 0.0f;
    }

    private float Trapezoid(float _x, float _x0, float _x1, float _x2, float _x3)
    {
        if (_x <= _x0)
            return 0.0f;
        else if (_x > _x0 && _x <= _x1)
            return (_x / (_x1 - _x0) - _x0 / (_x1 - _x0));
        else if (_x > _x1 && _x1 <= _x2)
            return 1.0f;
        else if (_x > _x2 && _x <= _x3)
            return -(_x / (_x3 - _x2)) + (_x3 / (_x3 - _x2));
        else
            return 0.0f;
    }
}
