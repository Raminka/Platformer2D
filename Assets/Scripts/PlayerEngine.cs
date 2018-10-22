using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEngine : MonoBehaviour {
    

    private Vector3 position;
    private float maximumSpeed; //vitesse maximale horizontale
    public Variables variables; 
    public GravityController gravityController;
    
    private bool isOnAir;
    private bool canMoveLaterally;
    private int compteurSaut;

    public bool canGoWest;
    public bool canGoEast;

    private typeOfWall lastWallTouched;

    public bool inTransparent;

    private void Start()
    {
        maximumSpeed = variables.playerVariables.maximumSpeed;
        isOnAir = true;
        canMoveLaterally = true;
        compteurSaut = variables.playerVariables.maximumSaut;
        lastWallTouched = typeOfWall.NONE;
        canGoWest = true;
        canGoEast = true;
        inTransparent = false;
    }

    private void updatePosition (Vector2 deplacement)
    {
        if (canMoveLaterally)
        {
            position = gameObject.transform.position + new Vector3(deplacement.x, deplacement.y, 0);
        }
        else
        {
            position = gameObject.transform.position + new Vector3(0, deplacement.y, 0);
        }
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
        if (!canGoWest & direction.x > 0)
        {
            direction.x = 0;
        }
        else if (!canGoEast & direction.x < 0)
        {
            direction.x = 0;
        }
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
        setIsOnAir(true);
        gravityController.On();
        compteurSaut--;
    }

    public void setIsOnAir(bool b)
    {
        isOnAir = b;
        if (!b)
        {
            resetSaut();
        }
    }

    public bool getIsOnAir()
    {
        return isOnAir;
    }

    public void setCanMoveLaterally(bool b)
    {
        canMoveLaterally = b;
    }

    public void resetSaut()
    {
        compteurSaut = variables.playerVariables.maximumSaut;
    }

    public bool canJump()
    {
        if (isOnAir & compteurSaut == variables.playerVariables.maximumSaut ) return false;
        return (compteurSaut > 0 & !inTransparent);
    }

    public void wallJump()
    {
        compteurSaut = 1;
    }


    public void setLastWall(typeOfWall wall)
    {
        lastWallTouched = wall;
    }

    public typeOfWall getLastWall()
    {
        return lastWallTouched;
    }
}
