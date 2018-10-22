using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum typeOfWall {NONE, EAST, WEST }

public class ColliderController : MonoBehaviour
{

    public Collider2D playerCollider;
    public PlayerEngine player;
    public GravityController gravity;
    private typeOfWall actualWall;

    private void Start()
    {
        actualWall = typeOfWall.NONE;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("East"))
        {
            Debug.Log("E");
            actualWall = typeOfWall.EAST;
            if (transform.position.y >= other.transform.position.y - 2.5f & transform.position.y <= other.transform.position.y + 2.5f)
            {
                player.canGoEast = false;
                transform.position = new Vector3(other.transform.position.x + 0.3f, transform.position.y, transform.position.z);
            }
            else if (gravity.deplacement().y >= 0 & transform.position.y <= other.transform.position.y + 2.5f)
            {
                player.setIsOnAir(true);
                gravity.Off();
                gravity.On();
            }
            else if (transform.position.y >= other.transform.position.y +2.4f )
            {
                player.setIsOnAir(false);
                gravity.Off();
                transform.position = new Vector3(transform.position.x, other.transform.position.y + 2.75f, transform.position.z);
            }

        }
        else if (other.CompareTag("West"))
        {
            Debug.Log("W");
            actualWall = typeOfWall.WEST;
            if (transform.position.y >= other.transform.position.y - 2.5f  & transform.position.y <= other.transform.position.y + 2.5f)
            {
                player.canGoWest = false;
                transform.position = new Vector3(other.transform.position.x - 0.3f, transform.position.y, transform.position.z);
            }
            else if ( gravity.deplacement().y >= 0 & transform.position.y <= other.transform.position.y + 2.5f) 
            {
                player.setIsOnAir(true);
                gravity.Off();
                gravity.On();
            }
            else if (transform.position.y >= other.transform.position.y + 2.4f)
            {
                player.setIsOnAir(false);
                gravity.Off();
                transform.position = new Vector3(transform.position.x, other.transform.position.y + 2.75f, transform.position.z);
            }
        }
        else {
            actualWall = typeOfWall.NONE;
            player.setLastWall(typeOfWall.NONE); 
                }

        if (actualWall != typeOfWall.NONE  & actualWall != player.getLastWall())
        {
            player.wallJump();
            player.setLastWall(actualWall);
        }



        if (other.CompareTag("Floor"))
        {

            player.setIsOnAir(false);

        }
        else if (other.CompareTag("Crossable") || other.CompareTag("NonCrossable"))
        {
            float temp = gravity.deplacement().y;
            if ( other.transform.position.y <= transform.position.y - 0.15) //crossable ou non crossable par au-dessus
            {

                player.setIsOnAir(false);
                gravity.Off();
                transform.position = new Vector3(transform.position.x, other.transform.position.y + 0.3f, transform.position.z);
            }
            else if (other.CompareTag("NonCrossable") & gravity.deplacement().y >= 0) //non crossable par en-dessous (de côté ou non)
            {
                    player.setCanMoveLaterally(false);
                    player.setIsOnAir(true);
                    gravity.Off();
                    gravity.On();
            }
            else if (other.CompareTag("Crossable") & gravity.deplacement().y>=0) //crossable par en-dessous
            {
                player.setCanMoveLaterally(true);
            }
            else if (gravity.deplacement().y == temp ) //non crossable par le côté
            {
                player.setCanMoveLaterally(false);
            }
        }

        if (other.CompareTag("trans"))
        {
            player.inTransparent = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Crossable") || other.CompareTag("NonCrossable"))
        {
         
            gravity.On();
            player.setIsOnAir(true);
        }
        player.setCanMoveLaterally(true);


        if (other.CompareTag("West"))
        {
            player.canGoWest = true;
            if (transform.position.x - other.transform.position.x <= 0.3f & transform.position.y - other.transform.position.y >= 2.5f )
            {
                gravity.On();
                player.setIsOnAir(true);
            }
        }
        else if (other.CompareTag("East"))
        {
            player.canGoEast = true;
            
            if (other.transform.position.x - transform.position.x <= 0.3f & transform.position.y - other.transform.position.y >=2.5f )
            {
                gravity.On();
                player.setIsOnAir(true);
            }
        }
       if (other.CompareTag("trans"))
        {
            player.inTransparent = false;
        }
    }
}
