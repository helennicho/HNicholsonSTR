using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayEffect : MonoBehaviour {



    // displys special efects by activating game object 


    public GameObject playEffect;
    // need way of calculating current time in scene
    // use Time.timeSinceLeveLoad

    public int startTime;
    public int endTime;


   
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        // Debug.Log(Time.timeSinceLevelLoad);
        if (Time.timeSinceLevelLoad == startTime)
        {
            if (playEffect != null) { 
                playEffect.SetActive(true); 
            }
        }
        else if (Time.timeSinceLevelLoad == endTime)
        {
            if (playEffect != null)
            {
                playEffect.SetActive(false);
            }
        }

    }
}