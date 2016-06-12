using System.Collections;
using System.Collections.Generic;
using SQLite4Unity3d;
using System;

public class DaoTask
{
	public DaoTask ()
	{
	}

	public Task dbo_TaskById_userAndId_group(int id_user, int id_grupo){
		Task obj = new Task();
		//OPEN DATABASE
		Dao dao = new Dao ();

		//QUERY
		if (!dao.Error) {
			obj = dao.Connection.Table<Task>().Where( x => (x.Id_user == id_user)&&(x.Id_group==id_grupo)).FirstOrDefault();
		}

		//CLOSE DATABASE
		dao.Close();		
		return obj;
	}

	//SELECT
	public  List<Task> dbo_TaskByById_userAndId_group(int id_user, int id_grupo){
		List<Task> list = new List<Task> ();
		IEnumerable<Task> tableDB = new List<Task> ();
		//OPEN DATABASE
		Dao dao = new Dao ();

		//QUERY
		if (!dao.Error) {
			tableDB = dao.Connection.Table<Task>().Where( x => (x.Id_user == id_user)&&(x.Id_group==id_grupo));
		}
		//OUTPUT
		foreach (Task row in tableDB) {
			list.Add(row);
		}
		//CLOSE DATABASE
		dao.Close();
		return list;
	}

	//INSERT
	public bool dbo_TaskInsert(string Task_Description,float Score,int Id_user,int Id_group, string Date){

		bool succcess = false;
		Task objNew = new Task ();

		objNew.Task_Description = Task_Description;
		objNew.Score = Score;
		objNew.Id_user = Id_user;
		objNew.Id_group = Id_group;
		objNew.DATE = Date;
		//OPEN DATABASE
		Dao dao = new Dao ();

		//UPDATE
		if (!dao.Error) {
			int result = dao.Connection.Insert (objNew);
			if (result != Dao.INSERT_ERROR)
				succcess = true;
		}

		//CLOSE DATABASE
		dao.Close ();
		return succcess;

	}


}