using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public GameObject Panel;

    public void Start()
    {
        if (Panel != null) Panel.SetActive(false);

    }

    public void OpenePanel()
    {
        if (Panel != null)
            Panel.SetActive(!Panel.activeSelf);
    }
}
