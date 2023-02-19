using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVSwitch : MonoBehaviour
{
    private MeshRenderer tvPlane;


    // Start is called before the first frame update
    void Start()
    {
        tvPlane = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void switchTv()
    {
        tvPlane.enabled = !tvPlane.enabled;

    }
}
