using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ChangeText : MonoBehaviour
{

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public GameObject obj;
    public GameObject frame2;
    public GameObject frame3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text1.text = obj.transform.eulerAngles.x.ToString();
        text2.text = obj.transform.eulerAngles.y.ToString();
        text3.text = obj.transform.eulerAngles.z.ToString();
    }
}
