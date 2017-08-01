using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour {
	public string[] tracked_tags = new string[] {"Projectile", "Player"};
	public float movement_speed = 5f;
	public float zoom_speed = 15f;
	public float minimum_orthographic_size = 4f;
	public float margin = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float min_x, min_y, max_x, max_y;
		CalculateBounds(out min_x, out min_y, out max_x, out max_y);
		UpdateCameraPosition(min_x, min_y, max_x, max_y, Time.deltaTime);
		UpdateCameraSize(min_x, min_y, max_x, max_y, Time.deltaTime);
	}

	void CalculateBounds(out float min_x, out float min_y, out float max_x, out float max_y) {
		min_x = min_y = max_x = max_y = 0;

		foreach (string tag in tracked_tags) {
			GameObject[] objects_with_tag = GameObject.FindGameObjectsWithTag(tag);
			foreach (GameObject object_with_tag in objects_with_tag) {
				Vector3 position = object_with_tag.transform.position;

				if (position.x < min_x) {
					min_x = position.x;
				}
				if (position.y < min_y) {
					min_y = position.y;
				}
				if (position.x > max_x) {
					max_x = position.x;
				}
				if (position.y > max_y) {
					max_y = position.y;
				}
			}
		}
	}

	void UpdateCameraPosition(float min_x, float min_y, float max_x, float max_y, float time) {
		float step = movement_speed * time;
		Vector3 middle_position = new Vector3 (min_x + (max_x - min_x) / 2, min_y + (max_y - min_y) / 2, transform.position.z);
		transform.position = Vector3.MoveTowards(transform.position, middle_position, step);
	}

	void UpdateCameraSize(float min_x, float min_y, float max_x, float max_y, float time) {
		float step = zoom_speed * time;

		// Set x_range and y_range to the longer distance between the current camera position to the minimum or maximum.
		float x_range = max_x - transform.position.x;
		if (x_range < transform.position.x - min_x) {
			x_range = transform.position.x - min_x;
		}
		float y_range = max_y - transform.position.y;
		if (y_range < transform.position.y - min_y) {
			y_range = transform.position.y - min_y;
		}

		// Aspect ratio is width / height
		// Orthographic size is the camera height.
		Camera camera = GetComponent<Camera>();
		float x_bound = x_range / camera.aspect; // Find the required camera height to fit all x_range.

		// Choose the biggest between fit all object in y_range, x_range, or minimum size to fit all objects or fulfill minimum size.
		float new_orthographic_size = y_range;
		if (new_orthographic_size < x_bound) {
			new_orthographic_size = x_bound;
		}
		if (new_orthographic_size < minimum_orthographic_size) {
			new_orthographic_size = minimum_orthographic_size;
		}
		new_orthographic_size = new_orthographic_size + margin;

		// Change the camera size in steps.
		camera.orthographicSize = Mathf.MoveTowards(camera.orthographicSize, new_orthographic_size, step);
	}
}