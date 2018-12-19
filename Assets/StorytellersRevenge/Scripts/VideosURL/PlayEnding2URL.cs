﻿


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// VideoPlayer & Controls code from Unity/Tutorial
// https://unity3d.com/learn/tutorials/topics/graphics/playing-and-pausing

/* For Oculus
// first person shooter script
// inherits from shootableUI

public class PlayEnding2 : ShootableUI 
{
    public override void ShotClick ()
    {
        worldSpaceVideo.SetNextClip ();
    }
} 
*/


// gvr script
public class PlayEnding2URL : MonoBehaviour
{
    // reference VideoURLController script on VideoPlayer (drag VideoPlayer from Hierarchy)
    public VideoURLController videoControl;
  

    // when button clicked then play next video clip in  worldSpaceVideo function
    public void OnClick()
    {
        Debug.Log("in PlayEnding2 / OnClick");
        videoControl.PlayEnding2();
    }
}