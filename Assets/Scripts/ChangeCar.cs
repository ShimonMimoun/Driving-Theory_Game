using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCar : MonoBehaviour
{
    public GameObject TempCar;
    void Start()
    {
        GameObject.Find("CarSelectorScript").GetComponentInChildren<DestroyParent>().ChangeParents();
        Transform current = TempCar.transform;
        GameObject carSelector = GameObject.Find("CarSelectorScript");
        int carInd = carSelector.GetComponent<CarSelectionScript>().carSelected;
        carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.position = GameObject.Find("Car").transform.position;
        carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.rotation = GameObject.Find("Car").transform.rotation;
        carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.localScale = GameObject.Find("Car").transform.localScale;
        Camera.main.transform.parent = carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.Find("Body").transform;
 
        carSelector.GetComponent<CarSelectionScript>().Cars[carInd].AddComponent<CarSpeed>();
        carSelector.GetComponent<CarSelectionScript>().Cars[carInd].AddComponent<Collids>();
        Destroy(GameObject.Find("Car"));
    }
}
