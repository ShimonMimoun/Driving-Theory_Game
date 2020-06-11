using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class editScore : MonoBehaviour
{
    public bool ans = true;

    void Start()
    {
    }
    private void Update()
    {
        var ss = GameObject.Find("ScoreSystem").GetComponent<ScoreManager>();
        ss.ShowScore();
    }
}
