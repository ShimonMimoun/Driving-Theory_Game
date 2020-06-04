using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Collids : MonoBehaviour
{
    [SerializeField] private string errorMSG = "This way you will never get a driving license!!!";
    public GameObject Panel;

    public void start()
    {
        if (Panel != null) Panel.SetActive(false);
        else
        {
            Panel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
            if (Panel != null) Panel.SetActive(false);
        }
    }
    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag != "StopLine" && other.tag != "Road")
        {
            Panel.GetComponentInChildren<TextMeshProUGUI>().text = errorMSG;
            Panel.SetActive(true);
            yield return new WaitForSeconds(3);
            Panel.SetActive(false);
        }
    }
}
