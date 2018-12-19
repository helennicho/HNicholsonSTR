
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// first person shooter script
// inherits from shootableUI

// VideoPlayer & Controls code from Unity/Tutorial
    // https://unity3d.com/learn/tutorials/topics/graphics/playing-and-pausing


public class NextButtonControl : MonoBehaviour
{
    public VideoController videoControl;

    public void OnClick()
    {
        videoControl.SetNextClip();
    }
}



// gvr script
/*
public class NextButtonControlGvr : MonoBehaviour
{
    public WorldSpaceVideo worldSpaceVideo;

    // when button clicked then play next video clip in  worldSpaceVideo function
    public void OnClickPlayPause()
    {
        VideoController.SetNextClip ();
    }
}
*/
