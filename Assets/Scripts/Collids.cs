using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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
        if (other.gameObject.CompareTag("Accident") || other.gameObject.CompareTag("Road") || other.gameObject.CompareTag("Sign")) // crash into roundabout
        {
            if (scoreSystem == null) scoreSystem = GameObject.Find("ScoreSystem");
            panel.GetComponentInChildren<TextMeshProUGUI>().text = other.GetComponent<MistakeCost>().MistakeMSG + "\n minus " + other.GetComponent<MistakeCost>().mistakeCost + " points";
            panel.SetActive(true);
            scoreSystem.GetComponent<ScoreManager>().DecrreaseScore(other.GetComponent<MistakeCost>().mistakeCost);
            yield return new WaitForSeconds(3);
            panel.SetActive(false);
        }
        else if (other.gameObject.CompareTag("AccidentCar"))
        {
            if (scoreSystem == null) scoreSystem = GameObject.Find("ScoreSystem");
            panel.GetComponentInChildren<TextMeshProUGUI>().text = other.GetComponent<MistakeCost>().MistakeMSG + "\n minus " + other.GetComponent<MistakeCost>().mistakeCost + " points";
            panel.SetActive(true);
            scoreSystem.GetComponent<ScoreManager>().DecrreaseScore(other.GetComponent<MistakeCost>().mistakeCost);
            other.gameObject.SetActive(false);
            yield return new WaitForSeconds(3);
            panel.SetActive(false);
        }
        else if (other.gameObject.CompareTag("traffic light"))
        {
            this.lastTL = other.gameObject;
            if (scoreSystem == null) scoreSystem = GameObject.Find("ScoreSystem");
            if (!this.lastTL.GetComponent<LightModeScripts>().blink) // NOT GREEN OR IN BLINKING MODE
            {
                panel.GetComponentInChildren<TextMeshProUGUI>().text = other.GetComponent<MistakeCost>().MistakeMSG + "\n minus " + other.GetComponent<MistakeCost>().mistakeCost + " points";
                panel.SetActive(true);
                scoreSystem.GetComponent<ScoreManager>().DecrreaseScore(other.GetComponent<MistakeCost>().mistakeCost);
                Debug.Log(other.GetComponent<MistakeCost>().mistakeCost);
                yield return new WaitForSeconds(1);
                panel.SetActive(false);
            }
        }
        else if (other.gameObject.CompareTag("OpenPart2"))
        {
            GameObject.Find("Part2").GetComponent<BoxCollider>().isTrigger = true;
            panel.GetComponentInChildren<TextMeshProUGUI>().text = "Now you can go to destionation 2";
            transform.Find("ARROW").GetComponent<MoveArrow>().target = GameObject.Find("DestPos 2").transform;
            panel.SetActive(true);
            yield return new WaitForSeconds(2);
            panel.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Part2"))
        {

            if (GameObject.Find("Part2").GetComponent<BoxCollider>().isTrigger == true)
            {
                GameObject.Find("Part2").GetComponent<startPart2>().MoveCars();
            }
            else
            {
                panel.GetComponentInChildren<TextMeshProUGUI>().text = "You have to go to destionation 1 first";
                panel.SetActive(true);
                yield return new WaitForSeconds(2);
                panel.SetActive(false);
            }

        }
        else if (other.gameObject.CompareTag("Good"))
        {
            GameObject DontEntry = GameObject.Find("Signs").transform.Find("NotEntry").gameObject;
            if (!DontEntry.GetComponent<NotEntryScript>().UncorrectDirection)
                DontEntry.GetComponent<NotEntryScript>().CorrectDirection = true;
        }
        else if (other.gameObject.CompareTag("Bad")) // set as bad and decrease points
        {
            GameObject DontEntry = GameObject.Find("Signs").transform.Find("NotEntry").gameObject;
            if (!DontEntry.GetComponent<NotEntryScript>().CorrectDirection)
            {
                DontEntry.GetComponent<NotEntryScript>().UncorrectDirection = true;
                panel.GetComponentInChildren<TextMeshProUGUI>().text = DontEntry.GetComponent<MistakeCost>().MistakeMSG + "\n minus " + DontEntry.GetComponent<MistakeCost>().mistakeCost + " points";
                panel.SetActive(true);
                scoreSystem.GetComponent<ScoreManager>().DecrreaseScore(DontEntry.GetComponent<MistakeCost>().mistakeCost);
                yield return new WaitForSeconds(1);
                panel.SetActive(false);
            }
        }
        else if (other.gameObject.CompareTag("Destination"))
        {
            levelUp();
            if (SceneManager.GetActiveScene().name.Equals("1")) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // load next level
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("traffic light manager"))
        {
            try
            {
                if (this.lastTL.GetComponent<LightModeScripts>().LightRed.enabled)
                {
                    if (scoreSystem == null) scoreSystem = GameObject.Find("ScoreSystem");
                    panel.GetComponentInChildren<TextMeshProUGUI>().text = other.GetComponent<MistakeCost>().MistakeMSG;
                    panel.SetActive(true);
                    scoreSystem.GetComponent<ScoreManager>().DecrreaseScore(other.GetComponent<MistakeCost>().mistakeCost * Time.deltaTime);
                }
            }catch (MissingReferenceException e) { scoreSystem.GetComponent<ScoreManager>().DecrreaseScore(scoreSystem.GetComponent<ScoreManager>().Score); }
        }
        else if (other.gameObject.CompareTag("Middle")) // check if the direction is right, else decrease points
        {
            GameObject DontEntry = GameObject.Find("Signs").transform.Find("NotEntry").gameObject;
            DontEntry.GetComponent<NotEntryScript>().OnTheMiddleOFStreet = true;
            if (DontEntry.GetComponent<NotEntryScript>().UncorrectDirection && (!DontEntry.GetComponent<NotEntryScript>().CorrectDirection))
            {
                DontEntry.GetComponent<NotEntryScript>().UncorrectDirection = true;
                panel.GetComponentInChildren<TextMeshProUGUI>().text = DontEntry.GetComponent<MistakeCost>().MistakeMSG + "\n minus " + DontEntry.GetComponent<MistakeCost>().mistakeCost * Time.deltaTime + " points";
                panel.SetActive(true);
                scoreSystem.GetComponent<ScoreManager>().DecrreaseScore(DontEntry.GetComponent<MistakeCost>().mistakeCost * Time.deltaTime);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("traffic light manager"))
        {
            panel.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Good"))
        { // if he isn's in the middle bool = false
            GameObject DontEntry = GameObject.Find("Signs").transform.Find("NotEntry").gameObject;
            if ((!DontEntry.GetComponent<NotEntryScript>().UncorrectDirection) && DontEntry.GetComponent<NotEntryScript>().OnTheMiddleOFStreet)
                DontEntry.GetComponent<NotEntryScript>().CorrectDirection = true;
            else if (!DontEntry.GetComponent<NotEntryScript>().OnTheMiddleOFStreet)
                DontEntry.GetComponent<NotEntryScript>().CorrectDirection = DontEntry.GetComponent<NotEntryScript>().UncorrectDirection = false;
        }
        else if (other.gameObject.CompareTag("Bad")) // if he isn's in the middle bool = false
        {
            GameObject DontEntry = GameObject.Find("Signs").transform.Find("NotEntry").gameObject;
            if (DontEntry.GetComponent<NotEntryScript>().UncorrectDirection)
                DontEntry.GetComponent<NotEntryScript>().CorrectDirection = DontEntry.GetComponent<NotEntryScript>().UncorrectDirection = false;
        }
        else if (other.gameObject.CompareTag("Middle")) // check if the direction is right, else decrease points
        {
            GameObject DontEntry = GameObject.Find("Signs").transform.Find("NotEntry").gameObject;
            DontEntry.GetComponent<NotEntryScript>().OnTheMiddleOFStreet = false;
            panel.SetActive(false);
        }
    }

    private void levelUp()
    {
        var ss = GameObject.Find("ScoreSystem").GetComponent<ScoreManager>();
        ss.SumScore += ss.Score;
        ss.LevelsCounter++;
        ss.Score = 100;
        gameObject.GetComponent<WheelVehicle>().Handbrake = true;
    }
}