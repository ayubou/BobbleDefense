using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMove : MonoBehaviour {

	// 落下速度
	private float speed = -0.01f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, this.speed, 0);
		if (transform.position.y < -5.5f) {
			Destroy (gameObject);
		}
	}
}
