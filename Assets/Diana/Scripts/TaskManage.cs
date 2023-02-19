using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TaskManage : MonoBehaviour
{
    public PillowDetection pillow;
    public CakeDetection cake;
    public PictureDetection picture;
    public PenPosition pen;
    public AngleDetection water;
    public Pills pill;
    public bool test = false;
    public bool test1 = false;
    public GameObject nokiaAudio;
    public GameObject sonAudio;
    public GameObject hihoney;
    public bool firsttime = true;
    public bool everythingFinished = false;
    public bool readyToTravel = false;
    public Animator clockAnimation;
    public SceneTransitionManager sceneTransitionManager;
    public bool isSonCalling = false;
    public GameObject nokiaUI;



    [SerializeField] TMP_Text[] texts = new TMP_Text[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pen.penDown == true)
        {
            texts[0].fontStyle = FontStyles.Normal;
            texts[0].fontStyle = FontStyles.Strikethrough;
            Debug.Log("finisheWriting");
           // AudioPlay(nokiaAudio);
        }
        else
        {
            texts[0].fontStyle = FontStyles.Bold;
        }


        if (water.waterIsFinished == true)
        {
            texts[1].fontStyle = FontStyles.Normal;
            texts[1].fontStyle = FontStyles.Strikethrough;
        }
        else
        {
            texts[1].fontStyle = FontStyles.Bold;
        }


        if (pillow.pillowIsFinished == true )
        {
            texts[2].fontStyle = FontStyles.Normal;
            texts[2].fontStyle = FontStyles.Strikethrough;
        }
        else
        {
            texts[2].fontStyle = FontStyles.Bold;
        }

        if (picture.frameIsFinished == true)
        {
            texts[3].fontStyle = FontStyles.Normal;
            texts[3].fontStyle = FontStyles.Strikethrough;
        }
        else
        {
            texts[3].fontStyle = FontStyles.Bold;
        }

        if (pill.eatPill == true)
        {
            texts[4].fontStyle = FontStyles.Normal;
            texts[4].fontStyle = FontStyles.Strikethrough;
        }
        else
        {
            texts[4].fontStyle = FontStyles.Bold;
        }


        if (pillow.pillowIsFinished && cake.cakeIsFinished && picture.frameIsFinished && pen.penDown&& water.waterIsFinished && firsttime && pill.eatPill)
        {
            everythingFinished = true;
            Debug.Log("finished");
            nokiaAudio.SetActive(true);
            nokiaUI.SetActive(true);
            firsttime = false;
        }

        if (test == true)
        {
            Debug.Log("finished");
            nokiaAudio.SetActive(true);
        }
        if(test1 == true)
        {
            SonTalk();
        }




        if (sonAudio.GetComponent<AudioSource>().isPlaying == false && isSonCalling == true)
        {
            readyToTravel = true;
        }

        if (readyToTravel == true)
        {
            clockAnimation.SetBool("travelBackClock", true);
            sceneTransitionManager.GoToScene(2);
        }

    }

    public void SonTalk()
    {
        if (everythingFinished == true)
        {
            nokiaAudio.SetActive(false);
            sonAudio.SetActive(true);
            //AudioPlay(hihoney);
            hihoney.SetActive(true);
            isSonCalling = true;
        }
        

    }


    public void Travel()
    {
        readyToTravel = true;
    }


    public void AudioPlay(AudioSource audio)
    {

        if (audio.isPlaying == false)
        {
            audio.Play();
            Debug.Log("audio is playing");
          
        }
    }


    public void AudioStop(AudioSource audio)
    {

       // if (audio.isPlaying == true)
       // {
            audio.Stop();
            //Debug.Log("audio is playing");
       // }
    }

}
