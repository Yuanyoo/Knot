using UnityEngine;
using System.Collections;
using Facebook.Unity;
using Facebook.MiniJSON;
using Facebook.Unity.Example;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class FB_Connection : MonoBehaviour {

	/*public static FB_Connection staticInstance;

	void Awake(){
		staticInstance = this;
		FB_Init ();
	}*/

	public void FB_Init(){
		FB.Init(OnInitComplete, OnHideUnity);
	}

	private void OnInitComplete()
	{
		string logMessage = string.Format(
			"OnInitCompleteCalled IsLoggedIn='{0}' IsInitialized='{1}'",
			FB.IsLoggedIn,
			FB.IsInitialized);
		Debug.Log(logMessage);
		//FB_Login ();
	}

	private void OnHideUnity(bool isGameShown)
	{
		Debug.Log("Is game shown: " + isGameShown);
	}

	public void FB_Login()
	{
		FB.LogInWithReadPermissions(new List<string>() { "public_profile", "email", "user_friends", "user_photos" }, LoginCallback);
	}

	void LoginCallback(IResult result)
	{
		if (result.Error != null)
			Debug.Log("Error Response:\n" + result.Error);
		else if (!FB.IsLoggedIn)
			Debug.Log("Login cancelled by Player");
		else{
			Debug.Log("Login was successful!");

			GetUserData ();
		}
	}
		
	private void GetUserData(){
		FB.API("/me?fields=id,first_name,picture.width(256).height(256)", HttpMethod.GET, UserDataCallback);
	}

	void UserDataCallback(IResult result)
	{
		if (result.Error != null)
			Debug.Log("Error Response:\n" + result.Error);
		else{
			Debug.Log (result.RawResult);
			IDictionary dict = Facebook.MiniJSON.Json.Deserialize(result.RawResult) as IDictionary;

			string fbid = dict ["id"].ToString();
			DBValues.CurrentUser.Id_fb = fbid;
			string fbname = dict["first_name"].ToString();
			DBValues.CurrentUser.FirstName = fbname;
			string pictureJSON = Facebook.MiniJSON.Json.Serialize (dict ["picture"]);
			IDictionary pDict = Facebook.MiniJSON.Json.Deserialize(pictureJSON) as IDictionary;
			string dataJSON = Facebook.MiniJSON.Json.Serialize (pDict ["data"]);
			IDictionary dDict = Facebook.MiniJSON.Json.Deserialize(dataJSON) as IDictionary;
			string fbpicture = dDict ["url"].ToString ();
			DBValues.CurrentUser.Link_ProfPic = fbpicture;
			//string fbpicture = dDict ["url"].ToString();

			Debug.Log("your name is: " + fbname);
			Debug.Log("your id is: " + fbid);
			Debug.Log("your picture is: " + fbpicture);
			GetUserPicture(fbpicture);
		}
	}

	public void GetUserPicture(string url){
		StartCoroutine (FBUserImage (url));
	}

	IEnumerator FBUserImage(string url)
	{
		WWW www = new WWW(url); 
		Texture2D textFb2 = new Texture2D(128, 128, TextureFormat.DXT1, false); //TextureFormat must be DXT5
		yield return www;
		www.LoadImageIntoTexture(textFb2);
		DBValues.profilePicture = Sprite.Create (www.texture, new Rect (0, 0, www.texture.width, www.texture.height), new Vector2 (0.5f, 0.5f));


		DaoUser daoUser = new DaoUser ();
		User newUser = DBValues.CurrentUser;
		if (!DBValues.HaveALocalUser) {
			daoUser.dbo_UserInsert (newUser.FirstName, newUser.Id_fb, newUser.Link_ProfPic, 1);
			DBValues.HaveALocalUser = true;
		} else {
			daoUser.dbo_UpdateUser (newUser.FirstName, newUser.Id_fb, newUser.Link_ProfPic, 1);
		}

		List<User> usersList = daoUser.dbo_User ();
		DBValues.CurrentUser.Id_user = usersList.Count;

		LevelLoader.StaticInstance.LoadLevel (2);
	}
}
