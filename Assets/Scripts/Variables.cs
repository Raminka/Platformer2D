﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}


public class Variables : MonoBehaviour {

    public Boundary boundary;

}
