using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPart2 : MonoBehaviour
{
    public GameObject Cars;
    public void MoveCars()
    {
        Cars.GetComponent<autoCar>().Drive = true;
    }
}
