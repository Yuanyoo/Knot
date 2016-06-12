using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TypePetManager : MonoBehaviour {
	public GameObject padre;
	void Start(){
		DaoTypePet D = new DaoTypePet ();
		List<TypePet> Pets = D.dbo_TypePet ();
		foreach(TypePet p in Pets){
			GameObject u =Instantiate(Resources.Load ("Prefabs/Pet", typeof(GameObject)) as GameObject);
			u.GetComponent<PetItem> ().idtype = p.Id_typePet;
			u.GetComponent<PetItem> ().name = p.Name;

			u.transform.SetParent (padre.transform);
			u.GetComponent<Transform> ().localScale = new Vector3 (1f, 1f, 1f);
		}
	}
}
