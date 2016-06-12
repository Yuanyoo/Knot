using SQLite4Unity3d;

public class User {
	[PrimaryKey, AutoIncrement]
	public int Id_user { get; set; }
	public string FirstName { get; set; }
	public string Id_fb { get; set; }
	public string Link_ProfPic{ get; set;}
	public int IsCurrentUser{ get; set;}

}
