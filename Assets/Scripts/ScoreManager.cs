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
    void Start()
    {
        ScorePanel = GameObject.Find("Canvas").transform.Find("ScorePanel").gameObject;
        sceneCtrl = GameObject.Find("Scenectrl");
        //ErrorsPanel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
    }

    void Update()
    {
        ScorePanel.GetComponentInChildren<TextMeshProUGUI>().text = scoreHeaderString + score+"\nmin possible score : "+minPossibleScore;
    }

    public void DecrreaseScore(float num)
    {
        score -= num;
        if (score < minPossibleScore)
            sceneCtrl.GetComponent<SceneCtrl>().ChangeScene("GameOver");
    }
}
