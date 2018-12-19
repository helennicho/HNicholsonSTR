using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// VideoPlayer & Controls code from Unity/Tutorial
// https://unity3d.com/learn/tutorials/topics/graphics/playing-and-pausing


public class PlayButtonControl : ShootableUI
{
    public VideoController videoController;

    public override void ShotClick()
    {
        videoController.PlayPause();
    }
}