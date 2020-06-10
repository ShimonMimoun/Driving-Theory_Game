using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCar : MonoBehaviour
{
    public GameObject startPos;
    void Start()
    {
        startPos = GameObject.Find("StartPos");
        GameObject.Find("CarSelectorScript").GetComponentInChildren<DestroyParent>().ChangeParents();
        Transform current = startPos.transform;
        GameObject carSelector = GameObject.Find("CarSelectorScript");
        int carInd = carSelector.GetComponent<CarSelectionScript>().carSelected;
        carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.position = startPos.transform.position;
        carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.rotation = startPos.transform.rotation;
        carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.localScale = startPos.transform.localScale;
        Camera.main.transform.parent = carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.Find("Body").transform;
 
        carSelector.GetComponent<CarSelectionScript>().Cars[carInd].AddComponent<CarSpeed>();
        carSelector.GetComponent<CarSelectionScript>().Cars[carInd].AddComponent<Collids>();
    }
}
