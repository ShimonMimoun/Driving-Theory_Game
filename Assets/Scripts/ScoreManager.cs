using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject ScorePanel;
    public GameObject sceneCtrl;
    //public GameObject ErrorsPanel;
    [SerializeField] private float score = 100;
    [SerializeField] private float minPossibleScore = 70;
    [SerializeField] private string scoreHeaderString = "score : ";
    [SerializeField] private string GameOverMSG = "Your average score is : ";
    private float sumScore = 0;
    private float levelsCounter = 0;

    public float LevelsCounter { get => levelsCounter; set => levelsCounter = value; }
    public float SumScore { get => sumScore; set => sumScore = value; }
    public float Score { get => score; set => score = value; }

    void Start()
    {
        ScorePanel = GameObject.Find("Canvas").transform.Find("ScorePanel").gameObject;
        sceneCtrl = GameObject.Find("Scenectrl");
        //ErrorsPanel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
    }

    void Update()
    {
        if(ScorePanel != null)
            ScorePanel.GetComponentInChildren<TextMeshProUGUI>().text = scoreHeaderString + score + "\nmin possible score : " + minPossibleScore;
    }

    public void DecrreaseScore(float num)
    {
        score -= num;
        if (score < minPossibleScore)
            sceneCtrl.GetComponent<SceneCtrl>().ChangeScene("Lost");
    }

    public void ShowScore()
    {
        Debug.Log("Showing score");
        GameObject Panel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
        Panel.GetComponentInChildren<TextMeshProUGUI>().text = GameOverMSG + (sumScore / levelsCounter);
    }
}
