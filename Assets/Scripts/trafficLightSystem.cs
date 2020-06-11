using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficLightSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> TrafficLights = new List<GameObject>();
    [SerializeField] private float greenLightDuration = 4;
    [Tooltip("green blinking light before it changes to yellow.")] [SerializeField] private float BlinkingDuration = 2;
    [SerializeField] private float yellowLightDuration = 2;
    private int currentTL = 0;
    private bool StartBlink = false;
    void Start()
    {
        StartCoroutine(ChangeLight());
    }

    public IEnumerator ChangeLight()
    {
        for (int i = 0; i < TrafficLights.Count; i++)
        {
            if (i == currentTL) TrafficLights[currentTL].GetComponent<LightModeScripts>().setLights(TrafficLights[currentTL].GetComponent<LightModeScripts>().yellowRedMode); 
            else TrafficLights[i].GetComponent<LightModeScripts>().setLights(TrafficLights[currentTL].GetComponent<LightModeScripts>().redMode);
        }
        yield return new WaitForSeconds(yellowLightDuration);
        TrafficLights[currentTL].GetComponent<LightModeScripts>().setLights(TrafficLights[currentTL].GetComponent<LightModeScripts>().greenMode);
        yield return new WaitForSeconds(greenLightDuration);
        StartBlink = true;
        StartCoroutine(Blinking());
        yield return new WaitForSeconds(BlinkingDuration);
        StartBlink = false;
        TrafficLights[currentTL].GetComponent<LightModeScripts>().setLights(TrafficLights[currentTL].GetComponent<LightModeScripts>().yellowMode);
        yield return new WaitForSeconds(yellowLightDuration);
        currentTL++;
        currentTL %= TrafficLights.Count;
        if(TrafficLights.Count == 1)
        {
            TrafficLights[0].GetComponent<LightModeScripts>().setLights(TrafficLights[currentTL].GetComponent<LightModeScripts>().redMode);
            yield return new WaitForSeconds(greenLightDuration);
        }
        StartCoroutine(ChangeLight());
    }
    public IEnumerator Blinking()
    {
        if (StartBlink)
        {
            TrafficLights[currentTL].GetComponent<LightModeScripts>().Blink();
            yield return new WaitForSeconds(0.333f);
            StartCoroutine(Blinking());
        }
    }
}