using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collids : MonoBehaviour
{
    [SerializeField] private string errorMSG = "This way you will never get a driving license!!!";
    [SerializeField] public GameObject panel;
    public GameObject scoreSystem;
    private GameObject lastTL;

    public void start()
    {
        scoreSystem = GameObject.Find("ScoreSystem");
        panel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
        if (panel != null) panel.SetActive(false);
    }
    private IEnumerator OnTriggerEnter(Collider other)
    {
        panel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
        if (other.tag == "Accident" || other.tag == "Road" || other.tag == "Sign") // crash into roundabout
        {
                if (scoreSystem == null) scoreSystem = GameObject.Find("ScoreSystem");
                panel.GetComponentInChildren<TextMeshProUGUI>().text = other.GetComponent<MistakeCost>().MistakeMSG + "\n minus "+ other.GetComponent<MistakeCost>().mistakeCost + "points"; 
                panel.SetActive(true);
                scoreSystem.GetComponent<ScoreManager>().DecrreaseScore(other.GetComponent<MistakeCost>().mistakeCost);
                yield return new WaitForSeconds(3);
                panel.SetActive(false);
        }
        if (other.tag == "Destination")
        {
            panel.GetComponentInChildren<TextMeshProUGUI>().text = "level up! please wait 3 sec";
            panel.SetActive(true);
            yield return new WaitForSeconds(3);
            panel.SetActive(false);
            float currentScene = float.Parse(SceneManager.GetActiveScene().name);
            currentScene++;
            levelUp();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // load next level
        }
        if(other.tag == "traffic light")
        {
            this.lastTL = other.gameObject;
            if (scoreSystem == null) scoreSystem = GameObject.Find("ScoreSystem");
            if (!this.lastTL.GetComponent<LightModeScripts>().blink) // NOT GREEN OR IN BLINKING MODE
            {
                panel.GetComponentInChildren<TextMeshProUGUI>().text = other.GetComponent<MistakeCost>().MistakeMSG + "\n minus " + other.GetComponent<MistakeCost>().mistakeCost + "points";
                panel.SetActive(true);
                scoreSystem.GetComponent<ScoreManager>().DecrreaseScore(other.GetComponent<MistakeCost>().mistakeCost);
                yield return new WaitForSeconds(1);
                panel.SetActive(false);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "traffic light manager")
        {
            if (this.lastTL.GetComponent<LightModeScripts>().LightRed.enabled)
            {
                if (scoreSystem == null) scoreSystem = GameObject.Find("ScoreSystem");
                panel.GetComponentInChildren<TextMeshProUGUI>().text = other.GetComponent<MistakeCost>().MistakeMSG;
                panel.SetActive(true);
                scoreSystem.GetComponent<ScoreManager>().DecrreaseScore(other.GetComponent<MistakeCost>().mistakeCost * Time.deltaTime);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "traffic light manager")
        {
            panel.SetActive(false);
        }
    }
    private void levelUp()
    {
        var ss = GameObject.Find("ScoreSystem").GetComponent<ScoreManager>();
        ss.SumScore += ss.Score;
        ss.LevelsCounter++;
        ss.Score = 100;
    }
}