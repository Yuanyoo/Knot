using SQLite4Unity3d;

public class Group {
	[PrimaryKey, AutoIncrement]
	public int Id_group { get; set; }
	public string Nombre { get; set; }
	public int Id_typeGroup { get; set; }
}
