
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// VideoPlayer & Controls code from Unity/Tutorial
// https://unity3d.com/learn/tutorials/topics/graphics/playing-and-pausing


//Calculate fraction of clip that has been played as part of total length of video clip

public class PlayHeadMover : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public void MovePlayhead(double playedFraction)
    {
        //  move playhead from start to end point
        //Debug.Log ("in PlayHeadMover / MovePlayhead");
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, (float)playedFraction);
    }
}

