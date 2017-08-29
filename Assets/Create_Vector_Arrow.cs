using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Create_Vector_Arrow : MonoBehaviour {
    public GameObject arrow_base;

	// Use this for initialization
	void Start () {
        foreach (Control_Vector_Arrow.Modes mode in Enum.GetValues(typeof(Control_Vector_Arrow.Modes))) {
            GameObject arrow = Instantiate(arrow_base, gameObject.transform.position, arrow_base.transform.rotation);

            Control_Vector_Arrow arrow_controller = arrow.GetComponent<Control_Vector_Arrow>();
            arrow_controller.SetTarget(gameObject);
            arrow_controller.SetMode(mode);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
