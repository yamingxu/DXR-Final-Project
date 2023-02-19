using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAngle : MonoBehaviour
{
    public GameObject waterCan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 parentDirection = waterCan.transform.eulerAngles;
        Vector3 defaultDirection = new Vector3(0f, 1f, 0f);
        Vector3 waterAngle = Vector3.Scale(parentDirection, defaultDirection);
        Vector3 startingOrientation = new Vector3(0, -90, 0);
        transform.eulerAngles = waterAngle + startingOrientation;
       // Debug.Log(transform.eulerAngles);

    }
}
