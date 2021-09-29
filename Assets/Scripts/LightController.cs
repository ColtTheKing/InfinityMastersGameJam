using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;




public class LightController : MonoBehaviour
{
    public double LIGHT_LEVEL_START = 100;
    public double SECONDS_FOR_LIGHT_TICK = 1; //seconds it takes for light level to decrease by 1

    public double LIGHT_BRIGHT_THRESHOLD = 75; //minimum light level to be considered "bright", "decent",
    public double LIGHT_DECENT_THRESHOLD = 50; //"dim", and "dark" respectively. pitch is 0
    public double LIGHT_DIM_THRESHOLD = 25;
    public double LIGHT_DARK_THRESHOLD = 1;

    public double LIGHT_BRIGHT_INTENSITY = 1; //light level constants - 
    public double LIGHT_BRIGHT_RADIUS = 1.4;
    public double LIGHT_DECENT_INTENSITY = 0.8;
    public double LIGHT_DECENT_RADIUS = 1;
    public double LIGHT_DIM_INTENSITY = 0.55;
    public double LIGHT_DIM_RADIUS = 0.7;
    public double LIGHT_DARK_INTENSITY = 0.4;
    public double LIGHT_DARK_RADIUS = 0.25;

    private Light2D myLight;
    private float timer;
    private double lightLevel; //current light level [0-100]

    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light2D>();
        timer = 0;
        lightLevel = LIGHT_LEVEL_START;
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
            myLight.intensity = (float) LIGHT_BRIGHT_INTENSITY;
            myLight.pointLightInnerRadius = (float) LIGHT_BRIGHT_RADIUS;

        }
        else if (lightLevel >= LIGHT_DECENT_THRESHOLD)
        {
            //Debug.Log("Light is DECENT - >=50");
            myLight.intensity = (float) LIGHT_DECENT_INTENSITY;
            myLight.pointLightInnerRadius = (float) LIGHT_DECENT_RADIUS;

        }
        else if (lightLevel >= LIGHT_DIM_THRESHOLD)
        {
            //Debug.Log("Light is DIM - >=25");
            myLight.intensity = (float) LIGHT_DIM_INTENSITY;
            myLight.pointLightInnerRadius = (float) LIGHT_DIM_RADIUS;

        }
        else if (lightLevel >= LIGHT_DARK_THRESHOLD)
        {
            //Debug.Log("Light is DARK - >=1");
            myLight.intensity = (float) LIGHT_DARK_INTENSITY;
            myLight.pointLightInnerRadius = (float) LIGHT_DARK_RADIUS;

        }
        else
        {
            //Debug.Log("Light is PITCH black! - 0");
            myLight.intensity = 0;
            myLight.pointLightInnerRadius = 0;
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
