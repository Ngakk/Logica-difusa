using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bayes : MonoBehaviour
{
    public TextReference textReference;
    public float A1, A2, B1, B2;
    [Header("Don't set variables below")]
    [SerializeField]
    private float A;
    [SerializeField]
    private float B;
    [SerializeField]
    float R1;
    [SerializeField]
    float R2;
    [SerializeField]
    float R3;
    [SerializeField]
    float R4;
    // Start is called before the first frame update
    void Start()
    {
        A = B = 0.5f;
        SetRs();
        UpdateTextReference();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            float temp = Random.Range(0.0f, 50.0f);
            DoBayes(temp);
        }
    }

    private void DoBayes(float _m)
    {
        if (_m >= 15)
        {
            print("More than 15m");
            A = R1 / (R1 + R3);
            B = 1.0f - A;
            R2 = 1.0f - R1;
            R4 = 1.0f - R3;
        }
        else
        {
            print("Less than 15m");
            A = R2 / (R2 + R4);
            B = 1.0f - A;
            R1 = 1.0f - R2;
            R3 = 1.0f - R4;
        }
        SetRs();
        UpdateTextReference();
    }

    private void SetRs()
    {
        R1 = A * A1;
        R2 = A * A2;
        R3 = B * B1;
        R4 = B * B2;
    }

    private void UpdateTextReference() { textReference.UpdateText(A, B, A1, A2, B1, B2, R1, R2, R3, R4); }
}
