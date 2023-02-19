using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PenPosition : MonoBehaviour
{
   // [SerializeField] TextMeshProUGUI dialogText;
    public Transform startingPos;
    public float xDis = 0f;
    public float yDis = 0f;
    public float zDis = 0f;
    Vector3 newPos;
    Vector3 prePos;
    public int countTextX = 0;
    public int countTextY = 0;
    public bool penDown = false;
    WritingEffects we;
    public GameObject recipeWord;
    TextMeshProUGUI writingProcess;
    public AudioSource pendrop;
    public AudioSource penWrittngSound;
    private bool penIsDown = true;
    private bool penIsWriting = false;
    
    
    void Start()
    {
        prePos = startingPos.position;
      
        
    }

    void Update()
    {

        writingProcess = recipeWord.GetComponent<WritingEffects>().dialogText;

        foreach (var letter in writingProcess.text.ToCharArray())
        {
            countTextX += 1;

            if (letter == 50) //ASCII code of first letter
            {
                penIsWriting = true;
            }

            if (letter == 10) //ASCII code of next line
            {
                //  Debug.Log("new line");
                countTextY += 1;
                countTextX = 0;
            }
            if (letter == 46) //ASCII code of .
            {
                penDown = true;
            }
            else
            {
                penDown = false;
            }
        }


        if (penIsWriting == true && penWrittngSound.isPlaying == false)
        {
            penWrittngSound.Play();
            penIsWriting = false;
        }

        if (penDown == true)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            penWrittngSound.Stop();
            if (pendrop.isPlaying == false && penIsDown == true)
            {
                
                pendrop.Play();
                penIsDown = false;
            }
            
        }
        else
        {
            newPos = new Vector3(xDis * countTextX, 0f, zDis * countTextY);
            gameObject.transform.position = prePos + newPos;
           

        }

        countTextX = 0;
        countTextY = 0;
    }
}
