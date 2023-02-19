using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeDetection : MonoBehaviour
{
    public bool cakeIsFinished = false;
    public AudioSource CakeAlert;
    public bool doorOpen = false;
    public GameObject ovenLight;
    public GameObject normalHandle;
    public GameObject glowHandle;



    private void Update()
    {
        if (doorOpen)
        {
            CakeAlert.Stop();
        }
        else
        {
            if (cakeIsFinished == false && CakeAlert.isPlaying == false)
            {
                CakeAlert.Play();
            }
        }

    }

    public void DoorOpen()
    {
        doorOpen = true;
    }

    public void DoorClose()
    {
        doorOpen = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Cake")
        {
            cakeIsFinished = false;
        } // cake is in the oven


    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cake")
        {
            cakeIsFinished = true;
            CakeAlert.Stop();
            ovenLight.SetActive(false);
            glowHandle.SetActive(false);
            normalHandle.SetActive(true);
        }// cake is taken outside

    }

}
