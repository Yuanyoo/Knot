using System;
using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;


public class DataService  {

	private SQLiteConnection _connection;
	private bool _error;
//	private float secondsForWaitLoad = 5.0f;

	public DataService(string DatabaseName){
		_error = false;
#if UNITY_EDITOR
            string dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);

#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID 
			float secondsForWaitLoad = 5.0f; //No comentar, se usa para la compilacion en ANDROID

            WWW loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
			Timer timerError = new Timer();
			timerError.initTimer(secondsForWaitLoad, 0);
			while (!loadDb.isDone) { 
				if (timerError.Stoped) {
					//Place the error process here.
					_error = true; break;
				}
			}  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check

			if (!_error){
	            // then save to Application.persistentDataPath
				File.WriteAllBytes(filepath, loadDb.bytes);
			}

#elif UNITY_IOS
			string loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.copy(loadDb, filepath);
#elif UNITY_WP8
			string loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
			string loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);
#endif

            Debug.Log("Database written");
        }

		string dbPath = filepath;	

#endif

		if (!_error) {
			_connection = new SQLiteConnection (dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
//			Debug.Log("Final PATH: " + dbPath);   
		}          

	}

	/*
	public void CreateDB(){
		_connection.DropTable<Mobile_device_Class> ();
		_connection.CreateTable<Mobile_device_Class> ();
		_connection.DropTable<School_Class> ();
		_connection.CreateTable<School_Class> ();

		//CREATE GAME RULES
		_connection.DropTable<Game_Class> ();
		_connection.CreateTable<Game_Class> ();
		_connection.DropTable<Ability_Class> ();
		_connection.CreateTable<Ability_Class> ();

		//CREATE ASSIGNMENT
		_connection.DropTable<File_Class> ();
		_connection.CreateTable<File_Class> ();
		_connection.DropTable<Advice_Class> ();
		_connection.CreateTable<Advice_Class> ();
		_connection.DropTable<Gui_Class> ();
		_connection.CreateTable<Gui_Class> ();
		_connection.DropTable<Subject_Class> ();
		_connection.CreateTable<Subject_Class> ();
		_connection.DropTable<Assignment_Class> ();
		_connection.CreateTable<Assignment_Class> ();

		//CREATE ASSIGNMENT CHILDS
		_connection.DropTable<Exercise_Class> ();
		_connection.CreateTable<Exercise_Class> ();
		_connection.DropTable<Alternative_Class> ();
		_connection.CreateTable<Alternative_Class> ();

		_connection.DropTable<Profile_Class> ();
		_connection.CreateTable<Profile_Class> ();

		//CREATE PROFILE CHILDS
		_connection.DropTable<Enemy_Class> ();
		_connection.CreateTable<Enemy_Class> ();
		_connection.DropTable<Card_Class> ();
		_connection.CreateTable<Card_Class> ();
		_connection.DropTable<Assignment_x_profile_Class> ();
		_connection.CreateTable<Assignment_x_profile_Class> ();
		_connection.DropTable<Subject_x_profile_Class> ();
		_connection.CreateTable<Subject_x_profile_Class> ();
		_connection.DropTable<Enemies_defeated_x_profile_Class> ();
		_connection.CreateTable<Enemies_defeated_x_profile_Class> ();
		_connection.DropTable<Cards_unblocked_x_profile_Class> ();
		_connection.CreateTable<Cards_unblocked_x_profile_Class> ();

	}
	*/

	/*public void InsertDataDB(){
		_connection.InsertAll(new[]{
			new Game_BE{
				Id = 1,
				Name = "X",
				Value = 500,
				Created = DateTime.Now,
				Modified = DateTime.Now
			},
			new Game_BE{
				Id = 2,
				Name = "Y",
				Value = 15,
				Created = DateTime.Now,
				Modified = DateTime.Now
			},
			new Game_BE{
				Id = 3,
				Name = "CommonCard",
				Value = 2,
				Created = DateTime.Now,
				Modified = DateTime.Now
			},
			new Game_BE{
				Id = 4,
				Name = "UncommonCard",
				Value = 4,
				Created = DateTime.Now,
				Modified = DateTime.Now
			},
			new Game_BE{
				Id = 5,
				Name = "RareCard",
				Value = 8,
				Created = DateTime.Now,
				Modified = DateTime.Now
			},
			new Game_BE{
				Id = 6,
				Name = "Repeated_01",
				Value = 6,
				Created = DateTime.Now,
				Modified = DateTime.Now
			},
			new Game_BE{
				Id = 7,
				Name = "Repeated_02",
				Value = 3,
				Created = DateTime.Now,
				Modified = DateTime.Now
			},
			new Game_BE{
				Id = 8,
				Name = "Repeated_03",
				Value = 1,
				Created = DateTime.Now,
				Modified = DateTime.Now
			},
			new Game_BE{
				Id = 9,
				Name = "Defeated_01",
				Value = 16,
				Created = DateTime.Now,
				Modified = DateTime.Now
			},
			new Game_BE{
				Id = 10,
				Name = "Defeated_02",
				Value = 1,
				Created = DateTime.Now,
				Modified = DateTime.Now
			}
		});
	}
*/
	public SQLiteConnection Connection{
		get{
			return _connection;
		}
		set{
			_connection = value;
		}
	}

	public bool Error{
		get{
			return _error;
		}
		set{
			_error = value;
		}
	}


}
