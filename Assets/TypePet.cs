using SQLite4Unity3d;

public class TypePet {
	[PrimaryKey, AutoIncrement]
	public int Id_typePet { get; set; }
	public string Name { get; set; }


}