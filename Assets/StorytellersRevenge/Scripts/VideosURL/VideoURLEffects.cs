using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoURLEffects : MonoBehaviour
{

    // displys special effects such as game objects and particles on videos as they are playing;

    // needs to receive 2 arguments from VideoController or VideoURLController - VideoClipIndex and currentTime of video being played

    public GameObject skeleton;

    // declares call VideoController script to get compnents for VideoClipIndex and Current time being played 
    private VideoController videoController;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpecialEffects()
    {
        // gets components (parameters etc.) from script
        videoController = GetComponent<VideoController>();

        switch (videoController.videoClipIndex)
        {
            case 0:
                // Video1 : Intro - BlueWaters Pirate ship
                // display skeleton in required position on pirate boat from 6 to 17 frames
                if ((skeleton != null) && (videoController.currentTime == 6))
                {
                    skeleton.SetActive(true);
                }
                else if ((skeleton != null) && (videoController.currentTime == 17))
                {
                    skeleton.SetActive(false);
                }
                break;

            // Method : using instantiate
            // clone skeleton - else when destory the gameObject in Project will be destroyed
            /*
                 GameObject p = Instantiate(skeleton) as GameObject; 
                 // destroy object didn't work ref : https://stackoverflow.com/questions/23971931/unity-destroy-gameobject-instantiated-clone

                 // destroy instantiated object after 5f secs
                 Destroy(p, 5f);
                 //Destroy(Instantiate(skeleton.gameObject), 5f);
             */

            case 1:
                // Video 2 : Ending 1 special & interactive  effects

                break;
            case 2:
                // Video 3 : Ending 2 special & interactive effects
                break;

        }
    }
}

