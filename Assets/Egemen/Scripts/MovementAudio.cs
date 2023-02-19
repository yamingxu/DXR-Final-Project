using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAudio : MonoBehaviour
{
    public float threshold = 1f;

    public AudioSource audioSource;

    private Rigidbody rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigidbody.velocity.magnitude >= threshold)
        {
            audioSource.Play();
        }
    }

    public void UpdateMoved(bool val)
    {
    }

}
