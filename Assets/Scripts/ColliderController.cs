using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{

    public Collider2D playerCollider;
    public PlayerEngine player;
    public GravityController gravity;

    void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.CompareTag("Floor") & gravity.deplacement().y <= 0)
        if (other.CompareTag("Crossable") & other.transform.position.y <= transform.position.y - 0.25)
        {
            
                player.isOnAir = false;
                gravity.Off();
            
        }
        else if (other.CompareTag("Floor"))
        {
            player.isOnAir = false;

        }
        else if (other.CompareTag("NonCrossable"))
        {
            //if (other.transform.position.y >= transform.position.y + 0.35)
            if (gravity.deplacement().y >= 0)
            {
                player.isOnAir = true;
                gravity.Off();
                gravity.On();
            }
            else if (other.transform.position.y <= transform.position.y - 0.25)
            {
                player.isOnAir = false;
                gravity.Off();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Crossable") || other.CompareTag("NonCrossable"))
        {
            gravity.On();   
        }
    }
}
