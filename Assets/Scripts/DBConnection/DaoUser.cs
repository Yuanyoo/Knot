using System;
using System.Collections;
using System.Collections.Generic;
using SQLite4Unity3d;

public class DaoUser
{
	public DaoUser ()
	{
	}

	public User dbo_UserByIdFb(string id){
		User obj = new User();
		//OPEN DATABASE
		Dao dao = new Dao ();

		//QUERY
		if (!dao.Error) {
			obj = dao.Connection.Table<User>().Where( x => (x.Id_fb.Equals(id))).FirstOrDefault();
		}

		//CLOSE DATABASE
		dao.Close();		
		return obj;
	}

	public User dbo_UserByIduser(int id){
		User obj = new User();
		//OPEN DATABASE
		Dao dao = new Dao ();

		//QUERY
		if (!dao.Error) {
			obj = dao.Connection.Table<User>().Where( x => (x.Id_user==id)).FirstOrDefault();
		}

		//CLOSE DATABASE
		dao.Close();		
		return obj;
	}

	//SELECT
	public  List<User> dbo_User(){
		List<User> list = new List<User> ();
		IEnumerable<User> tableDB = new List<User> ();
		//OPEN DATABASE
		Dao dao = new Dao ();

		//QUERY
		if (!dao.Error) {
			tableDB = dao.Connection.Table<User>();
		}
		//OUTPUT
		foreach (User row in tableDB) {
			list.Add(row);
		}
		//CLOSE DATABASE
		dao.Close();
		return list;
	}

	//INSERT
	public bool dbo_UserInsert(string FirstName, string Id_Fb, string linkpic, int isCurrentUser){
		
		bool succcess = false;
		User objNew = new User ();

	
		//objNew.Id_user = Id_user;
		objNew.Id_fb = Id_Fb;
		objNew.FirstName = FirstName;
		objNew.Link_ProfPic = linkpic;
		objNew.IsCurrentUser = isCurrentUser;
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

	public bool dbo_UpdateUser(string id_fb, string newname, string newzelda, int isCurrentUser){

		bool succcess = false;
		User obj = dbo_UserByIdFb (id_fb);

		if (obj != null) {
			obj.FirstName=newname;
			obj.Link_ProfPic = newzelda;
			obj.IsCurrentUser = isCurrentUser;
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
