using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Controller : MonoBehaviour {
    public bool IsPaused = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P)) {
            if (IsPaused) {
                Time.timeScale = 1;
                IsPaused = false;
            }
            else {
                Time.timeScale = 0;
                IsPaused = true;
            }
        }
	}
}
