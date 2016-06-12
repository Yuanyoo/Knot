using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class TaskManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable () {
		DaoTask T = new DaoTask();
		List<Task> Ts = T.dbo_TaskByById_userAndId_group (DBValues.CurrentUser.Id_user, DBValues.CurrentGroup.Id_group);
		foreach (Task t in Ts) {
			GameObject u =Instantiate(Resources.Load ("Prefabs/Tarea 1", typeof(GameObject)) as GameObject);
			u.GetComponent<TaskItem> ().descripcion.GetComponent<Text> ().text = t.Task_Description;
			u.GetComponent<TaskItem> ().puntaje.GetComponent<Text> ().text = t.Score.ToString();
			DaoUser us = new DaoUser ();
			u.GetComponent<TaskItem> ().encargado.GetComponent<Text> ().text = us.dbo_UserByIduser (t.Id_user).FirstName;
			u.transform.SetParent (gameObject.transform);
			u.GetComponent<Transform> ().localScale = new Vector3 (1f, 1f, 1f);
		}

	}
	void OnDisable(){
		Transform[] ts = gameObject.GetComponentsInChildren<Transform> ();
		foreach (Transform t in ts) {
			if (t.gameObject.name == "ContainerTasks") {
			} else {
				Destroy (t.gameObject);
			}

		}
	}
}
