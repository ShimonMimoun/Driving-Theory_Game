using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour {

    public Transform target;
    [SerializeField] private Vector3 targetPosition;
    private void Start()
    {
        target = GameObject.Find("EditCar").transform.Find("DestPos").transform.Find("dest");
    }
    private void Update()
    {
        targetPosition = target.transform.position;
        transform.LookAt(2 * transform.position - target.position);
    }
}