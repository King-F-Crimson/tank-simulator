using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculate_Trajectory : MonoBehaviour {

	public GameObject shooter;
	public float timeStep = 0.1f;
	public int points = 100;

	private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.positionCount = points;
	}
	
	// Update is called once per frame
	void Update () {
		CalculateTrajectory();
	}

	void CalculateTrajectory() {
		Vector3 position; Quaternion rotation; float v_velocity; float h_velocity;
		shooter.GetComponent<Shoot>().GetProjectileInstantiationData(out position, out rotation, out v_velocity, out h_velocity);

		for (int i = 0; i < points; i++) {
			lineRenderer.SetPosition(i, CalculateProjectilePosition(i * timeStep, position, rotation, v_velocity, h_velocity));
		}
	}

	Vector3 CalculateProjectilePosition(float timeElapsed, Vector3 initialPosition, Quaternion rotation, float vVelocity, float hVelocity) {
		float gravity = Physics.gravity[1];

		float verticalMovement = gravity * (float)Math.Pow((double)timeElapsed, 2.0) / 2 + vVelocity * timeElapsed;
		float horizontalMovement = hVelocity * timeElapsed;

		return new Vector3(horizontalMovement, verticalMovement, 0) + initialPosition;
	}
}
