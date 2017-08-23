using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Vector_Arrow : MonoBehaviour {
    public GameObject arrow_base;

	// Use this for initialization
	void Start () {
		GameObject arrow = Instantiate(arrow_base, gameObject.transform.position, arrow_base.transform.rotation);

        Control_Vector_Arrow arrow_controller = arrow.GetComponent<Control_Vector_Arrow>();
        arrow_controller.SetTarget(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
