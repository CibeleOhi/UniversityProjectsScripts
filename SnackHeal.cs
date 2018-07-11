using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnackHeal : MonoBehaviour {

    public GameObject message;
    private bool Epressed;
    public Image life;
    public static int healNumberSnack;
    public GameObject snack;
    public AudioSource healSnack;
    public AudioClip[] soundSnack;

    public void Start()
    {
        Epressed = false;
        healNumberSnack = 0;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Epressed = true;
        }
        else Epressed = false;

        if (healNumberSnack == 3)
        {
    
            snack.GetComponent<SnackHeal>().enabled = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (healNumberSnack == 3)
            {
                message.SetActive(false);
            }

            else
            {
            message.SetActive(true);
             PlaySounds(0);
            }

        }

    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Epressed == true)
            {
                Epressed = false;
                message.SetActive(false);
                PlaySounds(1);
                life.fillAmount += 0.2f;
                healNumberSnack++;
                
            }
        }


    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            message.SetActive(false);
            Epressed = false;
        }

    }

    public void PlaySounds(int index)
    {
        healSnack.clip = soundSnack[index];
        healSnack.PlayOneShot(healSnack.clip);
    }
}
