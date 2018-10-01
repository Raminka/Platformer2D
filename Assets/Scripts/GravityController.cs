using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {

    public float G;
    private float deplacementY;
    public float timeGOff;
    private bool isOn;

    private void Start()
    {
        deplacementY = -G * Time.deltaTime;
        isOn = true;
    }

    public Vector2 deplacement()
    {
        return new Vector2(0, deplacementY);
    }


    public void reverse()
    {
        //pour simuler un sorte d'impulsion, on exerce la force dans le sens oposé de pesanteur
        deplacementY = G * Time.deltaTime;
    }

    public void Off()
    {
        deplacementY = 0;
        isOn = false;
    }

    public void On()
    {
        isOn = true;
    }

    private void FixedUpdate()
    {
        //recuperation de gravité de base 
        if (deplacementY > - G * Time.deltaTime & isOn )
        {
            deplacementY -= G * Time.deltaTime / timeGOff;
        }
    }

}
