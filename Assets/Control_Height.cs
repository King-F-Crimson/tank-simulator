using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control_Height : MonoBehaviour {

    public float initialHeight = 2.1f;
    public Slider heightSlider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (0, heightSlider.value - initialHeight, 0);
	}
}
