using SQLite4Unity3d;

public class UserXGroup{
	[PrimaryKey, AutoIncrement]
	public int IdUxG{ get; set; }
	public int Id_user { get; set; }
	public int Id_group { get; set; }
	public float score_positive { get; set; }

	public float score_negative{ get; set; }

}

