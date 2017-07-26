using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Write_Equation : MonoBehaviour {
	public GameObject shooter;

	private Text equation;

	// Use this for initialization
	void Start () {
		equation = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position; Quaternion rotation; float v_velocity; float h_velocity;
		shooter.GetComponent<Shoot>().GetProjectileInstantiationData(out position, out rotation, out v_velocity, out h_velocity);

		float air_time = AirTime(Physics.gravity[1], v_velocity, position.y);
		float time_to_reach_max_height = TimeToReachMaxHeight(Physics.gravity[1], v_velocity);
		float maximum_height = MaximumHeight(Physics.gravity[1], v_velocity, position.y, time_to_reach_max_height);
		float horizontal_distance = air_time * h_velocity;

		equation.text = String.Format(@"Air time = {0:0.00}
Time to reach maximum height = {1:0.00}
Maximum height = {2:0.00}
Horizontal distance = {3:0.00}",
		air_time, time_to_reach_max_height, maximum_height, horizontal_distance);
	}

	float AirTime(float gravity, float initial_velocity, float height) {
		float air_time = (-initial_velocity - (float)Math.Sqrt(Math.Pow(initial_velocity, 2) - 2 * gravity * height)) / gravity;

		return air_time;
	}

	float TimeToReachMaxHeight(float gravity, float initial_velocity) {
		float time_to_reach_max_height = initial_velocity / -gravity;
		
		return time_to_reach_max_height;
	}

	float MaximumHeight(float gravity, float initial_velocity, float height, float time_to_reach_max_height) {
		float maximum_height = height + initial_velocity / 2 * time_to_reach_max_height;

		return maximum_height;
	}
}