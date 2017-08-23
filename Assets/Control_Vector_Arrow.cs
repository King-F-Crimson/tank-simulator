using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Control_Vector_Arrow : MonoBehaviour {
    private GameObject target;
    private Rigidbody target_rb;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (target != null) {
		  transform.position = target.transform.position;
          UpdateRotation();
        }
        else {
            Destroy(gameObject);
        }
	}

    void UpdateRotation () {
        float theta = (float)Math.Atan(target_rb.velocity.y / target_rb.velocity.x) * 180 / (float)Math.PI;

        transform.eulerAngles = new Vector3(theta, 270, 0);
    }

    public void SetTarget (GameObject target) {
        this.target = target;
        target_rb = target.GetComponent<Rigidbody>();
    }
}
