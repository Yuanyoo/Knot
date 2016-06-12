using SQLite4Unity3d;

public class Task{
	[PrimaryKey, AutoIncrement]
	public int Id_task { get; set; }
	public string Task_Description { get; set; }
	public float Score { get; set; }
	public int Id_user{ get; set; }
	public int Id_group{ get; set;}
	public string DATE{ get; set; }
}
	