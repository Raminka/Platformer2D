using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEngine : MonoBehaviour {
    

    private Vector3 position;
    private float maximumSpeed; //vitesse maximale horizontale
    public Variables variables; 
    public GravityController gravityController;
    
    public bool isOnAir;

    private void Start()
    {
        maximumSpeed = variables.playerVariables.maximumSpeed;
        isOnAir = true;
       
    }

    private void updatePosition (Vector2 deplacement)
    {
        position = gameObject.transform.position + new Vector3(deplacement.x, deplacement.y, 0);
        gameObject.transform.position = position;

        //verification que l'objet n'a pas quitté la limite du jeu
        gameObject.transform.position = new Vector3
        (
            Mathf.Clamp(gameObject.transform.position.x, variables.boundary.xMin, variables.boundary.xMax),
            Mathf.Clamp(gameObject.transform.position.y, variables.boundary.yMin, variables.boundary.yMax),
            0
        );
    }

    //deplacement influencé par le choix du joueur 
    public void move(Vector2 direction)
    {
        updatePosition((direction) * maximumSpeed * Time.deltaTime);
    }


    private void FixedUpdate()
    {
        //deplacement due au pesanteur
        updatePosition(gravityController.deplacement());   
    }

    public void jump()
    {
        gravityController.reverse();
        isOnAir = true;
        gravityController.On();
    }

}
