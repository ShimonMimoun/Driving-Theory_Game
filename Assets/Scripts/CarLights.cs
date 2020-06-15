using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLights : MonoBehaviour
{

    [Header("Lights")]
    [SerializeField] Light leftLight;
    [SerializeField] Light rightLight;
    [SerializeField] bool lightsOn = false;
    [SerializeField] KeyCode KeyToPress = KeyCode.L;

    void Update()
    {
        if (Input.GetKeyDown(KeyToPress))
        {
            lightsOn = !lightsOn;
            leftLight.enabled = rightLight.enabled = lightsOn;
            Debug.Log(lightsOn);
        }
    }
}
