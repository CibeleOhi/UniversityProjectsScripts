using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour {
    public Image life;
    public Image contamination;
    public GameObject youdied;
    public AudioSource ouch;
    public AudioClip[] ouchSounds;
    public static bool atacou;

    public void Start()
    {
        atacou = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "enemy1"&&atacou==false)
        {
            DamageSounds(0);
            life.fillAmount -= 0.2f;
            
        }


        if (collision.gameObject.tag == "Contamination"&&atacou==false)
        {
            DamageSounds(1);
            contamination.fillAmount +=0.1f;
            
        }

        if (collision.gameObject.tag == "enemy2"&&atacou==false)
        {
            DamageSounds(0);
            life.fillAmount -= 0.2f;
            contamination.fillAmount += 0.3f;
        }

        if (collision.gameObject.tag == "enemy3"&&atacou==false)
        {
            life.fillAmount -= 0.3f;
            contamination.fillAmount += 0.3f;
        }

        //if (collision.gameObject.name == "parasiteZombie")
        //{
        //    DamageSounds(0);
        //    life.fillAmount -= 0.5f;
        //    contamination.fillAmount += 0.5f;
        //}
    }

    public IEnumerator EsperaDano()
    {
        while (atacou == true)
        {
            yield return new WaitForSeconds(3);
            atacou = false;
        }
    }

    public void Update()
    {
        if (life.fillAmount == 0)
        {
            youdied.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = enabled;
        }

        if (contamination.fillAmount == 1)
        {
            youdied.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = enabled;
        }
    }


    public void Restart()
    {
        if (youdied == true)
        {
            life.fillAmount = 1;
            contamination.fillAmount = 0;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible =! enabled;
            youdied.SetActive(false);
        }
    }

    public void DamageSounds(int index)
    {
        ouch.clip = ouchSounds[index];
        ouch.PlayOneShot(ouch.clip);
    }
}
