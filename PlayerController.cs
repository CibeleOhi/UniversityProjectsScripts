using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public static float playerSpeed;
    public Rigidbody Player;


    public void Start()
    {
        Player = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        playerSpeed = 7;
        Cursor.visible = false;

    }



    public void Update()
    {
            float moveVertical = Input.GetAxis("Vertical") * playerSpeed;
            float moveHorizontal = Input.GetAxis("Horizontal") * playerSpeed;
            float moveJump = Input.GetAxis("Jump");

            moveVertical *= Time.deltaTime;
            moveHorizontal *= Time.deltaTime;
            moveJump *= Time.deltaTime; 

            Player.transform.Translate(moveHorizontal, 0, moveVertical);

        //aparecer o cursor do mouse
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
            }

          //fazer o player correr
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerSpeed = 12;
            }

         //fazer player voltar ao seu estado normal de andar
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                playerSpeed = 7;
            }

        //caso o player pule, irá adicionar uma força
        else if (Input.GetButtonDown("Jump"))
        {
            moveJump = 4.5f;
            Player.AddForce(0, moveJump, 0,ForceMode.Impulse);
            
            
        }
     
    }



}
