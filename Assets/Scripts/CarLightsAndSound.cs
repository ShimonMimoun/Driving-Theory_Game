using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLightsAndSound : MonoBehaviour
{

    [Header("Lights")]
    [SerializeField] Light leftLight;
    [SerializeField] Light rightLight;
    [SerializeField] bool lightsOn = false;
    [SerializeField] KeyCode KeyToPress = KeyCode.L;
    [Header("Sound")]
    [SerializeField] bool SoundOn = true;
    [SerializeField] KeyCode _keyToPress = KeyCode.M;

    void Update()
    {
        if (Input.GetKeyDown(KeyToPress))
        {
            lightsOn = !lightsOn;
            leftLight.enabled = rightLight.enabled = lightsOn;
            Debug.Log(lightsOn);
        }
        if (Input.GetKeyDown(_keyToPress))
        {
            SoundOn = !SoundOn;
            gameObject.GetComponent<EngineSoundManager>().enabled = SoundOn;
            Debug.Log(SoundOn);
        }
    }
}
