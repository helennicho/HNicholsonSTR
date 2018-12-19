

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// VideoPlayer & Controls code from Unity/Tutorial
// https://unity3d.com/learn/tutorials/topics/graphics/playing-and-pausing

/*
// for non Gvr - Oculus etc
public class PlaybuttonControl : ShootableUI 
{
    // when button clicked then play or pause worldSpaceVideo function
    public override void ShotClick ()
    {
        worldSpaceVideo.PlayPause ();
    }
}
*/


// gvr script
public class GvrPlayPause : MonoBehaviour
{
    public VideoController videoController;

    // when button clicked then play next video clip in  worldSpaceVideo function
    public void OnClickPlayPause()

    {
        Debug.Log("in PlayButtonControlGvr - OnCLickNextVideoClip");
        videoController.PlayPause();
    }
}