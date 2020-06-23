using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject ScorePanel;
    public GameObject sceneCtrl;
    [SerializeField] private float score = 100;
    [SerializeField] private float minPossibleScore = 70;
    [SerializeField] private string scoreHeaderString = "score : ";
    [SerializeField] private string GameOverMSG = "Your average score is : ";
    private float sumScore = 0;
    private float levelsCounter = 0;
    [Range (0,3)] 
    [SerializeField] private int numberOfLifes = 3;

    [SerializeField] private GameObject[] lives = new GameObject[3];   

    public float LevelsCounter { get => levelsCounter; set => levelsCounter = value; }
    public float SumScore { get => sumScore; set => sumScore = value; }
    public float Score { get => score; set => score = value; }

    void Start()
    {
        ScorePanel = GameObject.Find("Canvas").transform.Find("ScorePanel").gameObject;
        sceneCtrl = GameObject.Find("Scenectrl");
    }

    void Update()
    {
        if(ScorePanel != null)
            ScorePanel.GetComponentInChildren<TextMeshProUGUI>().text = scoreHeaderString + score + "\nmin score to win : " + minPossibleScore;
    }

    public void DecrreaseScore(float num)
    {
        score -= num;
        if (score < minPossibleScore)
        {
            RestartLevel();
        }
    }


    public void ShowScore()
    {
        Debug.Log("Showing score");
        GameObject Panel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
        Panel.GetComponentInChildren<TextMeshProUGUI>().text = GameOverMSG + (sumScore / levelsCounter);
    }
    public void RestartLevel()
    {
        score = 100;
        numberOfLifes--;
        GameObject.Find("Player").GetComponent<WheelVehicle>().Speed = 0;
        if (numberOfLifes < 0) // lost
            sceneCtrl.GetComponent<SceneCtrl>().ChangeScene("Lost");
        else
        {
            lives[numberOfLifes].SetActive(false);
            if (SceneManager.GetActiveScene().name.Equals("1"))
            {
                GameObject.Find("Player").GetComponent<WheelVehicle>().enabled = false;
                sceneCtrl.GetComponent<SceneCtrl>().ChangeScene("1second");
            }
            else
            {
                sceneCtrl.GetComponent<SceneCtrl>().ChangeScene(SceneManager.GetActiveScene().name);
                GameObject.Find("Player").GetComponent<WheelVehicle>().enabled = false;
            }
        }
    }
}
