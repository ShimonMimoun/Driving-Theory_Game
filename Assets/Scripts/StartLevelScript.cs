using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartLevelScript : MonoBehaviour
{
    [SerializeField] GameObject car;
    [SerializeField] private GameObject panel;
    [SerializeField] private string LevelUpMsg;
    void Start()
    {
        car = GameObject.Find("Player");
        car.GetComponent<WheelVehicle>().Handbrake = true;
        GameObject canvas = GameObject.Find("Canvas");
        panel = canvas.transform.Find("RulsPanel").gameObject;
        panel.GetComponentInChildren<TextMeshProUGUI>().text = LevelUpMsg;
        panel.SetActive(true);
        car.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,0));
        GameObject.Find("Player").GetComponent<WheelVehicle>().enabled = false;
    }

    public void StartLevel()
    {
        GameObject.Find("Player").GetComponent<WheelVehicle>().enabled = true;
        GameObject.Find("Player").GetComponent<WheelVehicle>().Handbrake = false;
        GameObject.Find("Canvas").transform.Find("RulsPanel").gameObject.SetActive(false);
    }
}
