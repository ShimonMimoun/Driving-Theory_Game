using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{ 
    [SerializeField] private string[] sceneThatDestroyed = { "Menu" ,"GameOver"};
    private void Update()
    {
        foreach(string s in sceneThatDestroyed)
            if (SceneManager.GetActiveScene().name == s)
            {
                Destroy(this.gameObject);
            }
    }
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SelectedCar");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
