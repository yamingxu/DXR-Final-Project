using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSwitch : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchRadio()
    {
        audioSource.enabled = !audioSource.enabled;
    }

}
