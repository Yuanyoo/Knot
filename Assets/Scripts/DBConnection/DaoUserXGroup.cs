using System.Collections;
using System.Collections.Generic;
using SQLite4Unity3d;
using System;

public class DaoUserXGroup
{
	public DaoUserXGroup ()
	{
	}

	public UserXGroup dbo_UxGByIDUserIDGroup(int id_user,int id_group){
		UserXGroup obj = new UserXGroup();
		//OPEN DATABASE
		Dao dao = new Dao ();

		//QUERY
		if (!dao.Error) {
			obj = dao.Connection.Table<UserXGroup>().Where( x => (x.Id_user == id_user)&&(x.Id_group==id_group)).FirstOrDefault();
		}

		//CLOSE DATABASE
		dao.Close();		
		return obj;
	}

	//SELECT
	public  List<UserXGroup> dbo_UxGByIDuser(int id_user){
		List<UserXGroup> list = new List<UserXGroup> ();
		IEnumerable<UserXGroup> tableDB = new List<UserXGroup> ();
		//OPEN DATABASE
		Dao dao = new Dao ();

		//QUERY
		if (!dao.Error) {
			tableDB = dao.Connection.Table<UserXGroup>().Where( x => (x.Id_user == id_user));
		}
		//OUTPUT
		foreach (UserXGroup row in tableDB) {
			list.Add(row);
		}
		//CLOSE DATABASE
		dao.Close();
		return list;
	}

	//INSERT
	public bool dbo_UxGInsert(int id_group, int id_user, float score_positive,float score_negative){

		bool succcess = false;
		UserXGroup objNew = new UserXGroup ();

		objNew.Id_group = id_group;
		objNew.Id_user = id_user;
		objNew.score_negative = score_negative;
		objNew.score_positive = score_positive;
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


	public bool dbo_UxGUpdateByIdUserIdGroup(int id_user, int id_group, float positive, float negative){

		bool succcess = false;
		UserXGroup obj = dbo_UxGByIDUserIDGroup (id_user, id_group);

		if (obj != null) {
			obj.score_positive += positive;
			obj.score_negative += negative;
			//OPEN DATABASE
			Dao dao = new Dao ();

			//UPDATE
			if (!dao.Error) {
				int result = dao.Connection.Update (obj);
				if (result != Dao.UPDATE_ERROR)
					succcess = true;
			}

			//CLOSE DATABASE
			dao.Close ();
		}

		return succcess;
	}
}