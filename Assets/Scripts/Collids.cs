using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Collids : MonoBehaviour
{
    [SerializeField] private string errorMSG = "This way you will never get a driving license!!!";
    [SerializeField] public GameObject panel;
    private bool firstHit = false;

    public void start()
    {
        panel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
        if (panel != null) panel.SetActive(false);
    }
    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Accident" || other.tag == "Road") // crash into roundabout
        {
            if (!firstHit)
            {
                panel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
                firstHit = true;
            }
            else
            {
                panel.GetComponentInChildren<TextMeshProUGUI>().text = errorMSG;
                panel.SetActive(true);
                yield return new WaitForSeconds(3);
                panel.SetActive(false);
            }
        }
    }
}
    
