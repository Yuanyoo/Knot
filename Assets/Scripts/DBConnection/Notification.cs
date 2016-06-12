using SQLite4Unity3d;

public class Notification{
	
	public int Id_grupo { get; set; }
	public int Id_sender { get; set; }
	public int Id_receiver { get; set; }
	[PrimaryKey, AutoIncrement]
	public int Id_notification{ get; set; }
	public int Id_typeNotification{ get; set;}
	public string Message{ get; set; }
}
