using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StopLine : MistakeCost
{
    float time = 0;
    public GameObject Panel;
    [SerializeField] private float StopWaitsTimer = 3;
    [SerializeField] private string good = "Great!!!";
    [SerializeField] private string MSG = "Wait here 3 seconds";
    private string tempMSG = "You should wait 3 seconds!!!";

    public void Start()
    {
        if(Panel == null) Panel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
        if (Panel != null) Panel.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        Panel.SetActive(true);
        Panel.GetComponentInChildren<TextMeshProUGUI>().text = MSG;
    }

    private void OnTriggerStay(Collider other)
    {
        string[] messages = { MSG, "2", "1", "GO" };
        time += Time.deltaTime;
        int round = (int)time;
        if (round > 3) round = 3;
        Panel.GetComponentInChildren<TextMeshProUGUI>().text = messages[round];
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        if (time < StopWaitsTimer)
        {
            if (string.IsNullOrEmpty(MistakeMSG)) MistakeMSG = tempMSG; 
            Panel.GetComponentInChildren<TextMeshProUGUI>().text = this.MistakeMSG;
            Panel.SetActive(true);
            GameObject.Find("ScoreSystem").GetComponent<ScoreManager>().DecrreaseScore(this.mistakeCost);
            yield return new WaitForSeconds(3);
            Panel.SetActive(false);
        }
        else
        {
            Panel.GetComponentInChildren<TextMeshProUGUI>().text = good;
            Panel.SetActive(true);
            yield return new WaitForSeconds(2);
            Panel.SetActive(false);
        }
        time = 0;
    }
}