using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ID : MonoBehaviour {
	public int x = 0;
	public int y = 0;
	public GameObject system;
	public Text text;
	public Image image;
	public Image mine;
	public bool open;
	public bool flag;
	public bool aketa;
	system sys;

	void Start(){
		system = GameObject.Find ("abc");
		sys = system.GetComponent<system> ();
	}

	void Update(){
		if (open == true) {
			if (aketa = false) {
				if (flag == false) {
					sys.Check (x, y);
					aketa = true;
					if (sys.mine [x, y] == 1) {
						mine.enabled = true;
					} else {
						text.text = sys.stage [x, y].ToString ();
					}
				}
			}
		}
	}

	public void check(){
		if (sys.first == false) {
			sys.first = !sys.first;
			sys.SetMine_first (x, y);
//			open = true;
		} else {
			if (sys.flag == true) {
				if (open == false) {
					flag = !flag;
					image.enabled = flag;
					sys.FlagCount (flag);
				}
			} else {
				if (flag == false) {
					open = true;
					sys.Check (x, y);
				}
			}
		}
	}
}
