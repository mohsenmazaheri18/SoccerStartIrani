using UnityEngine;
using System.Collections;

public class TeamsManager : MonoBehaviour {


	///*************************************************************************///
	/// Main Teams manager.
	/// You can define new teams here.
	/// Team attributes are set as x, y and z component of a vector3.
	/// They should be set from 1 (min) to 10 (max).
	/// x = power
	/// y = time
	/// z = aim
	///*************************************************************************///

	public static int teams = 11;		//total number of available teams

	//Power differs from 1 (weakest) to 10 (strongest) (base power: 35)
	//additional time differs from 1 seconds (little) to 10 seconds (too much) (base time: 15 seconds)
	//w value of vector 4 indicates the lock/unlock state of the selected team (0 = locked, 1 = unlocked)

	public static Vector4 getTeamSettings(int _teamID) {
		Vector4 settings = Vector4.zero;
		switch (_teamID) {
		case 0:
			//Settings: Vector4(power, time, aim, locked/unlocked)
			settings = new Vector4(7, 5, 3, 1);
			break;
		case 1:
			settings = new Vector4(5, 6, 5, 0);
			break;
		case 2:
			settings = new Vector4(4, 8, 2, 1);
			break;
		case 3:
			settings = new Vector4(3, 6, 6, 0);
			break;
		case 4:
			settings = new Vector4(9, 3, 2, 0);
			break;
		case 5:
			settings = new Vector4(3, 10, 3, 1);
			break;
		case 6:
			settings = new Vector4(5, 7, 4, 1);
			break;
		case 7:
			settings = new Vector4(4, 9, 5, 0);
			break;
		case 8:
			settings = new Vector4(8, 3, 7, 1);
			break;
		case 9:
			settings = new Vector4(5, 6, 2, 0);
			break;
		case 10:
			settings = new Vector4(3, 9, 5, 1);
			break;
		case 11:
			settings = new Vector4(5, 6, 2, 1);
			break;
		case 12:
			settings = new Vector4(4, 8, 4, 0);
			break;
		case 13:
			settings = new Vector4(3, 6, 6, 0);
			break;
		case 14:
			settings = new Vector4(9, 3, 2, 1);
			break;
		case 15:
			settings = new Vector4(3, 10, 3, 1);
			break;
		case 16:
			settings = new Vector4(5, 7, 4, 0);
			break;
		case 17:
			settings = new Vector4(4, 9, 5, 1);
			break;
		case 18:
			settings = new Vector4(8, 3, 7, 0);
			break;
		case 19:
			settings = new Vector4(5, 6, 2, 1);
			break;
		case 20:
			settings = new Vector4(3, 9, 5, 1);
			break;
		case 21:
			settings = new Vector4(5, 6, 2, 0);
			break;
		case 22:
			settings = new Vector4(4, 8, 4, 1);
			break;
		case 23:
			settings = new Vector4(3, 6, 6, 0);
			break;
		case 24:
			settings = new Vector4(9, 3, 2, 0);
			break;
		case 25:
			settings = new Vector4(3, 10, 3, 1);
			break;
		case 26:
			settings = new Vector4(5, 7, 4, 1);
			break;
		case 27:
			settings = new Vector4(4, 9, 5, 0);
			break;
		case 28:
			settings = new Vector4(8, 3, 7, 1);
			break;
		case 29:
			settings = new Vector4(5, 6, 2, 0);
			break;
		case 30:
			settings = new Vector4(3, 9, 5, 1);
			break;
		case 31:
			settings = new Vector4(4, 3, 5, 0);
			break;
		default:
			settings = new Vector4(3, 3, 0, 1);
			break;
		}

		return settings;
	}

}