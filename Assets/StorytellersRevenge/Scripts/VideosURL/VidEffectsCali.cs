using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidEffectsCali : MonoBehaviour {


    // displys special effects such as game objects and particles on videos as they are playing;

    // needs to call parameters from VideoController or VideoURLController scrpits eg. VideoClipIndex and currentTime of video 

    public GameObject skeleton;
    public GameObject seagulls;


    // if streaming videos from dropbox use VideoURLController
    // if accessing videos using array - and videos in Assets use VideoController

    private VideoURLController videoController;
    // private VideoController videoController

    // Use this for initialization
    void Start()
    {
        // gets components (parameters etc.) from script
        videoController = GetComponent<VideoURLController>();
    }

    // Update is called once per frame
    void Update()
    {

        // Video1 : Intro - BlueWaters Pirate ship
        // display skeleton in required position on pirate boat from 6 to 17 frames
        if ((skeleton != null) && (videoController.currentTime == 3))
        {
            skeleton.SetActive(true);
        }
        else if ((skeleton != null) && (videoController.currentTime == 10))
        {
            skeleton.SetActive(false);
        }
        if ((seagulls != null) && (videoController.currentTime == 60))
        {
            seagulls.SetActive(true);
        }
        else if ((seagulls != null) && (videoController.currentTime == 70))
        {
            seagulls.SetActive(false);
        }
    }

    // Method : using instantiate
    // clone skeleton - else when destory the gameObject in Project will be destroyed
    /*
         GameObject p = Instantiate(skeleton) as GameObject; 
         // destroy object didn't work ref : https://stackoverflow.com/questions/23971931/unity-destroy-gameobject-instantiated-clone

         // destroy instantiated object after 5f secs
         Destroy(p, 5f);
         //Destroy(Instantiate(skeleton.gameObject), 5f);
     */




}




