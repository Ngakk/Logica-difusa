using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuzzy : MonoBehaviour
{
    public SliderReference sliderReference;

    public float veryLight;
    public float light;
    public float normal;
    public float heavy;
    public float veryHeavy;
    public float clean;
    public float kindaDirty;
    public float dirty;
    public float nasty;
    public float littleTime;
    public float someTime;
    public float fullTime;
    public float littleWater;
    public float normalWater;
    public float muchWater;
    public float littleSoap;
    public float someSoap;
    public float muchSoap;

    float soapResult, timeResult, waterResult;

    private void Update()
    {
        Fuzzyfication();
    }

    private void Fuzzyfication()
    {
        float weight = sliderReference.input1.value; //Get the values
        float dirtyness = sliderReference.input2.value;

        weight /= sliderReference.maxWeight;    //Normalization
        dirtyness /= sliderReference.maxDirt;

        //Fuzzyfication
        veryLight = DLMF.InvGrade(weight, 0.0f, 0.35f);
        light = DLMF.Triangle(weight, 0.2f, 0.4f, 0.6f);
        normal = DLMF.Trapezoid(weight, 0.35f, 0.4f, 0.6f, 0.75f);
        heavy = DLMF.Triangle(weight, 0.55f, 0.7f, 0.85f);
        veryHeavy = DLMF.Grade(weight, 0.75f, 1.0f);

        clean = DLMF.InvBool(dirtyness, 0.05f);
        kindaDirty = DLMF.Triangle(dirtyness, 0.2f, 0.3f, 0.4f);
        dirty = DLMF.Triangle(dirtyness, 0.35f, 0.5f, 0.8f);
        nasty = DLMF.Grade(dirtyness, 0.65f, 1.0f);


        littleTime = DLMF.OpOR(clean, veryLight);
        someTime = DLMF.OpAND(DLMF.OpOR(DLMF.OpOR(light, normal), heavy), DLMF.OpNOT(clean));
        fullTime = DLMF.OpOR(DLMF.OpOR(DLMF.OpOR(heavy, veryHeavy), nasty), dirty);

        littleWater = DLMF.OpOR(veryLight, light);
        normalWater = DLMF.OpOR(DLMF.OpOR(light, normal), heavy);
        muchWater = DLMF.OpOR(heavy, veryHeavy);

        littleSoap = DLMF.OpOR(DLMF.OpOR(clean, veryLight), light);
        someSoap = DLMF.OpAND(normal, DLMF.OpOR(dirty, kindaDirty)); //Arreglar esto
        muchSoap = DLMF.OpOR(DLMF.OpOR(DLMF.OpAND(veryHeavy, dirty), DLMF.OpAND(heavy, nasty)), nasty);

        //Deffuzzyfication



        timeResult = Mathf.Lerp(0, sliderReference.maxTime, (1 - littleTime + someTime + fullTime) / 2.0f);

        waterResult = Mathf.Lerp(0, sliderReference.maxWater, (1 - littleWater + normalWater + muchWater) /2.0f);

        soapResult = Mathf.Lerp(0, sliderReference.maxSoap, (1 - littleSoap + someSoap + muchSoap) / 2.0f);

        sliderReference.UpdateOutput(timeResult, soapResult, waterResult);
    }
    
}
