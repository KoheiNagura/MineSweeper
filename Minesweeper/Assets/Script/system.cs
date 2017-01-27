using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class system : MonoBehaviour {
	public int[,] mine;
	public int[,] stage;
	public ID[,] _id;
	public Cube[,] cub;
	public nav nav;
	public GameObject can;
	public GameObject s;
	public GameObject cube;
	public int MineCount;
	public int range = 5;
	public int flagcount;
	public GameObject Fl_UI;
	public Text text;
	public Text FlagText;
	public Image[] a;
	public Sprite[] key;
	public bool first;
	int random_x = 0;
	int random_y = 0;
	int up = 0;
	int down = 0;
	int right = 0;
	int left = 0;
	int pos_x = 0;
	int pos_z = -2;
	public bool flag;
	bool f;
	// Use this for initialization
	void Start () {
		//配列の初期化など
		mine = new int[range,range];
		for (int x = 0; x < range; x++) {
			for (int y = 0; y < range; y++) {
				mine [x, y] = 0;
				Debug.Log("x = " + x + " , " + "y = " + y);
			}
		}
		cub = new Cube[range, range];
		stage = new int[range,range];
		_id = new ID[range, range];
		for (int x = 0; x < range; x++) {
			pos_z += 2;
			pos_x = 0;
			for (int y = 0; y < range; y++) {
				GameObject c = Instantiate (cube, new Vector3 (pos_x, 0, pos_z), Quaternion.identity)as GameObject;
				cub [x, y] = c.GetComponent<Cube> ();
				pos_x -= 2;
				stage [x, y] = 0;
				GameObject obj = Instantiate (s, can.transform.position, Quaternion.identity)as GameObject;
				obj.transform.parent = can.transform;
				ID id = obj.GetComponent<ID> ();
				id.x = x;
				id.y = y;
				_id [x, y] = id;
			}
		}

		text.text = "x " + MineCount.ToString ();

//		SetMine ();
//		CheckMine ();

	}

	void Update(){
		if (Input.GetKeyDown ("z")) {
			CheckMine ();
		}
	}

	public void flagManager(){
		flag = !flag;
		if (flag == true) {
			a [0].sprite = key [0];
		} else {
			a [0].sprite = key [1];
		}
	}

	public void CameraManager(){
		can.GetComponent<drag> ().enabled = !can.GetComponent<drag> ().enabled;
		if (can.GetComponent<drag> ().enabled == true) {
			a [1].sprite = key [0];
		} else {
			a [1].sprite = key [1];
		}
	}

	public void SetMine() {

		for(int i = 0; i < MineCount;){
			random_x = Random.Range (0, range);
			random_y = Random.Range (0, range);
			if(mine[random_x,random_y] != 1){
				mine [random_x,random_y] = 1;
				i++;
			}
		}
	
	}

	public void SetMine_first(int x,int y) {

		Debug.Log("first x = " + x + " , " + "y = " + y);

		if (range * range > MineCount) {
			for (int i = 0; i < MineCount;) {
				random_x = Random.Range (0, range);
				random_y = Random.Range (0, range);
				Debug.Log (random_x + "," + random_y);
				if (mine [random_x, random_y] != 1 && random_x != x && random_y != y) {
					mine [random_x, random_y] = 1;
					i++;
				} else {
					i = MineCount;
					Debug.Log ("koko");
				}
			}
		} else {
			for(int i = 0; i < MineCount;){
				random_x = Random.Range (0, range-1);
				random_y = Random.Range (0, range-1);
				Debug.Log (range);
				if(mine[random_x,random_y] != 1){
					mine [random_x,random_y] = 1;
					i++;
				}
			}
		}


		Debug.Log ("Finish");
		CheckMine ();
		_id [x, y].open = true;
//		Check (x, y);

	}


	public void CheckMine() {
		
		for (int x = 0; x < range; x++) {
			
			for (int y = 0; y < range; y++) {
				
				if(x - 1 != -1){
					left = 1;
					if (mine [x - 1, y] == 1) {
						stage [x, y]++;
					}
				}

				if (x + 1 != range) {
					right = 1;
					if (mine [x + 1, y] == 1) {
						stage [x, y]++;
					}
				}

				if (y - 1 != -1) {
					up = 1;
					if (mine [x, y - 1] == 1) {
						stage [x, y]++;
					}
				}

				if (y + 1 != range) {
					down = 1;
					if (mine [x, y + 1] == 1) {
						stage [x, y]++;
					}
				}
				Debug.Log (x + "," + y + "右：" + right + "左：" + left + "上：" + up + "下：" + down);
				if (right == 1) {
					if (up == 1) {
						if (mine [x + 1, y - 1] == 1) {
							stage [x, y]++;
						}
					}
					if (down == 1) {
						if (mine [x + 1, y + 1] == 1) {
							stage [x, y]++;
						}
					}
				}

				if (left == 1) {
					if (up == 1) {
						if (mine [x - 1, y - 1] == 1) {
							stage [x, y]++;
						}
					}
					if (down == 1) {
						if (mine [x - 1, y + 1] == 1) {
							stage [x, y]++;
						}
					}
				}
				up = 0;
				down = 0;
				right = 0;
				left = 0;
			}
		}


	
	}

	public void Check(int x, int y){
		Debug.Log ("a");
		nav.Move (cub [x, y]);
		if (stage [x, y] == 0) {
			if (x - 1 != -1) {
				left = 1;
				if (_id [x - 1, y].flag == false) {
					_id [x - 1, y].open = true;
				}
			}

			if (x + 1 != range) {
				right = 1;
				if (_id [x + 1, y].flag == false) {
					_id [x + 1, y].open = true;
				}
			}

			if (y - 1 != -1) {
				up = 1;
				if (_id [x, y - 1].flag == false) {
					_id [x, y - 1].open = true;
				}
			}

			if (y + 1 != range) {
				down = 1;
				if (_id [x, y + 1].flag == false) {
					_id [x, y + 1].open = true;
				}
			}

			if (right == 1) {
				if (up == 1) {
					if (_id [x + 1, y - 1].flag == false) {
						_id [x + 1, y - 1].open = true;
					}
				}
				if (down == 1) {
					if (_id [x + 1, y + 1].flag == false) {
						_id [x + 1, y + 1].open = true;
					}
				}
			}

			if (left == 1) {
				if (up == 1) {
					if (_id [x - 1, y - 1].flag == false) {
						_id [x - 1, y - 1].open = true;
					}
				}
				if (down == 1) {
					if (_id [x - 1, y + 1].flag == false) {
						_id [x - 1, y + 1].open = true;
					}
				}
			}

			up = 0;
			down = 0;
			right = 0;
			left = 0;
		}
			
	}

	public void FlagCount(bool fl){
		if (fl == true) {
			flagcount++;
		} else {
			flagcount--;
		}
	}

	public void Flag_UI(){
		f = !f;
		Fl_UI.SetActive (f);
		FlagText.text =  "x " + flagcount.ToString ();
	}
}
