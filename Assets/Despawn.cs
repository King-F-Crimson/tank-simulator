using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour {
	public float life = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (life > 0) {
			life -= Time.deltaTime;
		}
		else {
			Destroy(this.gameObject);
		}
	}
}
