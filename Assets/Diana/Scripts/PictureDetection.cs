using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureDetection : MonoBehaviour
{
    public GameObject[] frames;
    public bool[] frameCounts;
    public bool frameIsFinished = false;
    public int frameCount = 0;
    public bool frameIsBack = false;

    void Update()
    {
        for(int i = 0; i < frames.Length; i++)
        {
            //FramePicCount(i);
            if (frameCounts[i] == true)
            {
                frameCount += 1;
            }
        }
        //foreach (GameObject frame in frames)
        //{
        //    if (frame.transform.eulerAngles.x == 0 || frame.transform.eulerAngles.x == 360)
        //    {
        //        frameCount += 1;
        //    }
        //}

        if(frameCount == frames.Length)
        {
            frameIsFinished = true;
        }
        else
        {
            frameIsFinished = false;
        }

        frameCount = 0;
        Debug.Log(frameCount);
    }

    public void FramePicCount(int frame)
    {
        frameCounts[frame] = true;
        
    }
}
