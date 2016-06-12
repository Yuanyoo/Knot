using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour {
	public static LevelLoader StaticInstance;
	// Use this for initialization
	void Awake () {
		StaticInstance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel(int num){
		switch(num){
		case 1: 
			SceneManager.LoadScene ("Scene_Logo");
			break;
		case 2:
			SceneManager.LoadScene ("Scene_User");
			break;
		case 3:
			SceneManager.LoadScene ("Scene_Group");
			break;
		case 4:
			SceneManager.LoadScene ("Scene_Game");
			break;
		default:
			SceneManager.LoadScene ("Scene_Logo");
			break;
		}
	}
}
