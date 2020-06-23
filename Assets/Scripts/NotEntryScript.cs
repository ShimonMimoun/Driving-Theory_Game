using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEntryScript : MonoBehaviour
{
    [SerializeField] private bool correctDirection = false;
    [SerializeField] private bool uncorrectDirection = false;
    [SerializeField] private bool onTheMiddleOFStreet = false;

    public bool UncorrectDirection { get => uncorrectDirection; set => uncorrectDirection = value; }
    public bool CorrectDirection { get => correctDirection; set => correctDirection = value; }
    public bool OnTheMiddleOFStreet { get => onTheMiddleOFStreet; set => onTheMiddleOFStreet = value; }
}
