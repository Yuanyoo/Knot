using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CommandDBValues : DBValues {

	public static void SetCurrentProfile(User currentUser, GameObject go = null){
		debug (go);
		DBValues.CurrentUser = currentUser;
	}

	public static void SetCurrentGroup(Group currentGroup, GameObject go = null){
		debug (go);
		DBValues.CurrentGroup = currentGroup; 
	}

	private static void debug (GameObject go = null){
		string s = "***CommandInitBDValues_from::: ";	
		if(go != null){
			s += "___gameObject::: " + go.name;
		}
		Debug.Log(s);
	}
}
