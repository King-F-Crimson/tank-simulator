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

        string[] equation_text = new string[4];

		float air_time = AirTime(out equation_text[0], Physics.gravity[1], v_velocity, position.y);
		float time_to_reach_max_height = TimeToReachMaxHeight(out equation_text[1], Physics.gravity[1], v_velocity);
		float maximum_height = MaximumHeight(out equation_text[2], Physics.gravity[1], v_velocity, position.y, time_to_reach_max_height);
		float horizontal_distance = HorizontalDistance(out equation_text[3], air_time, h_velocity);

		equation.text = String.Format(@"{0}
{1}
{2}
{3}",
		equation_text[0], equation_text[1], equation_text[2], equation_text[3]);
	}

	float AirTime(out string text, float gravity, float v_velocity, float height) {
		float air_time = (-v_velocity - (float)Math.Sqrt(Math.Pow(v_velocity, 2) - 2 * gravity * height)) / gravity;
        text = String.Format("Air time = (-v - \u221A(v\u00B2 - 2gh)) / g");
        text = text + String.Format(" = (-{1:0.00} - \u221A({1:0.00}\u00B2 - 2*{0:0.00}*{2:0.00})) / {0:0.00} = {3:0.00}",
            gravity, v_velocity, height, air_time);

		return air_time;
	}

	float TimeToReachMaxHeight(out string text, float gravity, float v_velocity) {
		float time_to_reach_max_height = v_velocity / -gravity;
        text = "Time to reach maximum height = -(v / g)";
        text = text + String.Format(" = -({1:0.00} / {0:0.00}) = {2:0.00}", gravity, v_velocity, time_to_reach_max_height);
		
		return time_to_reach_max_height;
	}

	float MaximumHeight(out string text, float gravity, float v_velocity, float height, float time_to_reach_max_height) {
		float maximum_height = height + v_velocity / 2 * time_to_reach_max_height;
        text = "Maximum height = h + (v / 2 * time_to_reach_max_height)";
        text = text + String.Format(" = {2:0.00} + ({1:0.00} / 2 * {0:0.00}) = {3:0.00}", time_to_reach_max_height, v_velocity, height, maximum_height);

		return maximum_height;
	}

    float HorizontalDistance(out string text, float air_time, float h_velocity) {
        float horizontal_distance = air_time * h_velocity;
        text = "Horizontal distance = air_time * horizontal_velocity";
        text = text + String.Format(" = {0:0.00} * {1:0.00} = {2:0.00}", air_time, h_velocity, horizontal_distance);

        return horizontal_distance;
    }
}