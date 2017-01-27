using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour {
	public bool active = false;
	public GameObject p;

	public void stop(){
		active = !active;
		p.SetActive (active);
	}

	public void retry(){
		Application.LoadLevel ("main");
	}
}
