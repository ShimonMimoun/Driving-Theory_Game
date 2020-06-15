using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCar : MonoBehaviour
{
    public GameObject startPos;
    [SerializeField]private bool firstLevel = true;
    void Start()
    {
        if (firstLevel)
        {
            startPos = GameObject.Find("StartPos");
            GameObject.Find("CarSelectorScript").GetComponentInChildren<DestroyParent>().ChangeParents();
            Transform current = startPos.transform;
            GameObject carSelector = GameObject.Find("CarSelectorScript");
            int carInd = carSelector.GetComponent<CarSelectionScript>().carSelected;
            carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.position = current.position;
            carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.rotation = current.rotation;
            carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.localScale = current.localScale;
            Camera.main.transform.parent = carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.Find("Body").transform;
            carSelector.GetComponent<CarSelectionScript>().Cars[carInd].AddComponent<CarSpeed>();
            carSelector.GetComponent<CarSelectionScript>().Cars[carInd].AddComponent<Collids>();
            carSelector.GetComponent<CarSelectionScript>().Cars[carInd].GetComponent<WheelVehicle>().enabled = true;
        }
        else
        {
            startPos = GameObject.Find("StartPos");
            Transform current = startPos.transform;
            GameObject carSelector = GameObject.Find("CarSelectorScript");
            int carInd = carSelector.GetComponent<CarSelectionScript>().carSelected;
            carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.position = current.transform.position;
            carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.rotation = current.transform.rotation;
            carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.localScale = current.transform.localScale;
            carSelector.GetComponent<CarSelectionScript>().Cars[carInd].GetComponent<WheelVehicle>().enabled = true;
        }
    }
}
