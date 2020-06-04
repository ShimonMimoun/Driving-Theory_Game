using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelectionScript : MonoBehaviour
{
    public List<GameObject> Cars = new List<GameObject>();
    public int carSelected;
    void Start()
    {
        Cars[0].SetActive(true);
        for (int i =1;i<Cars.Count; i++)
        {
            Cars[i].SetActive(false);
        }

        carSelected = 0;
    }

    public void LoadCar(int i)
    {
        for (int j = 0; j < Cars.Count; j++)
        {
            if (i == j) Cars[j].SetActive(true);
            else Cars[j].SetActive(false);
        }
        carSelected = i;
    }
}
