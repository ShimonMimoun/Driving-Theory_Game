using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class editSpeed : MonoBehaviour
{
    public GameObject SpeedLimit;
    [SerializeField] private float speedLimit = 50;

    public float _SpeedLimit { get => speedLimit; set => speedLimit = value; }

    void Start()
    {
        SpeedLimit = GameObject.Find("SpeedLimit");
        SpeedLimit.GetComponent<speedLimitScript>().CurrentLimit = speedLimit;
    }

    private void Update()
    {
        SpeedLimit.GetComponent<speedLimitScript>().CurrentLimit = speedLimit;
    }

}
