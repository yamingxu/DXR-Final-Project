using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleDetection : MonoBehaviour
{
    public bool tilt = true;
    public bool theRightPlant = false;
    public GameObject water;
    public bool waterIsFinished = false;
    public int turningAngle;
    
   
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("x: " + gameObject.transform.rotation.x);
        if(gameObject.transform.eulerAngles.z > turningAngle && gameObject.transform.eulerAngles.z < 270)
        {
            water.SetActive(true);
            tilt = true;
            
        }
        else
        {
            water.SetActive(false);
            tilt = false;
        }

        if(theRightPlant && tilt)
        {
            waterIsFinished = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Plant")
        {
            theRightPlant = true;
        }
    }
}
