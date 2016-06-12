using System;
using System.Collections;
using System.Collections.Generic;
using SQLite4Unity3d;

public class DaoTypePet
{
	public DaoTypePet ()
	{
	}


	//SELECT
	public  List<TypePet> dbo_TypePet(){
		List<TypePet> list = new List<TypePet> ();
		IEnumerable<TypePet> tableDB = new List<TypePet> ();
		//OPEN DATABASE
		Dao dao = new Dao ();

		//QUERY
		if (!dao.Error) {
			tableDB = dao.Connection.Table<TypePet>();
		}
		//OUTPUT
		foreach (TypePet row in tableDB) {
			list.Add(row);
		}
		//CLOSE DATABASE
		dao.Close();
		return list;
	}


}
