using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoCar : MonoBehaviour
{
    public GameObject StartPos;
    public GameObject endPos;
    [SerializeField] float speed;
    [SerializeField] float alpha = 0.01f;
    [SerializeField] bool drive;

    public bool Drive { get => drive; set => drive = value; }

    //[SerializeField] private GameObject 

    void Update()
    {
        if (drive)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, endPos.transform.position, step);
            if (Vector3.Distance(transform.position, endPos.transform.position) < alpha)
            {
                transform.position = StartPos.transform.position;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("traffic light"))
            if (!other.gameObject.GetComponent<LightModeScripts>().blink)
                drive = false;
        if (other.gameObject.CompareTag("Player")) Debug.Log("player trigger");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) Debug.Log("player collision");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("traffic light"))
            if (other.gameObject.GetComponent<LightModeScripts>().blink)
                drive = true;
    }
}
