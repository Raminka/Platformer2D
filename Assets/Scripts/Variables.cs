using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

[System.Serializable]
public class GravityVariables
{
    public float G;
    public float impulsion;
}

[System.Serializable]
public class PlayerVariables
{
    public float maximumSpeed;
    public int maximumSaut;
}

public class Variables : MonoBehaviour {

    public GravityVariables gravityVariables;

    public Boundary boundary;

    public PlayerVariables playerVariables;

}
