using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Debug.Log("I am here");
    }
}
