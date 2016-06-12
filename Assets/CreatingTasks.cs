using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CreatingTasks : MonoBehaviour {
	public GameObject DescriptionTask;

	public GameObject score;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InsertTask(){
		string description = DescriptionTask.GetComponent<InputField> ().text;
		string aux_score = score.GetComponent<InputField> ().text;
		float aux=float.Parse (aux_score);

		DaoTask T = new DaoTask ();
		T.dbo_TaskInsert (description, aux, DBValues.CurrentUser.Id_user, DBValues.CurrentGroup.Id_group, "");
	}
}
