using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowDetection : MonoBehaviour
{
    public GameObject[] pillows;
    public bool pillowIsFinished = false;
    public int pillowCount;
    public AudioSource movePillowSound;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pillow")
        {
            pillowCount += 1;
        }
        movePillowSound.Play();
            
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pillow")
        {
            pillowCount -= 1;
        }
    

    }


    private void Update()
    {
        if(pillowCount == pillows.Length){
            pillowIsFinished = true;
        }
        else
        {
            pillowIsFinished = false;
        }
    }
}
