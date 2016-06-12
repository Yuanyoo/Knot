using UnityEngine;
using System.Collections;

public class GetCurrentGroup : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
		DaoPet d = new DaoPet ();
		gameObject.GetComponent<PetItem> ().idtype = d.dbo_PetByIdGroup(DBValues.CurrentGroup.Id_group).Id_typePet;
		gameObject.GetComponent<PetItem> ().name = DBValues.CurrentGroup.Nombre;
	}

}
