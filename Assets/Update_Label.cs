using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Update_Label : MonoBehaviour {
    public Slider slider;
    public string text_format;

    private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = String.Format(text_format, slider.value);
	}
}
