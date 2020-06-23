using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedLimitScript : MistakeCost
{
    [SerializeField] private float currentLimit = 80;

    public float CurrentLimit { get => currentLimit; set => currentLimit = value; }
}
