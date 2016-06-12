using SQLite4Unity3d;
using System;
using System.Collections;
using System.Collections.Generic;
public class DaoPet
{
	public DaoPet ()
	{
	}

	public Pet dbo_PetByIdGroup(int id){
		Pet obj = new Pet();
		//OPEN DATABASE
		Dao dao = new Dao ();

		//QUERY
		if (!dao.Error) {
			obj = dao.Connection.Table<Pet>().Where( x => (x.Id_group == id)).FirstOrDefault();
		}

		//CLOSE DATABASE
		dao.Close();		
		return obj;
	}

	//SELECT
	public  List<Pet> dbo_Pet(){
		List<Pet> list = new List<Pet> ();
		IEnumerable<Pet> tableDB = new List<Pet> ();
		//OPEN DATABASE
		Dao dao = new Dao ();

		//QUERY
		if (!dao.Error) {
			tableDB = dao.Connection.Table<Pet>();
		}
		//OUTPUT
		foreach (Pet row in tableDB) {
			list.Add(row);
		}
		//CLOSE DATABASE
		dao.Close();
		return list;
	}

	//INSERT
	public bool dbo_PetInsert(string Name,int id_group,float happiness,int alive, int gone, int type){

		bool succcess = false;
		Pet objNew = new Pet ();

		objNew.Name = Name;
		objNew.Id_group = id_group;
		objNew.Happiness_level = happiness;
		objNew.Alive = alive;
		objNew.Gone = gone;
		objNew.Id_typePet = type;

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


	public bool dbo_PetUpdateByIdGroup(int id, int newHappinness, int newalive, int newgone){

		bool succcess = false;
		Pet obj = dbo_PetByIdGroup (id);

		if (obj != null) {
			obj.Happiness_level = newHappinness;
				obj.Alive = newalive;
				obj.Gone = newgone;
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