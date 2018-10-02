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
        float temp = gravity.deplacement().y;
        if (other.CompareTag("Crossable") & other.transform.position.y <= transform.position.y - 0.25)
        {

            player.setIsOnAir(false);
                gravity.Off();
            
        }
        else if (other.CompareTag("Floor"))
        {

            player.setIsOnAir(false);

        }
        else if (other.CompareTag("NonCrossable"))
        {
            if (gravity.deplacement().y >= 0)
            {
                player.setIsOnAir(true);
                //gravity.Off();
                //gravity.On();
            }
            else if (other.transform.position.y <= transform.position.y - 0.25)
            {

                player.setIsOnAir(false);
                gravity.Off();
            }
        }
        if (gravity.deplacement().y == temp & !other.CompareTag("Floor"))
        {
            player.setCanMoveLaterally(false);
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
    }
}
