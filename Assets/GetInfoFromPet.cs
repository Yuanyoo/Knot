using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GetInfoFromPet : MonoBehaviour {
	public GameObject PetContainer;
	public GameObject PetName;
	public GameObject GroupName;
	public GameObject Go;
	// Use this for initialization
	void Start () {
	
	}


		
		

	// Update is called once per frame
	void Update () {
		
		Transform[] transform1 = PetContainer.GetComponentsInChildren<Transform> ();
		foreach (Transform t in transform1) {
			if (t.gameObject.name == "Pet(Clone)") {
				if (t.gameObject.GetComponent<PetItem> ().clicked == 1) {
					PetName.GetComponent<Text> ().text = t.gameObject.GetComponent<PetItem> ().name;
					DaoGroup d = new DaoGroup ();
					Go.GetComponent<GetGroup> ().G = d.dbo_GroupById(t.gameObject.GetComponent<PetItem> ().idgroup);
					GroupName.GetComponent<Text> ().text = Go.GetComponent<GetGroup> ().G.Nombre;

				} 
			}
		}
	}
}
