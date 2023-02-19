using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private Light lightObj;

    // Start is called before the first frame update
    void Start()
    {
        lightObj = gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void switchLight()
    {
        lightObj.enabled = !lightObj.isActiveAndEnabled;

    }
}
