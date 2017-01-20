//zeed

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class motioncapture : MonoBehaviour
{
    private int cooldown = 0;
    public GameObject uiElement;

    private float accelerometerUpdateInterval = 1.0f / 60.0f;
    // The greater the value of LowPassKernelWidthInSeconds, the slower the filtered value will converge towards current input sample (and vice versa).
    private float lowPassKernelWidthInSeconds = 1.0f;
    // This next parameter is initialized to 2.0 per Apple's recommendation, or at least according to Brady! ;)
    public float shakeDetectionThresholdMin = 4.0f;

    public float shakeDetectionThresholdMax = 10.0f;

    private float lowPassFilterFactor;
    private Vector3 lowPassValue = Vector3.zero;
    private Vector3 acceleration;
    private Vector3 deltaAcceleration;
    // Use this for initialization
    void Start()
    {
        lowPassFilterFactor = (float)accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThresholdMin *= shakeDetectionThresholdMin;
        shakeDetectionThresholdMax *= shakeDetectionThresholdMax;
        lowPassValue = Input.acceleration;
        //adadsadsa
        cooldown = 100;

    }

    // Update is called once per frame
    void Update()
    {

        acceleration = Input.acceleration;
        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
        deltaAcceleration = acceleration - lowPassValue;

        if (cooldown < 1)
        {
            if (cooldown >=100 && deltaAcceleration.sqrMagnitude >= shakeDetectionThresholdMax)
            {
                Skill1();
                cooldown -= 100;
            }
            else if (cooldown >= 60 && deltaAcceleration.sqrMagnitude >= shakeDetectionThresholdMin)
            {
                Skill2();
                cooldown -= 60;
            }
        }

        refillCooldown();
    }

    private void Skill1()
    {

    }
    private void Skill2()
    {

    }

    private void refillCooldown()
    {
        cooldown += 1;
        //Do something with the UI
        //uiElement.something()
    }
    
}