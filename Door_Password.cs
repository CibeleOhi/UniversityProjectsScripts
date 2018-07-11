using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door_Password : MonoBehaviour
{
    public static string correctCode= "2502";
    public static string typedCode = "";
    public static int maxNumber = 0;
    public GameObject doorOpen;
    public GameObject correctText;
    public Text textCode;
    public GameObject lightRED;
    public GameObject lightGREEN;
    public GameObject player;
    public static bool gotgun;
    public void Start()
    {
        correctText.SetActive(false);
        doorOpen.GetComponent<AudioSource>().enabled = false;
        doorOpen.GetComponent<Open_Door>().enabled = false;
        doorOpen.GetComponent<Animator>().enabled = false;
    }
    public void Update()
    {
        if (maxNumber < 4)
        {
            Teclas();

            
        }

        if (maxNumber == 4)
        {
            if (correctCode == textCode.text)
            {
                doorOpen.GetComponent<AudioSource>().enabled = true;
                doorOpen.GetComponent<Open_Door>().enabled = true;
                doorOpen.GetComponent<Animator>().enabled = true;
                correctText.SetActive(true);
                lightRED.SetActive(false);
                lightGREEN.SetActive(true);
                
                textCode.text = "";
                
                
            }

            else
            {

                EraseString();
            }
        }


    }

    public void Teclas()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            textCode.text += 0;
            maxNumber += 1;
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            textCode.text+= "1";
            maxNumber ++;
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            textCode.text += "2";
            maxNumber ++;
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            textCode.text += "3";
            maxNumber ++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            textCode.text += "4";
            maxNumber ++;
        }

        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            textCode.text += "5";
            maxNumber ++;
        }

        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            textCode.text += "6";
            maxNumber ++;
        }

        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            textCode.text += 7;
            maxNumber ++;
        }

        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            textCode.text += 7;
            maxNumber ++;
        }

        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            textCode.text += 9;
            maxNumber ++;
        }
    }

public void ClickNumber (string numberClicked)
    {
        textCode.text += numberClicked;
        maxNumber++;
    }
    
    public void EraseString()
    {
        textCode.text = "";
        maxNumber = 0;
    }

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = !enabled;
    }

    public void ActiveFire()
    {
        if (StaticValues.activeGun==true)
        {
            player.GetComponent<Fire>().enabled = true;
        }
        
    }
}

