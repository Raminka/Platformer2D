using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public PlayerEngine player; 

    // Update is called once per frame
    void FixedUpdate()
    {

        //deplacement horizontal 
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(moveHorizontal, 0);
        player.move(direction);

        //saut
        if (Input.GetButtonDown("Jump") & !player.getIsOnAir())
        {
           
            player.jump();
        }
    }
}
