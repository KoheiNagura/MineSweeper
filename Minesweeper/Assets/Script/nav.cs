using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nav : MonoBehaviour {
	public Transform tra;
	public bool move;
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (move == true) {
			if (this.transform.position.x != tra.position.x && this.transform.position.z != tra.position.z) {
				this.transform.position += transform.forward * speed;
			}
		}
	}

	public void Move(Cube c){
		tra = c.tra;
		transform.LookAt (tra);
		move = true;
	}
}
