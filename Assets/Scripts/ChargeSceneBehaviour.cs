using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChargeSceneBehaviour : MonoBehaviour {

	public GameObject loginMenu;
	public FB_Connection fb;

	public void InitValues(){


		fb.FB_Init ();

		DaoUser daoUser = new DaoUser ();

		List<User> users = daoUser.dbo_User();
		Debug.Log (users.Count);

		foreach (User u in users) {
			if (u.IsCurrentUser == 1) {
				CommandDBValues.SetCurrentProfile(u);
				Debug.Log ("tenemos un usuario local");
				DBValues.HaveALocalUser = true;
				break;
			}
		}

		if (DBValues.CurrentUser == null)
			CommandDBValues.SetCurrentProfile(new User ());
	
	}

	public void CanChargeUserLevel(){
		if (!DBValues.HaveALocalUser)
			loginMenu.SetActive (true);
		else
			fb.FB_Login();
	}
}
