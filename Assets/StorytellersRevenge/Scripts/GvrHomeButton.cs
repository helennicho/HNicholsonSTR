using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GvrHomeButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        Debug.Log(" In GvrHomeButton/ OnClick");
        GoToScene();
    }

    void GoToScene()
    {
        Debug.Log("in GvrHomeButton /GotToScene ");
        SceneManager.LoadScene("Main");
    }
}
