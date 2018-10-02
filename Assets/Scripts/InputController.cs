using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public PlayerEngine player; 

    // Update is called once per frame
    void Update()
    {
        //saut
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("button pressed");
            if (player.canJump())
            {
                Debug.Log("saut accepté");
                player.jump();
            }
            player.jump();
        }

        //deplacement horizontal 
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(moveHorizontal, 0);
        player.move(direction);

        
    }
}
