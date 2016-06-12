using SQLite4Unity3d;
using System;
using System.Collections;
using System.Collections.Generic;

public class DaoGroup
{
	public DaoGroup ()
	{
	}

	public Group dbo_GroupById(int id){
		Group obj = new Group();
		//OPEN DATABASE
		Dao dao = new Dao ();

		//QUERY
		if (!dao.Error) {
			obj = dao.Connection.Table<Group>().Where( x => (x.Id_group == id)).FirstOrDefault();
		}

		//CLOSE DATABASE
		dao.Close();		
		return obj;
	}

	//SELECT
	public  List<Group> dbo_Group(){
		List<Group> list = new List<Group> ();
		IEnumerable<Group> tableDB = new List<Group> ();
		//OPEN DATABASE
		Dao dao = new Dao ();

		//QUERY
		if (!dao.Error) {
			tableDB = dao.Connection.Table<Group>();
		}
		//OUTPUT
		foreach (Group row in tableDB) {
			list.Add(row);
		}
		//CLOSE DATABASE
		dao.Close();
		return list;
	}

	//INSERT
	public bool dbo_GroupInsert(string Name, int id_typeGroup){

		bool succcess = false;
		Group objNew = new Group ();

		objNew.Nombre = Name;
		objNew.Id_typeGroup = id_typeGroup;

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


	public bool dbo_PetUpdateByIdGroup(int id, string newname){

		bool succcess = false;
		Group obj = dbo_GroupById (id);

		if (obj != null) {
			obj.Nombre = newname;

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