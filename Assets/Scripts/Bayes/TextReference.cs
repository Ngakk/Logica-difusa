using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextReference : MonoBehaviour
{
    public Text A, B, A1, A2, B1, B2, R1, R2, R3, R4;

    public void UpdateText(float _a, float _b, float _a1, float _a2, float _b1, float _b2, float _r1, float _r2, float _r3, float _r4)
    {
        A.text = _a.ToString();
        B.text = _b.ToString();
        A1.text = _a1.ToString();
        A2.text = _a2.ToString();
        B1.text = _b1.ToString();
        B2.text = _b2.ToString();
        R1.text = _r1.ToString();
        R2.text = _r2.ToString();
        R3.text = _r3.ToString();
        R4.text = _r4.ToString();
    }
}
