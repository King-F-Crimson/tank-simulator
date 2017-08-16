using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

	public GameObject projectile;
	public Slider velocitySlider;
	public Slider angleSlider;

	public Vector3 muzzlePosition;

	private float verticalVelocity;
	private float horizontalVelocity;

	// Use this for initialization.
	void Start () {
		velocitySlider.onValueChanged.AddListener(delegate {ChangeVelocity(); });
		angleSlider.onValueChanged.AddListener(delegate {ChangeVelocity(); });

		ChangeVelocity();
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
		verticalVelocity = velocitySlider.value * (float)Math.Sin(angleSlider.value * Math.PI / 180);
		horizontalVelocity = velocitySlider.value * (float)Math.Cos(angleSlider.value * Math.PI / 180);
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

	public float GetVelocity() {
		return velocitySlider.value;
	}

	public float GetAngle() {
		return angleSlider.value;
	}
}
