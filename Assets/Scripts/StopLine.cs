using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StopLine : MonoBehaviour
{
    float time = 0;
    public GameObject Panel;
    [SerializeField] private float StopWaitsTimer = 3;
    [SerializeField] private string mistake = "You should wait 3 seconds!!!";
    [SerializeField] private string good = "Great!!!";

    public void Start()
    {
        if (Panel != null) Panel.SetActive(false);

    }

    private void OnTriggerStay(Collider other)
    {
        time += Time.deltaTime;
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        if (time < StopWaitsTimer)
        {
            Panel.GetComponentInChildren<TextMeshProUGUI>().text = mistake;
            Panel.SetActive(true);
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
