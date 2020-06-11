using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightModeScripts : MonoBehaviour
{
    public Light LightGreen;
    public Light LightRed;
    public Light LightYellow;
    public string greenMode = "green";
    public string redMode = "red";
    public string yellowMode = "yellow";
    public string yellowRedMode = "yellow and red";

    void Start()
    {
        LightGreen.GetComponent<Light>().color = Color.green;
        LightRed.GetComponent<Light>().color = Color.red;
        LightYellow.GetComponent<Light>().color = Color.yellow;
    }
    private void Update()
    {
        LightGreen.GetComponent<Light>().color = Color.green;
        LightRed.GetComponent<Light>().color = Color.red;
        LightYellow.GetComponent<Light>().color = Color.yellow;
    }

    public void setLights(string mode)
    {
        if (mode.Equals(redMode))
        {
            LightRed.enabled = true;
            LightYellow.enabled = false;
            LightGreen.enabled = false;
        }
        else if (mode.Equals(yellowMode))
        {
            LightRed.enabled = false;
            LightYellow.enabled = true;
            LightGreen.enabled = false;
        }
        else if (mode.Equals(greenMode))
        {
            LightRed.enabled = false;
            LightYellow.enabled = false;
            LightGreen.enabled = true;
        }
        else if (mode.Equals(yellowRedMode))
        {
            LightRed.enabled = true;
            LightYellow.enabled = true;
            LightGreen.enabled = false;
        }
    }

    public void Blink()
    {
        LightGreen.enabled = (!LightGreen.enabled);
    }
}
