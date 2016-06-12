using System.Collections;
using System.Collections.Generic;
using SQLite4Unity3d;
using System;

public class DaoNotification
{
	public DaoNotification ()
	{
	}

	public Notification dbo_NotificationById(int id){
		Notification obj = new Notification();
		//OPEN DATABASE
		Dao dao = new Dao ();

		//QUERY
		if (!dao.Error) {
			obj = dao.Connection.Table<Notification>().Where( x => (x.Id_notification == id)).FirstOrDefault();
		}

		//CLOSE DATABASE
		dao.Close();		
		return obj;
	}

	//SELECT
	public  List<Notification> dbo_NotificationByIdReceiver(int id_receiver){
		List<Notification> list = new List<Notification> ();
		IEnumerable<Notification> tableDB = new List<Notification> ();
		//OPEN DATABASE
		Dao dao = new Dao ();

		//QUERY
		if (!dao.Error) {
			tableDB = dao.Connection.Table<Notification>().Where( x => (x.Id_receiver == id_receiver));
		}
		//OUTPUT
		foreach (Notification row in tableDB) {
			list.Add(row);
		}
		//CLOSE DATABASE
		dao.Close();
		return list;
	}

	//INSERT
	public bool dbo_NotificationInsert(int id_grupo,int id_sender, int id_receiver,int id_tipo,string mensaje){

		bool succcess = false;
		Notification objNew = new Notification ();

		objNew.Id_grupo = id_grupo;
		objNew.Id_sender = id_sender;
		objNew.Id_receiver = id_receiver;
		objNew.Id_typeNotification = id_tipo;
		objNew.Message = mensaje;
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