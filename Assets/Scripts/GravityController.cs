﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {

    private float G;
    private float impulsion;
    private float deplacementY;
    private float vitesseInversion;
    private bool isOn;
    public Variables variables;

    private void Start()
    {
        G=variables.gravityVariables.G;
        impulsion = variables.gravityVariables.impulsion;
        vitesseInversion =30 * impulsion ; //NE PAS TOUCHER!!!

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
        deplacementY =  G * Time.deltaTime;
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
       /* if (deplacementY < -G * Time.deltaTime)
        {
            deplacementY = -G * Time.deltaTime;
        }*/
        //recuperation de gravité de base 
        if (deplacementY > - G * Time.deltaTime & isOn )
        {
            deplacementY -= G * Time.deltaTime / vitesseInversion;
        }
    }

}
