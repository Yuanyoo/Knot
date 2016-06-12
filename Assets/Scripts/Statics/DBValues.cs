using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DBValues {

	private static User currentUser;
	public static User CurrentUser{ get {return currentUser;} protected set{	currentUser = value;	} }

	private static Group currentGroup;
	public static Group CurrentGroup { get { return currentGroup; } protected set { currentGroup = value; } }

	public static bool HaveALocalUser = false;
	public static Sprite profilePicture ;
}
