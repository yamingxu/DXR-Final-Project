using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeTrigger : MonoBehaviour
{
    public WritingEffects writingeffects;
    private bool startWrite = true;
    public GameObject penOld;
    public GameObject penNew;
    public AudioSource writingSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pen" && startWrite)
        {
            writingeffects.BegintoWrite();
            Debug.Log("detected");
            startWrite = false;

            penOld.SetActive(false);
            penNew.SetActive(true);
        }
        //if (other.gameObject.tag == "WritingPen")
        //{
        //    writingSound.Play();
        //}
    }



    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "WritingPen")
    //    {
    //        writingSound.Stop();
    //    }
    //}
}
