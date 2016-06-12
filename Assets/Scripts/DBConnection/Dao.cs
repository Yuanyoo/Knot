using UnityEngine;
using System.Collections;
using SQLite4Unity3d;


public class Dao  {
	//CONNECT WITH DATABASE
	private DataService _ds;
	private SQLiteConnection _connection;
	private bool _error;
	public static int INSERT_ERROR = 0;
	public static int UPDATE_ERROR = 0;
	public static int DELETE_ERROR = 0;

	public Dao(){
		//CONNECT WITH DATABASE
//		_ds = new DataService (Constants.DATABASE_NAME_V2_2);
		_ds = new DataService ("knotAngelHack.db");
		_connection = _ds.Connection;
		_error = _ds.Error;
	}

	public SQLiteConnection Connection{
		get{ return _connection;}
		set{ _connection = value;}
	}

	public bool Error{
		get{ return _error;}
		set{ _error = value;}
	}

	public void Close(){
		if (_ds != null) {
			_ds.Connection.Close();
		}
	}
}
