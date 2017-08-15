using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot_Double_Velocity : MonoBehaviour {

	public GameObject projectile;
	public Slider verticalVelocitySlider;
	public Slider horizontalVelocitySlider;

	public Vector3 muzzlePosition;

	private float verticalVelocity;
	private float horizontalVelocity;

	// Use this for initialization.
	void Start () {
		verticalVelocitySlider.onValueChanged.AddListener(delegate {ChangeVelocity(); });
		horizontalVelocitySlider.onValueChanged.AddListener(delegate {ChangeVelocity(); });

		verticalVelocity = verticalVelocitySlider.value;
		horizontalVelocity = horizontalVelocitySlider.value;
	}
	
	// Update is called once per frame.
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			GameObject clone = Instantiate(projectile, transform.position + muzzlePosition, transform.rotation);
			Rigidbody rb = clone.GetComponent<Rigidbody>();

			rb.velocity = new Vector3(horizontalVelocity, verticalVelocity, 0);
		}
	}

	void ChangeVelocity() {
		verticalVelocity = verticalVelocitySlider.value;
		horizontalVelocity = horizontalVelocitySlider.value;
	}

	// Returns the initial coordinates and velocities.
	public void GetProjectileInstantiationData(out Vector3 position,
		out Quaternion rotation,
		out float verticalVelocityInput,
		out float horizontalVelocityInput) {
		position = transform.position + muzzlePosition;
		rotation = transform.rotation;
		verticalVelocityInput = verticalVelocity;
		horizontalVelocityInput = horizontalVelocity;
	}
}
