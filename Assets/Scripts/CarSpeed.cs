using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class CarSpeed : MonoBehaviour
{
    public GameObject SpeedLimit;
    private Rigidbody rb;
    private float speed;
    [SerializeField] public GameObject speedPanel;
    [SerializeField] private string msg = "Speed is : ";
    [SerializeField] private string SLmsg = "allow : ";
    private string screenMsg = "";
    public GameObject scoreSystem ;
    //private bool OverSpeedflag = false;
    void Start()
    {
        speedPanel = GameObject.Find("Canvas").transform.Find("SpeedPanel").gameObject;
        rb = gameObject.GetComponent<Rigidbody>();
        scoreSystem = GameObject.Find("ScoreSystem");
        SpeedLimit = GameObject.Find("SpeedLimit");
    }

    void Update()
    {
        speed = rb.velocity.magnitude * 3.6f;
        if (speed <= 1) speed = 0;
        screenMsg = msg + (int)speed + " km/h" + "\n"+SLmsg + SpeedLimit.GetComponent<speedLimitScript>().CurrentLimit;
        if ((int)speed > SpeedLimit.GetComponent<speedLimitScript>().CurrentLimit)
        {
            screenMsg += "\n" + SpeedLimit.GetComponent<speedLimitScript>().MistakeMSG + ", minus "+ SpeedLimit.GetComponent<speedLimitScript>().mistakeCost * Time.deltaTime;
            if (scoreSystem == null) scoreSystem = GameObject.Find("ScoreSystem");
            try
            {
                scoreSystem.GetComponent<ScoreManager>().DecrreaseScore(SpeedLimit.GetComponent<speedLimitScript>().mistakeCost * Time.deltaTime);
            }
            catch (Exception e) { }
        }
        try
        {
            speedPanel.GetComponentInChildren<TextMeshProUGUI>().text = screenMsg;
        }
        catch (Exception e) { }
    }
}