
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoController: MonoBehaviour
{
    // VideoPlayer & Controls code from Unity/Tutorial
    // https://unity3d.com/learn/tutorials/topics/graphics/playing-and-pausing

    // inherits from PlayHeadMover.cs

    public Material playButtonMaterial;
    public Material pauseButtonMaterial;
    //public Renderer playButtonRenderer;

    // allow videos to be streamed - uses anindex array to allow an array of video clips to be set up
// controls for video player include play/pause, reset/restart, got to Home screen
// at end of video canvases are displayed to allow user choice of endings 
// co-routine set up to allow option of endings to be played without reloading a new scene

// technical
// need to set up a VideoClip else can't assign a VideoComponent to Play/Pause/Next control buttons and get error message on play

// as generalisation extension could set public string videoURL, URL2, URL£ to a string of arrays  (public string[] videoURL

    public VideoClip[] videoClips;
    private VideoPlayer videoPlayer;
    public int videoClipIndex;


    public int currentTime;
    private double fraction;
 

    // to improve mobile performance don't display current or total time of video clip

     public Text currentMinutes;
    public Text currentSeconds;
    public Text totalMinutes;
    public Text totalSeconds;


   public GameObject LoadingObject;
  

    public GameObject Ending1hotspot;
    public GameObject Ending2hotspot;
    public GameObject Ending1FF;
    public GameObject Ending2FF;

    // to improve mobile performance don't display video  playhead
    public PlayHeadMover playHeadMover;

    // declare assets used in video effects
    public GameObject skeleton;


    void Awake()
    {
        // place to put get components clauses
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Use this for initialization
    void Start()
    {
        if (LoadingObject != null) { LoadingObject.SetActive(true); };
        Debug.Log("in VideoController  ");
        // makes sure last frame of last video doesn’t hang about when switching to next video clip
        videoPlayer.targetTexture.Release();

        videoPlayer.clip = videoClips[0];
        videoClipIndex = 0;
        SetTotalTimeUI();
    }

    // Update is called once per frame
    void Update()
    {

        // settings for video pause and play
        if (videoPlayer.isPlaying)
        {
            SetCurrentTimeUI();

            // https://unity3d.com/learn/tutorials/topics/graphics/playing-and-pausing
            playHeadMover.MovePlayhead(CalculatePlayedFraction());

            // once video is loading stop displaying "Loading" object
            if ((LoadingObject != null) && (currentTime == 1))
            {

                LoadingObject.SetActive(false);
            }

            //at end of each video set different UI canvases giving user options to play next video depending on storyline
            //can do by fixed time in video or more generically by % of  video played

            if (currentTime == 106)
            {
            fraction = CalculatePlayedFraction();
                Debug.Log("fraction of video played = " + fraction);
            }

           
            if (fraction == 0.95)
            {

                switch (videoClipIndex)
                {
                    case 0:
                        // at end of intro allow user to choose between 2 endings
                        Ending1hotspot.SetActive(true);
                        Ending2hotspot.SetActive(true);

                        // method 2 using instantiate
                        //GameObject Ending1 = Instantiate(Ending1hotspot);
                        //GameObject Ending2 = Instantiate(Ending2hotspot);

                        break;
                    case 1:
                        // at end of ending 1 allow user to go to ending 2
                        Ending1hotspot.SetActive(true);
                        Ending2hotspot.SetActive(true);
                        break;

                    case 2:
                        // at end of ending 1 allow user to go to ending 1
                        Ending1hotspot.SetActive(true);
                        Ending2hotspot.SetActive(true);
                        break;

                    default:
                        break;
                }
            }

            // NB could control display special effects for each video in separate script VideoEffects.cs- call compnents from this script in VideoEffects.cs using parameters VideoIndex and CurrentTime
            //videoEffects.SpecialEffects();
        }

    }


    public void SetNextClip()
    {
        videoClipIndex++;

        // if trying to access a clip greater than clip array then loop

        if (videoClipIndex >= videoClips.Length)
        {
            videoClipIndex = videoClipIndex % videoClips.Length;
        }
       
        videoPlayer.clip = videoClips[videoClipIndex];

        SetTotalTimeUI();
        videoPlayer.Play();

    }

    public void PlayPause()
    {
        
        Debug.Log("in WorldSpaceVideoIntro - PlayPause");
        {

            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
                //playButtonRenderer.material = playButtonMaterial;
            }
            else
            {
                videoPlayer.Play();
                SetTotalTimeUI();
            }
            //playButtonRenderer.material = pauseButtonMaterial;
        }
    }

    public void OnRestart()
    {
        videoPlayer.frame = 0;
        SetTotalTimeUI();
        videoPlayer.Play();

    }

  


    // to play ending option 1

    public void PlayEnding1()
    {
        videoClipIndex = 1;

        // if trying to access a clip greater than clip array then loop

        if (videoClipIndex >= videoClips.Length)
        {
            videoClipIndex = videoClipIndex % videoClips.Length;
        }

        videoPlayer.clip = videoClips[videoClipIndex];

        SetTotalTimeUI();

        // set active UI's
        Ending1hotspot.SetActive(false);
        Ending2hotspot.SetActive(false);
        Ending1FF.SetActive(true);
        Ending2FF.SetActive(true);

        videoPlayer.Play();

    }


    // to play ending option 2

    public void PlayEnding2()
    {
        videoClipIndex = 2;

        // if trying to access a clip greater than clip array then loop

        if (videoClipIndex >= videoClips.Length)
        {
            videoClipIndex = videoClipIndex % videoClips.Length;
        }

        videoPlayer.clip = videoClips[videoClipIndex];

        SetTotalTimeUI();

        // set active UI's
        Ending1hotspot.SetActive(false);
        Ending2hotspot.SetActive(false);
        Ending1FF.SetActive(true);
        Ending2FF.SetActive(true);
        videoPlayer.Play();

    }



    void SetCurrentTimeUI()
    {
        currentTime = (int)videoPlayer.time;
      Debug.Log("SetCurrentTime" + currentTime);
        string minutes = Mathf.Floor((int)videoPlayer.time / 60).ToString("00");
        string seconds = ((int)videoPlayer.time % 60).ToString("00");

         currentMinutes.text = minutes;
         currentSeconds.text = seconds;
    }

    void SetTotalTimeUI()
    {
      //  Debug.Log("Total time video" + videoPlayer.clip.length);
        string minutes = Mathf.Floor((int)videoPlayer.clip.length / 60).ToString("00");
        string seconds = ((int)videoPlayer.clip.length % 60).ToString("00");

       totalMinutes.text = minutes;totalSeconds.text = seconds;
    }

    double CalculatePlayedFraction()
    {
        double fraction = (double)videoPlayer.frame / (double)videoPlayer.clip.frameCount;
        return fraction;
    }


   
}