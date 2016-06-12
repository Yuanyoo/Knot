using UnityEngine;
using System.Collections;

public class GetGroup : MonoBehaviour {
	public Group G;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetCurrentGroup(){
		CommandDBValues.SetCurrentGroup (G);
	}
}
