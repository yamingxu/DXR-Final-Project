using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{

    private bool cakeGrab;

    //public AudioSource grandma;

    // Start is called before the first frame update
    void Start()
    {
        cakeGrab = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GrabCake()
    {
        cakeGrab = true;
    }

    public void CallPhone()
    {
        if (cakeGrab)
        {
            //grandma.Play();
        }
    }

}
