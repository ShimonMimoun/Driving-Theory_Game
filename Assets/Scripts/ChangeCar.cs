using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCar : MonoBehaviour
{
    public GameObject startPos;
    [SerializeField]private bool firstLevel = true;
    [SerializeField] private GameObject arrowDirection;
    void Start()
    {
        if (firstLevel)
        {
            startPos = GameObject.Find("StartPos");
            Transform current = startPos.transform;
            GameObject carSelector = GameObject.Find("CarSelectorScript");
            int carInd = carSelector.GetComponent<CarSelectionScript>().carSelected;
            carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.position = current.position;
            carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.rotation = current.rotation;
            carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.localScale = current.localScale;
            Camera.main.transform.parent = carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform;
            carSelector.GetComponent<CarSelectionScript>().Cars[carInd].AddComponent<CarSpeed>();
            carSelector.GetComponent<CarSelectionScript>().Cars[carInd].AddComponent<Collids>();
            carSelector.GetComponent<CarSelectionScript>().Cars[carInd].GetComponent<DontDestroy>().enabled = true;
            carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform.SetParent(null);
            carSelector.GetComponent<DontDestroy>().enabled = false;
            GameObject arrow = GameObject.Find("Player").transform.Find("ARROW").gameObject;
            arrow.GetComponent<MeshRenderer>().enabled = true;
            arrow.transform.rotation = startPos.transform.rotation;
            arrow.SetActive(true);
            arrow.GetComponent<MoveArrow>().enabled = true;
            arrow.transform.parent = carSelector.GetComponent<CarSelectionScript>().Cars[carInd].transform;
            Destroy(carSelector);

        }
        else
        {
            Transform current = startPos.transform;
            GameObject player = GameObject.Find("Player");
            player.GetComponent<WheelVehicle>().Handbrake = true;
            player.transform.position = current.transform.position;
            player.transform.rotation = current.transform.rotation;
            player.transform.localScale = current.transform.localScale;
            GameObject arrow = player.transform.Find("ARROW").gameObject;
            arrow.GetComponent<MoveArrow>().target = GameObject.Find("DestPos").transform;
            Button button = GameObject.Find("Canvas").transform.Find("RulsPanel").GetComponentInChildren<Button>();
            button.onClick.AddListener(TaskOnClick);
        }
    }

    private void TaskOnClick()
    {
        GameObject.Find("EditCar").GetComponent<StartLevelScript>().StartLevel();
    }
}
