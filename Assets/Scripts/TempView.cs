using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempView : MonoBehaviour {
	public Vector3 tempVectors = new Vector3(121, 23,-18);
	public Vector3 defaultVector = new Vector3(121, 20, -18);
	public bool MouseEnter = false;
	public float delta;
	// Use this for initialization
	void OnMouseEnter() {
		if (MouseEnter == true) {
			while (transform.position != defaultVector) {
				transform.position = Vector3.MoveTowards (defaultVector, tempVectors, delta);
			}
		}
	}
	void OnMouseExit() {
		if (MouseEnter == false) {
			
			delta = (float)(1.0 * Time.deltaTime);
			while (transform.position != tempVectors) {
				transform.position = Vector3.MoveTowards (tempVectors, defaultVector, delta);
			}
		}
	}
}
