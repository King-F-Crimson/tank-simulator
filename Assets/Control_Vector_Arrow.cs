using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Control_Vector_Arrow : MonoBehaviour {
	public enum Modes {Vertical, Horizontal, Composite};

	private GameObject target;
	private Modes mode;
	private Rigidbody target_rb;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			transform.position = target.transform.position;

			if (mode == Modes.Composite) {
				UpdateRotation();
			}
			
			UpdateScale();
		}
		else {
			Destroy(gameObject);
		}
	}

	void UpdateRotation () {
		float theta = (float)Math.Atan(target_rb.velocity.y / target_rb.velocity.x) * 180 / (float)Math.PI;

		transform.eulerAngles = new Vector3(theta, 270, 0);
	}

	void UpdateScale() {
		if (mode == Modes.Horizontal) {
			transform.localScale = new Vector3 (1, 0.3f, target_rb.velocity.x / 5f);
		}
		if (mode == Modes.Vertical) {
			transform.localScale = new Vector3 (1, 0.3f, target_rb.velocity.y / 5f);
		}
		if (mode == Modes.Composite) {
			transform.localScale = new Vector3 (1, 0.3f, (float)Math.Sqrt(Math.Pow(target_rb.velocity.x, 2) + Math.Pow(target_rb.velocity.y, 2)) / 5f);
		}
	}

	public void SetTarget (GameObject target) {
		this.target = target;
		target_rb = target.GetComponent<Rigidbody>();
	}

	public void SetMode (Modes mode) {
		this.mode = mode;

		if (mode == Modes.Horizontal) {
			transform.eulerAngles = new Vector3(0, 270, 0);
		}
		if (mode == Modes.Vertical) {
			transform.eulerAngles = new Vector3(90, 270, 0);
		}
	}
}
