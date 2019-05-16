using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLMF : MonoBehaviour //Difuse Logic Membership Functions
{
    public static float Bool(float _x, float _x0)
    {
        if (_x <= _x0)
            return 0.0f;
        else
            return 1.0f;
    }

    public static float InvBool(float _x, float _x0)
    {
        if (_x > _x0)
            return 0.0f;
        else
            return 1.0f;
    }

    public static float Grade(float _x, float _x0, float _x1)
    {
        if (_x <= _x0)
            return 0.0f;
        else if (_x > _x0 && _x <= _x1)
            return (_x / (_x1 - _x0)) - (_x0 / (_x1 - _x0));
        else
            return 1.0f;
    }

    public static float InvGrade(float _x, float _x0, float _x1)
    {
        if (_x < _x0)
            return 1.0f;
        else if (_x >= _x0 && _x < _x1)
            return -(_x / (_x1 - _x0)) + (_x1 / (_x1 - _x0));
        else
            return 0.0f;
    }

    public static float Triangle(float _x, float _x0, float _x1, float _x2)
    {
        if (_x <= _x0)
            return 0;
        else if (_x > _x0 && _x <= _x1)
            return (_x / (_x1 - _x0)) - (_x0 / (_x1 - _x0));
        else if (_x > _x1 && _x <= _x2)
            return -(_x / (_x2 - _x1)) + (_x2 / (_x2 - _x1));
        else
            return 0.0f;
    }

    public static float InvTriangle(float _x, float _x0, float _x1, float _x2)
    {
        if (_x < _x0)
            return 1.0f;
        else if (_x >= _x0 && _x < _x1)
            return -(_x / (_x1 - _x0)) + (_x1 / (_x1 - _x0));
        else if (_x >= _x1 && _x < _x2)
            return (_x / (_x2 - _x1)) - (_x1 / (_x2 - _x1));
        else
            return 1.0f;
    }

    public static float Trapezoid(float _x, float _x0, float _x1, float _x2, float _x3)
    {
        if (_x <= _x0)
            return 0.0f;
        else if (_x > _x0 && _x <= _x1)
            return (_x / (_x1 - _x0) - _x0 / (_x1 - _x0));
        else if (_x > _x1 && _x <= _x2)
            return 1.0f;
        else if (_x > _x2 && _x <= _x3)
            return -(_x / (_x3 - _x2)) + (_x3 / (_x3 - _x2));
        else
            return 0.0f;
    }

    public static float OpAND(float _a, float _b)
    {
        return Mathf.Min(_a, _b);
    }

    public static float OpOR(float _a, float _b)
    {
        return Mathf.Max(_a, _b);
    }

    public static float OpNOT(float _a)
    {
        return 1 - _a;
    }
}
