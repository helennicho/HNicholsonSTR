using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

// VideoPlayer & Controls code from Unity/Tutorial
// https://unity3d.com/learn/tutorials/topics/graphics/playing-and-pausing

/*
// for non Gvr - Oculus etc
public class GvrPlayPauseURL : ShootableUI 
{
    // when button clicked then play or pause worldSpaceVideo function
    public override void ShotClick ()
    {
        worldSpaceVideo.PlayPause ();
    }
}
*/


// gvr script
public class GvrPlayPauseURL : MonoBehaviour
{
    public VideoURLController videoURLController;

    // when button clicked then play next video clip in  worldSpaceVideo function
    public void OnClick()

    {
        Debug.Log("in PlayButtonControlGvr - OnCLickNextVideoClip");
        videoURLController.PlayPause();
    }
}