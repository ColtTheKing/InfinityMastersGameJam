using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;




public class LightController : MonoBehaviour
{
    public float timer;
    private Light2D light;
    public double lightLevel; //current light level [0-100]\
    public double SECONDS_FOR_LIGHT_TICK; //seconds it takes for light level to decrease by 1

    public double LIGHT_BRIGHT_THRESHOLD; //minimum light level to be considered "bright", "decent",
    public double LIGHT_DECENT_THRESHOLD; //"dim", and "dark" respectively. pitch is 0
    public double LIGHT_DIM_THRESHOLD;
    public double LIGHT_DARK_THRESHOLD;

    public double LIGHT_BRIGHT_INTENSITY; //light level constants - 
    public double LIGHT_BRIGHT_RADIUS;
    public double LIGHT_DECENT_INTENSITY;
    public double LIGHT_DECENT_RADIUS;
    public double LIGHT_DIM_INTENSITY;
    public double LIGHT_DIM_RADIUS;
    public double LIGHT_DARK_INTENSITY;
    public double LIGHT_DARK_RADIUS;



    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
        lightLevel = 100;
        SECONDS_FOR_LIGHT_TICK = 1;

        //light setup
        timer = 0;
        LIGHT_BRIGHT_THRESHOLD = 75; //minimum light level to be considered "bright", "decent",
        LIGHT_DECENT_THRESHOLD = 50; //"dim", and "dark" respectively. pitch is 0
        LIGHT_DIM_THRESHOLD = 25;
        LIGHT_DARK_THRESHOLD = 1;

        LIGHT_BRIGHT_INTENSITY = 1; //light level constants - 
        LIGHT_BRIGHT_RADIUS = 1.4;

        LIGHT_DECENT_INTENSITY = 0.8;
        LIGHT_DECENT_RADIUS = 1;

        LIGHT_DIM_INTENSITY = 0.55;
        LIGHT_DIM_RADIUS = 0.7;

        LIGHT_DARK_INTENSITY = 0.4;
        LIGHT_DARK_RADIUS = 0.25;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + 0.01f;
        if (timer >= SECONDS_FOR_LIGHT_TICK)
        {
            if (lightLevel>0) lightLevel--;
            UpdateLightLevel();
            //Debug.Log("Light level ticked!");
            timer = 0;
        }
    }

    void UpdateLightLevel()
    {
        if (lightLevel >= LIGHT_BRIGHT_THRESHOLD)
        {
            //Debug.Log("Light is bright - >=75");
            light.intensity = (float) LIGHT_BRIGHT_INTENSITY;
            light.pointLightInnerRadius = (float) LIGHT_BRIGHT_RADIUS;

        }
        else if (lightLevel >= LIGHT_DECENT_THRESHOLD)
        {
            //Debug.Log("Light is DECENT - >=50");
            light.intensity = (float) LIGHT_DECENT_INTENSITY;
            light.pointLightInnerRadius = (float) LIGHT_DECENT_RADIUS;

        }
        else if (lightLevel >= LIGHT_DIM_THRESHOLD)
        {
            //Debug.Log("Light is DIM - >=25");
            light.intensity = (float) LIGHT_DIM_INTENSITY;
            light.pointLightInnerRadius = (float) LIGHT_DIM_RADIUS;

        }
        else if (lightLevel >= LIGHT_DARK_THRESHOLD)
        {
            //Debug.Log("Light is DARK - >=1");
            light.intensity = (float) LIGHT_DARK_INTENSITY;
            light.pointLightInnerRadius = (float) LIGHT_DARK_RADIUS;

        }
        else
        {
            //Debug.Log("Light is PITCH black! - 0");
            light.intensity = 0;
            light.pointLightInnerRadius = 0;
        }

    }


    public void AddToLightLevel(double l) 
    {
        if ((l + lightLevel) >= 100)
        {
            lightLevel = 100;
        } else
        {
            lightLevel = lightLevel + l;
        }

    }
}
