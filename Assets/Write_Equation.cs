using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Write_Equation : MonoBehaviour {
	public Shoot shooter;
    public GameObject[] equations;
    public int base_text_size = 150;

    private string[] equation_texts = {"", "", "", "", ""};

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position; Quaternion rotation; float v_velocity; float h_velocity;
		shooter.GetProjectileInstantiationData(out position, out rotation, out v_velocity, out h_velocity);

		float air_time = AirTime(out equation_texts[0], Physics.gravity[1], v_velocity, position.y);
		float time_to_reach_max_height = TimeToReachMaxHeight(out equation_texts[1], Physics.gravity[1], v_velocity);
		float maximum_height = MaximumHeight(out equation_texts[2], Physics.gravity[1], v_velocity, position.y, time_to_reach_max_height);
		float horizontal_distance = HorizontalDistance(out equation_texts[3], air_time, h_velocity);
        Velocity(out equation_texts[4], v_velocity, h_velocity);

        for (int i = 0; i <= 4; i++) {
            equations[i].GetComponent<Text>().text = equation_texts[i];
        }
	}

	float AirTime(out string text, float gravity, float v_velocity, float height) {
        int v_text_size = (int)Math.Round(base_text_size * ((v_velocity) / 5.00 + 0.5));

		float air_time = (-v_velocity - (float)Math.Sqrt(Math.Pow(v_velocity, 2) - 2 * gravity * height)) / gravity;
        text = String.Format("Air time = <size={1}>{0:0.00}</size>\n-<size={1}>v</size> - \u221A(<size={1}>v\u00B2</size> - 2gh)\n────────────────────\ng\n", air_time, v_text_size);
        text = text + String.Format("\n-<size={3}>{1:0.00}</size> - \u221A(<size={3}>{1:0.00}</size>\u00B2 - 2*{0:0.00}*{2:0.00})\n────────────────────\n{0:0.00}",
            gravity, v_velocity, height, v_text_size);

		return air_time;
	}

	float TimeToReachMaxHeight(out string text, float gravity, float v_velocity) {
        int v_text_size = (int)Math.Round(base_text_size * ((v_velocity) / 5.00 + 0.5));

		float time_to_reach_max_height = v_velocity / -gravity;
        text = String.Format("Time to reach maximum height = <size={0}>{1:0.00}</size> =\n", v_text_size, time_to_reach_max_height);
        text = text + String.Format("-(<size={2}>v</size> / g) = -(<size={2}>{1:0.00}</size> / {0:0.00})", gravity, v_velocity, v_text_size);
		
		return time_to_reach_max_height;
	}

	float MaximumHeight(out string text, float gravity, float v_velocity, float height, float time_to_reach_max_height) {
        int v_text_size = (int)Math.Round(base_text_size * ((v_velocity) / 5.00 + 0.5));

		float maximum_height = height + v_velocity / 2 * time_to_reach_max_height;
        text = String.Format("Maximum height = <size={0}>{1:0.00}</size> =\nh + (<size={0}>v</size> / 2 * time to reach max height)", v_text_size, maximum_height);
        text = text + String.Format(" = {2:0.00} + (<size={3}>{1:0.00}</size> / 2 * {0:0.00})", time_to_reach_max_height, v_velocity, height, v_text_size);

		return maximum_height;
	}

    float HorizontalDistance(out string text, float air_time, float h_velocity) {
        int h_text_size = (int)Math.Round(base_text_size * ((h_velocity) / 5.00 + 0.5));

        float horizontal_distance = air_time * h_velocity;
        text = String.Format("Horizontal distance = <size={0}>{1:0.00}</size> =\nair time * <size={0}>hv</size>", h_text_size, horizontal_distance);
        text = text + String.Format(" = {0:0.00} * <size={2}>{1:0.00}</size>", air_time, h_velocity, h_text_size);

        return horizontal_distance;
    }

    void Velocity(out string text, float v_velocity, float h_velocity) {
        text = String.Format("Vertical velocity = Total velocity * sin(\u03B8) = {0:0.00} * sin({1:0.00}) = {2:0.00}\n", shooter.GetVelocity(), shooter.GetAngle(), v_velocity);
        text = text + String.Format("Horizontal velocity = Total velocity * cos(\u03B8) = {0:0.00} * cos({1:0.00}) = {2:0.00}\n", shooter.GetVelocity(), shooter.GetAngle(), h_velocity);
    }
}