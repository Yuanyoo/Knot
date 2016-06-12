using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class ReadInputFields : MonoBehaviour {
	public GameObject GroupNameInput;
	public GameObject GroupContainerPets;
	public GameObject PetNameInput;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InsertNewGroup(){

		Group group = new Group();
		group.Nombre = GroupNameInput.GetComponent<InputField> ().text;

		DaoGroup G = new DaoGroup ();
		G.dbo_GroupInsert (group.Nombre, 1);
		List<Group> u = G.dbo_Group ();

		group.Id_group = u.Count;

		string petname = PetNameInput.GetComponent<InputField> ().text;
		int typePet = GettingTypePet ();
		DaoPet P = new DaoPet ();
		P.dbo_PetInsert (petname, u.Count, 50, 1, 0, typePet);

		DaoUserXGroup userxgroup = new DaoUserXGroup ();
		userxgroup.dbo_UxGInsert (group.Id_group, DBValues.CurrentUser.Id_user, 0, 0); 
	}

	int GettingTypePet(){
		int aux=1;
		Transform[] transform1 = GroupContainerPets.GetComponentsInChildren<Transform> ();
		foreach (Transform t in transform1) {
			if (t.gameObject.name == "Pet(Clone)") {
				if (t.gameObject.GetComponent<PetItem> ().clicked == 1) {
					aux = t.gameObject.GetComponent<PetItem> ().idtype;
				} 
			}
		}
		return aux;
	}
}
