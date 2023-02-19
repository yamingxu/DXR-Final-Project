using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ToDoListManager : MonoBehaviour
{
    public bool[] tasks = new bool[4];
    //public GameObject[] todos = new GameObject[4];
    [SerializeField] TMP_Text[] texts = new TMP_Text[4];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < tasks.Length; i++)
        {
            if(tasks[i] == true)
            {
                texts[i].fontStyle = FontStyles.Strikethrough;
            }
            else
            {
                texts[i].fontStyle = FontStyles.Normal;
            }
        }
    }
}
