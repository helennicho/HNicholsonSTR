using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class VidEffectsIntro : MonoBehaviour {

    // displys special effects such as game objects and particles on videos as they are playing;

    // needs to call parameters from VideoController or VideoURLController scrpits eg. VideoClipIndex and currentTime of video 

    public GameObject Obj1;
    public GameObject Obj2;
    public GameObject Obj3;
    public GameObject Obj4;
    public GameObject Obj5;
    private GameObject videoObject;
    public GameObject seagulls;
    public GameObject skeleton;

 
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

        switch (videoController.currentTime)
        {
            case 3:
                if (skeleton != null)
                {
                    skeleton.SetActive(true);
                }
                break;

            case 10:
                if (skeleton != null)
                {
                    skeleton.SetActive(false);
                }
                break;

            case 60:
                if (seagulls != null)
                {
                    seagulls.SetActive(true);
                }
                break;
            case 70:
                if (seagulls != null)
                {
                    seagulls.SetActive(false);
                }
                break;
        }
    }

        void setObjectActive()
        {
            if (videoObject != null) {
                videoObject.SetActive(true);       
            }
        }  

        void setObjectInactive()
        {
            if (videoObject != null){
                videoObject.SetActive(false);
            }
        }
       

}



