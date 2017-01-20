using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage : MonoBehaviour {
	public InputField mine;
	public InputField sta;
	public GridLayoutGroup grid;
	public system sys;
	int i1;
	int i2;
	string st1;
	string st2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void start(){
		st1 = mine.text;
		st2 = sta.text;
		i1 = int.Parse (st1);
		i2 = int.Parse (st2);
		if (i1 < 0) {
			i1 = i1 * -1;
		}

		if (i2 < 0) {
			i2 = i2 * -1;
		}

		if (i2 * i2 < i1) {
			i1 = i2 * i2;
		}

		sys.MineCount = i1;
		sys.range = i2;
		grid.constraintCount = i2;
		sys.enabled = true;
		this.gameObject.SetActive (false);
	}
}
