


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoURLController : MonoBehaviour
{
    // Video Player & Controls code from Unity/Tutorial
    // https://unity3d.com/learn/tutorials/topics/graphics/playing-and-pausing

    // inherits from PlayHeadMover.cs

    public Material playButtonMaterial;
    public Material pauseButtonMaterial;

    //public Renderer playButtonRenderer;

    // allow videos to be streamed from a URL link to dropbox
    // controls for video player include play/pause, reset/restart, got to Home screen
    // at end of video canvases are displayed to allow user choice of endings 
    // in video component in Indspector leave URL empty as this is handled in this script
    // co-routine set up to allow option of endings to be played without reloading a new scene
    // technical
    // need to set up a VideoClip else can't assign a VideoComponent to Play/Pause/Next control buttons and get error message on play
    // leave VideoClip element on WorldSpaceVideoIntroURL that is assigned to VideoPlayer game object empty though
    // as generalisation extension could set public string videoURL, URL2, URL£ to a string of arrays  (public string[] videoURL

   // public VideoClip videoClip;
    public VideoPlayer videoPlayer;

    // in VideoCompnent set  videoURL string to same as used in VideoPlayer/Source/URL component of VideoPlayer game object
    // note - can set 
    public string videoURL0;   // URL for ipart 1 of video (intro)
    public string videoURL1;   // URL for ending 1
    public string videoURL2;   // URL for ending 2

    // assign intro as video 0, ending 1 as video index 1 and ending 2 as video index 2
    public int videoClipIndex;

    // for streaming videos need to use different method for calculating frames in video
    // need var currentTime in VideoEffects.cs so set as public
    public int currentTime;
    private double fraction;

    // to improve mobile performance don't display current or total time of video clip
    /*
     public Text currentMinutes;
    public Text currentSeconds;
    public Text totalMinutes;
    public Text totalSeconds;
*/

    public GameObject LoadingObject;

    public GameObject Ending1hotspot;
    public GameObject Ending2hotspot;
    public GameObject Ending1FF;
    public GameObject Ending2FF;

    // to improve mobile performance don't display video  playhead
    // playhead function is public function used to move plyahead for required fraction along progress bar
    //public PlayHeadMover playHeadMover;




    void Awake()
    {
        // place to put get components clauses
        videoPlayer = GetComponent<VideoPlayer>();

    }

    // Use this for initialization
    void Start()
    {
        if (LoadingObject != null) { LoadingObject.SetActive(true); };
        //Debug.Log("in WorldSpaceVideoIntroURL  start() ");
        // makes sure last frame of last video doesn’t hang about when switching to next video clip
        videoPlayer.targetTexture.Release();
     
        Debug.Log("video URL" + videoURL0);
       // seem to need to set this up for play/pause to work
       // videoPlayer.clip = videoClips[0];

        switch (videoClipIndex)
        {
            case 0:
                videoPlayer.url = videoURL0;
                break;
            case 1:
                videoPlayer.url = videoURL1;
                break;
            case 2:
                videoPlayer.url = videoURL2;
                break;
        }

        Ending1hotspot.SetActive(false);
        Ending2hotspot.SetActive(false);
        //SetTotalTimeUI();
      
    }

    // Update is called once per frame
    void Update()
    {

        // settings for video pause and play
        if (videoPlayer.isPlaying){
            //SetCurrentTimeUI();
            currentTime = (int)videoPlayer.time;

            // https://unity3d.com/learn/tutorials/topics/graphics/playing-and-pausing
            // ????can't calculate total length of video that is being streamed from URL
            // playHeadMover.MovePlayhead(CalculatePlayedFraction());

            // if the first part of the video is playing
            if ((LoadingObject != null) && ( (int)videoPlayer.time == 1))
            {
                //Debug.Log("LoadingObject  time = " + (int)videoPlayer.time);
                LoadingObject.SetActive(false);
            }

            // video effects for each video clip controlled in VideoEffects.cs or VideoEffectsIntro.cs etc

           
            // set endings canvases for videos
         

             switch (videoClipIndex)
             {
                    case 0:
                    
                    if ( (int)videoPlayer.time == 60)// at end of intro allow user to choose between 2 endings
                    {
                        //Debug.Log("EndSpot - time = " + (int)videoPlayer.time);
                        Ending1hotspot.SetActive(true);
                        Ending2hotspot.SetActive(true);

                        // method 2 using instantiate
                        //GameObject Ending1 = Instantiate(Ending1hotspot);
                        //GameObject Ending2 = Instantiate(Ending2hotspot);

                        // Video1 : Intro - BlueWaters Pirate ship
                        // display skeleton in required position on pirate boat from 6 to 17 frames
                        // or could tryputting special effects in to VideoEffects.cs
                    }

                        break;
                    case 1:
                        // at end of ending 1 allow user to go to ending 2
                        //Ending1hotspot.SetActive(true);
                        //Ending2hotspot.SetActive(true);
                        break;

                    case 2:
                        // at end of ending 1 allow user to go to ending 1
                        //Ending1hotspot.SetActive(true);
                        //Ending2hotspot.SetActive(true);
                        break;
                }




        }
    }


    public void PlayPause()
    {
        Debug.Log("in WorldSpaceVideoIntroURL - PlayPause");

        // this was atempt to get over having to set up video array of at least 1 for play/pause to work/*if (!videoPlayer)
        /*
         {
            Debug.Log("video URL" + videoURL);
            videoPlayer = GetComponent<VideoPlayer>();
            // ?? videoPlayer = FindObjectOfType<VideoPlayer>();
        }
        */
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            // playButtonRenderer.material = playButtonMaterial;
        }
        else
        {
            videoPlayer.Play();


            // ???? need different way to calculate total length of video that is being streamed from URL
            //SetTotalTimeUI();


            // playButtonRenderer.material = pauseButtonMaterial;
        }
    }

    // NB>  when streaming from URL - maybe best to reload video scene  as a diff scene rather than reset play head

     public void OnRestart()
    {
        videoPlayer.frame = 0;
        // ????can't calculate total length of video that is being streamed from URL
        //SetTotalTimeUI();
        videoPlayer.Play();

    }


  // to stream video for ending option 1
    // maybe best to load up ending as new scene using goto diff scene
    public void PlayEnding1()
    {
        //could hard code video link in
        //videoPlayer.url = "https://www.dropbox.com/s/whgwv1zzvkb5ime/NewportCoastDuffyBoat.mp4?dl=1";

        /* not used for streaming video from URL
         * videoClipIndex = 1;
        // if trying to access a clip greater than clip array then loop
        if (videoClipIndex >= videoClips.Length)
        {
            videoClipIndex = videoClipIndex % videoClips.Length;
        }
        videoPlayer.clip = videoClips[videoClipIndex];
        */
       
        videoClipIndex = 1;
        videoPlayer.url = videoURL1;
        // ???? calculate total length of video that is being streamed from URL
        SetTotalTimeUI();

        Ending1hotspot.SetActive(false);
        Ending2hotspot.SetActive(false);
        Ending1FF.SetActive(true);
        Ending2FF.SetActive(true);
        videoPlayer.Play();

    }


   
    // to stream video for ending option 2
    // maybe best to load up ending as new scene using goto diff scene
    public void PlayEnding2()
    {
        //could hard code video link in
        //videoPlayer.url = "https://www.dropbox.com/s/nz5h7v1lljlaxxt/BlueWaterStaycation_1.mp4?dl=1";


        /* not used for streaming video from URL
         
        // if trying to access a clip greater than clip array then loop
        if (videoClipIndex >= videoClips.Length)
        {
            videoClipIndex = videoClipIndex % videoClips.Length;
        }
        videoPlayer.clip = videoClips[videoClipIndex];
        */

        videoClipIndex = 2;
        videoPlayer.url = videoURL2;
        // ????calculate total length of video that is being streamed from URL
        SetTotalTimeUI();
        Ending1hotspot.SetActive(false);
        Ending2hotspot.SetActive(false);
        Ending1FF.SetActive(true);
        Ending2FF.SetActive(true);
        videoPlayer.Play();

    }






    /*
     public void PlayVideo()
     {
             videoPlayer.Play();
     }

     public void Pausevideo()
     {

         //?? videoPlayer.Pause();
         videoPlayer.Stop();

     }
     */


    void SetCurrentTimeUI()
    {
        
        currentTime = (int)videoPlayer.time;
        //Debug.Log ("SetCurrentTime" + currentTime);

        string minutes = Mathf.Floor((int)videoPlayer.time / 60).ToString("00");
        string seconds = ((int)videoPlayer.time % 60).ToString("00");

        // not used to improve mobileperformance
       // currentMinutes.text = minutes;
        //currentSeconds.text = seconds;
    }

    // ?? when streaming from video might need to set a double var as  videoLength and hard code into script instead of VideoPlayer.clip.length

     
    void SetTotalTimeUI()
    {
        // ????calculate total length of video that is being streamed from URL use frameCount instead of videoPlayer.clip.length for stramed video
        // ?? not sure any of this is working but not needed fo StoryTellers Revenge - just nice to have for Capstone Project
        var videoLength = (double)videoPlayer.frameCount;
        double duration = videoPlayer.frameCount / videoPlayer.frameRate;
       // Debug.Log("SetTotalTimeUI " + duration);
       // Debug.Log("video length  " + videoLength);


        string minutes = Mathf.Floor((int)videoLength / 60).ToString("00");
        string seconds = ((int)videoLength % 60).ToString("00");

        // to improve mobile performance displaying length of video not used
        /*
        totalMinutes.text = minutes;
        totalSeconds.text = seconds;
    */
    }

  // ?? NULL REFERENCE ERROR
    // Nb. double just means 5.0 instead of 5
    // ????can't calculate total length of video that is being streamed from URL

    double CalculatePlayedFraction()
    {
       
        double fraction = (double)videoPlayer.frame / (double)videoPlayer.frameCount;
        return fraction;
    }



}