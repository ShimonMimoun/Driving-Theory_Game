using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedSign : MonoBehaviour
{
    [SerializeField] private float AllowSpeed;
    [SerializeField] private GameObject editSpeed;
    void Start()
    {
        if (editSpeed == null) editSpeed = GameObject.Find("EditSpeed");
    }
    private void OnTriggerEnter(Collider other)
    {
        editSpeed.GetComponent<editSpeed>()._SpeedLimit = AllowSpeed;
    }
}
