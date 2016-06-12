using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PetItem : MonoBehaviour {
	public int clicked;
	public int idtype;
	public string name;
	public int idgroup;
	// Use this for initialization
	void Start () {
		switch (idtype) {
		case 1:
			gameObject.GetComponent<Image> ().sprite = Resources.Load ("Images/Pets/knoto", typeof(Sprite)) as Sprite;
			break;
		case 2:
			gameObject.GetComponent<Image> ().sprite = Resources.Load ("Images/Pets/personaje b", typeof(Sprite)) as Sprite;
			break;
		case 3:
			gameObject.GetComponent<Image> ().sprite = Resources.Load ("Images/Pets/personaje c", typeof(Sprite)) as Sprite;
			break;

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Select(){
		DeselectOthers ();
		clicked = 1;
	}

	void DeselectOthers(){
		GameObject parent = gameObject.transform.parent.gameObject;
		Transform[] transform1 = parent.GetComponentsInChildren<Transform> ();
		foreach (Transform t in transform1) {
			if (t.gameObject.name == "Pet(Clone)") {
				t.gameObject.GetComponent<PetItem> ().clicked = 0;
			}
		}
	}


}
