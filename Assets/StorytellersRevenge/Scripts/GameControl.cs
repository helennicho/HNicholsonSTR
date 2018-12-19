

using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour
{
    // set MainCamera as player (point of view)
    public GameObject player;
	
    // not needed ??
    //public GameObject eventSystem;

    public GameObject startUI, playUI, restartUI;
    //public GameObject homeUI;

	// waypoints : start, play & restart
	public GameObject startPoint, playPoint, restartPoint;


    /* comment out audio for moment
	// set up empty GameObject holders for various events and stages
	public GameObject playAudio;
	public GameObject failAudioHolder;

	// Used to play sound to indicate Puzzle solved
	public GameObject successAudioHolder;
	public GameObject restingAudioHolder;
	*/


	void Start()
	{
		Debug.Log ("in GameLogic() / Start()");
		// Update 'player' to be the camera's parent gameobject, i.e. 'GvrEditorEmulator' instead of the camera itself.
		// Required because GVR resets camera position to 0, 0, 0.
		player = player.transform.parent.gameObject;

		// Move the 'player/camera' to the 'startPoint' position.
		player.transform.position = startPoint.transform.position;

		//Play the audio attached to start / Audiosource component
		// startPoint.GetComponent<GvrAudioSource>().Play();



		// set start UI active
		startUI.SetActive(true);
		//homeUI.SetActive (true);

	}

    // Initial entry point to game - overview
	public void StartGame()
	{
		Debug.Log ("in GameLogic() / Start()");
		// Update 'player' to be the camera's parent gameobject, i.e. 'GvrEditorEmulator' instead of the camera itself.
		// Required because GVR resets camera position to 0, 0, 0.
		player = player.transform.parent.gameObject;

		// Move the 'player/camera' to the 'startPoint' position.
		player.transform.position = startPoint.transform.position;

		//Play the audio attached to start / Audiosource component
		//startPoint.GetComponent<GvrAudioSource>().Play();

		// set start UI active
		startUI.SetActive(true);
	}

	
    public void OnCLickStartButton()
    {
        PlayGame();
    }
	
    // Zoom into Play game position
	public void PlayGame()
	{
		// Disable the start UI & stop start sounds
		startUI.SetActive(false);
	
		//startPoint.GetComponent<GvrAudioSource>().Stop();

		Debug.Log ("in GameLogic()  / Start() at playPoint - startUI.SetActive(false) call iTween to move player to play position");
		// start play sounds
		//playAudio.GetComponent<GvrAudioSource>().Play();
		// Move the player/camera to the play position.
		iTween.MoveTo(player,
			iTween.Hash(
				"position", playPoint.transform.position,
				"time", 2,
				"easetype", "linear"));

        // set play game UI active
        playUI.SetActive(true);
   
	}

    // Zoom into Play game position
    public void RestartGame()
    {
        // Disable the start UI & stop start sounds
        playUI.SetActive(false);

        //startPoint.GetComponent<GvrAudioSource>().Stop();

        Debug.Log("in GameLogic()  / Start() at playPoint - startUI.SetActive(false) call iTween to move player to play position");
        // start play sounds
        //playAudio.GetComponent<GvrAudioSource>().Play();
        // Move the player/camera to the play position.
        iTween.MoveTo(player,
            iTween.Hash(
                "position", playPoint.transform.position,
                "time", 2,
                "easetype", "linear"));

        // set restart game UI active
        restartUI.SetActive(true);

    }

  




}