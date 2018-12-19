using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// VideoPlayer & Controls code from Unity/Tutorial
// https://unity3d.com/learn/tutorials/topics/graphics/playing-and-pausing

public abstract class ShootableUI : MonoBehaviour
{
    // sets up object as a shootable (clickable UI  )
    //public VideoController videoController;

    public abstract void ShotClick();
}

