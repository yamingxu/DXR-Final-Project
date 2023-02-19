using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTest : MonoBehaviour
{
    public SceneTransitionManager stm;
    public int sceneIndex;

    private void OnTriggerEnter(Collider other)
    {
        stm.GoToScene(sceneIndex);    
    }
}
