using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pills : MonoBehaviour
{
    public GameObject pill;
    public bool eatPill = false;
    public AudioSource eatPillSound;

    public void PillShowUp()
    {
        pill.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pill")
        {
            eatPill = true;
            eatPillSound.Play();
            Destroy(pill);
        }
       
    }
}
