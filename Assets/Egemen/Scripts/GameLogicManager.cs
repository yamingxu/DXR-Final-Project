using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameLogicManager : MonoBehaviour
{
    private bool battery1In, battery2In, clockIn, pieIn, ovenStart = false;

    public SceneTransitionManager sceneTransitionManager;

    public GameObject clockGuide;

    public Animator clockBottomAnimator;

    public AudioSource clockStart;

    public UnityEvent onBatteriesIn;


    // Start is called before the first frame update
    void Start()
    {
        clockGuide.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ovenStart & battery1In & battery2In)
        {
            clockGuide.SetActive(true);
        }
        if (clockIn & ovenStart)
        {
            sceneTransitionManager.GoToScene(1);
        }
    }

    public void PieIn(bool value)
    {
        pieIn = value;
    }

    public void OvenStart(bool value)
    {
        if (pieIn)
        {
            ovenStart = value;
        }
    }

    private void StartClock()
    {
        clockStart.Play();
        clockBottomAnimator.SetTrigger("ClockMove");
        onBatteriesIn.Invoke();

    }

    public void Battery1In(bool value)
    {
        battery1In = value;
        if (value & battery2In)
        {
            StartClock();
        }
    }

    public void Battery2In(bool value)
    {
        battery2In = value;

        if (value & battery1In)
        {
            StartClock();
        }
    }

    public void ClockIn()
    {
        if (battery1In & battery2In)
        {
            clockIn = true;
        } else
        {
            clockIn = false;
        }
    }

}
