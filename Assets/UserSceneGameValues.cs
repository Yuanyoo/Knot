using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserSceneGameValues : MonoBehaviour {

	public Image profileImage;
	public Text profileName;

	public static UserSceneGameValues staticInstance;

	void Awake(){
		staticInstance = this;
		ChargeUserData ();
	}

	void ChargeUserData(){
		profileName.text = DBValues.CurrentUser.FirstName;
		profileImage.sprite = DBValues.profilePicture;
	}
}
