using SQLite4Unity3d;

public class Pet {
	[PrimaryKey, AutoIncrement]
	public int Id_pet { get; set; }
	public string Name { get; set; }
	public int Id_group { get; set; }
	public float Happiness_level{ get; set; }
	public int Alive{ get; set;}
	public int Gone{ get; set;}
	public int Id_typePet{ get; set; }

}
