using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayEnding1 : MonoBehaviour
{
    // reference VideoController script on VideoPlayer (drag VideoPlayer from Hierarchy)
    public VideoController videoControl;
 


    // when button clicked then play next video clip in  worldSpaceVideo function
    public void OnClick()
    {
        Debug.Log("in PlayEnding1 / OnClick");
        videoControl.PlayEnding1();
    }
}