using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class CarSpeed : MistakeCost
{
    [SerializeField] public float speedLimit = 80;
    private Rigidbody rb;
    private float speed;
    [SerializeField] public GameObject speedPanel;
    [SerializeField] private string msg = "Speed is : ";
    private string screenMsg = "";
    [SerializeField] private string OverSpeedMsg = "slow down!!!!!!";
    public GameObject scoreSystem ;
    //private bool OverSpeedflag = false;
    // Start is called before the first frame update
    void Start()
    {
        speedPanel = GameObject.Find("Canvas").transform.Find("SpeedPanel").gameObject;
        rb = gameObject.GetComponent<Rigidbody>();
        scoreSystem = GameObject.Find("ScoreSystem");
    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity.magnitude * 3.6f;
        if (speed <= 1) speed = 0;
        screenMsg = msg + speed + " km/h";
        if (speed > speedLimit)
        {
            screenMsg += "\n" + OverSpeedMsg;
            if (scoreSystem == null) scoreSystem = GameObject.Find("ScoreSystem");
            try
            {
                scoreSystem.GetComponent<ScoreManager>().DecrreaseScore(this.mistakeCost * Time.deltaTime);
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
