using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float RotateSpeed = 20;
    [SerializeField] private Vector3 HowToRotate = new Vector3(0, 1, 0);
    
    void Update()
    {
        transform.Rotate(HowToRotate * Time.deltaTime * RotateSpeed);
    }
}
