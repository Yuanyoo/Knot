using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Test : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		DaoUser lol = new DaoUser ();
		lol.dbo_UpdateUser("2342","Yuanyo","pasaelzelda", 1);
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
