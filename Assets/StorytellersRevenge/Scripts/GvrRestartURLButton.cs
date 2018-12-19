
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// VideoPlayer & Controls code from Unity/Tutorial
// https://unity3d.com/learn/tutorials/topics/graphics/playing-and-pausing

/* For Oculus
// first person shooter script
// inherits from shootableUI

// VideoPlayer & Controls code from Unity/Tutorial
    // https://unity3d.com/learn/tutorials/topics/graphics/playing-and-pausing


public class NextButtonControl : ShootableUI
{
    public override void ShotClick()
    {
        videoControllerURL.SetNextClip();
    }
}
*/


// gvr script
  
public class GvrRestartURLButton : MonoBehaviour
{
    public VideoURLController videoControllerURL;
   
   // could just reload whole scene for restart as not sure can go tback to 1st frame on streamed video from URL
    /*
     public void OnClick()
    {
        Debug.Log(" In GvrRestartURL/ OnClick");
        GoToScene();
    }

    void GoToScene()
    {
        Debug.Log("in GvrRestartURL /GotToScene ");
        SceneManager.LoadScene("VideoSphereBlueIntro");
    }
*/


    // when button clicked then play next video clip in  worldSpaceVideo function
    public void OnClick()
    {
        videoControllerURL.OnRestart();
    }

}
