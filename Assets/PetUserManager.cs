using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PetUserManager : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
		DaoUserXGroup UxG = new DaoUserXGroup ();
		List<UserXGroup> Us=UxG.dbo_UxGByIDuser (DBValues.CurrentUser.Id_user);
		foreach (UserXGroup U in Us) {
			DaoPet d = new DaoPet ();
			Pet p = d.dbo_PetByIdGroup (U.Id_group);
			GameObject u =Instantiate(Resources.Load ("Prefabs/Pet", typeof(GameObject)) as GameObject);
			u.GetComponent<PetItem> ().idtype = p.Id_typePet;
			u.GetComponent<PetItem> ().name = p.Name;
			u.GetComponent<PetItem> ().idgroup = U.Id_group;
			u.transform.SetParent (gameObject.transform);
			u.GetComponent<Transform> ().localScale = new Vector3 (1f, 1f, 1f);
		}

	}

	void OnDisable(){
		Transform[] ts = gameObject.GetComponentsInChildren<Transform> ();
		foreach (Transform t in ts) {
			if (t.gameObject.name == "GroupContainer") {
			} else {
				Destroy (t.gameObject);
			}

			}
	}
	

}