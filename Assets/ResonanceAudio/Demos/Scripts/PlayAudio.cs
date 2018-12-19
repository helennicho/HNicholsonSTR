using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour {

    // Use this for initialization
    public GameObject audioOrb;
    private bool isPlaying;



	void Start () {
        audioOrb.SetActive(false);
        isPlaying = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        if (isPlaying == true)
        {
            audioOrb.SetActive(false);
            isPlaying = false;
        }
        else
        {
            audioOrb.SetActive(true);
            isPlaying = true;
            TeleportRandomly();
        }

    }

    /// Teleports the cube to a random location.
    public void TeleportRandomly()
    {
        Vector3 direction = Random.onUnitSphere;
        direction.y = Mathf.Clamp(direction.y, 0.5f, 1.0f);
        float distance = 2.0f * Random.value + 1.5f;
        transform.localPosition = distance * direction;
    }
           

}
