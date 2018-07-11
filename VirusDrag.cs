using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusDrag : MonoBehaviour {
    public float distance;
    public Camera cam;
    public GameObject virus;
    public GameObject gotVirus;
    public GameObject pressEmessage;
    public GameObject doorOpen2;
 //   public GameObject congratsCanvas;

    public void Start()
    {
        virus.GetComponent<Rigidbody>().isKinematic = true;
        doorOpen2.GetComponent<AudioSource>().enabled = false;
        doorOpen2.GetComponent<Open_Door>().enabled = false;
        doorOpen2.GetComponent<Animator>().enabled = false;
    }
    public void OnMouseDrag()
    {
        virus.GetComponent<Animator>().enabled = false;
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 virusPos = cam.ScreenToWorldPoint (mousePos);
        virus. transform.position =virusPos ;
        virus.GetComponent<Rigidbody>().isKinematic = false;

     }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gotVirus.SetActive(true);
            pressEmessage.SetActive(true);


        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                virus.SetActive(false);
                pressEmessage.SetActive(false);
                doorOpen2.GetComponent<AudioSource>().enabled = true;
                doorOpen2.GetComponent<Open_Door>().enabled = true;
                doorOpen2.GetComponent<Animator>().enabled = true;

            }
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (virus == false)
            {
                gotVirus.SetActive(false);
            }
        }

    }

}


