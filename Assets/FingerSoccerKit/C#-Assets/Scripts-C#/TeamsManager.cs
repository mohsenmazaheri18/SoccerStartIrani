using UnityEngine;
using System.Collections;

public class TeamsManager : MonoBehaviour
{


	///*************************************************************************///
	/// Main Teams manager.
	/// You can define new teams here.
	/// Team attributes are set as x, y and z component of a vector3.
	/// They should be set from 1 (min) to 10 (max).
	/// x = power
	/// y = time
	/// z = aim
	///*************************************************************************///

	public static int teams = 109; //total number of available teams

	//Power differs from 1 (weakest) to 10 (strongest) (base power: 35)
	//additional time differs from 1 seconds (little) to 10 seconds (too much) (base time: 15 seconds)
	//w value of vector 4 indicates the lock/unlock state of the selected team (0 = locked, 1 = unlocked)

	public static Vector4 getTeamSettings(int _teamID)
	{
		Vector4 settings = Vector4.zero;
		switch (_teamID)
		{

			//Country 

			case 0:
				//Settings: Vector4(power, time, aim, locked/unlocked)
				settings = new Vector4(7, 5, 3, 1);
				break;
			case 1:
				settings = new Vector4(5, 6, 5, 0);
				break;
			case 2:
				settings = new Vector4(4, 8, 2, 0);
				break;
			case 3:
				settings = new Vector4(3, 6, 6, 0);
				break;
			case 4:
				settings = new Vector4(9, 3, 2, 0);
				break;
			case 5:
				settings = new Vector4(3, 10, 3, 0);
				break;
			case 6:
				settings = new Vector4(5, 7, 4, 0);
				break;
			case 7:
				settings = new Vector4(4, 9, 5, 0);
				break;
			case 8:
				settings = new Vector4(8, 3, 7, 0);
				break;
			case 9:
				settings = new Vector4(5, 6, 2, 0);
				break;
			case 10:
				settings = new Vector4(3, 9, 5, 0);
				break;
			case 11:
				settings = new Vector4(5, 6, 2, 0);
				break;
			case 12:
				settings = new Vector4(4, 8, 4, 0);
				break;
			case 13:
				settings = new Vector4(3, 6, 6, 0);
				break;
			case 14:
				settings = new Vector4(9, 3, 2, 0);
				break;
			case 15:
				settings = new Vector4(3, 10, 3, 0);
				break;
			case 16:
				settings = new Vector4(5, 7, 4, 0);
				break;
			case 17:
				settings = new Vector4(4, 9, 5, 0);
				break;
			case 18:
				settings = new Vector4(8, 3, 7, 0);
				break;
			case 19:
				settings = new Vector4(5, 6, 2, 0);
				break;
			case 20:
				settings = new Vector4(3, 9, 5, 0);
				break;
			case 21:
				settings = new Vector4(5, 6, 2, 0);
				break;
			case 22:
				settings = new Vector4(4, 8, 4, 0);
				break;
			case 23:
				settings = new Vector4(3, 6, 6, 0);
				break;
			case 24:
				settings = new Vector4(9, 3, 2, 0);
				break;
			case 25:
				settings = new Vector4(3, 10, 3, 0);
				break;
			case 26:
				settings = new Vector4(5, 7, 4, 0);
				break;
			case 27:
				settings = new Vector4(4, 9, 5, 0);
				break;
			case 28:
				settings = new Vector4(8, 3, 7, 0);
				break;
			case 29:
				settings = new Vector4(5, 6, 2, 0);
				break;
			case 30:
				settings = new Vector4(3, 9, 5, 0);
				break;
			case 31:
				settings = new Vector4(4, 3, 5, 0);
				break;

			//My Stery
			case 32:
				settings = new Vector4(4, 4, 3, 0);
				break;
			case 33:
				settings = new Vector4(3, 4, 5, 0);
				break;
			case 34:
				settings = new Vector4(5, 3, 4, 0);
				break;
			case 35:
				settings = new Vector4(6, 4, 4, 0);
				break;
			case 36:
				settings = new Vector4(4, 3, 3, 0);
				break;
			case 37:
				settings = new Vector4(3, 6, 8, 0);
				break;
			case 38:
				settings = new Vector4(5, 5, 7, 0);
				break;
			case 39:
				settings = new Vector4(8, 3, 5, 0);
				break;
			case 40:
				settings = new Vector4(7, 6, 5, 0);
				break;
			case 41:
				settings = new Vector4(4, 5, 6, 0);
				break;
			case 42:
				settings = new Vector4(4, 3, 5, 0);
				break;
			case 43:
				settings = new Vector4(4, 5, 5, 0);
				break;
			case 44:
				settings = new Vector4(6, 6, 6, 0);
				break;
			case 45:
				settings = new Vector4(5, 4, 3, 0);
				break;
			case 46:
				settings = new Vector4(5, 3, 3, 0);
				break;

			//Ligeh Bartar
			
			case 47:
				settings = new Vector4(6, 4, 7, 0);
				break;
			case 48:
				settings = new Vector4(5, 3, 5, 0);
				break;
			case 49:
				settings = new Vector4(4, 6, 3, 0);
				break;
			case 50:
				settings = new Vector4(5, 4, 4, 0);
				break;
			case 51:
				settings = new Vector4(6, 4, 7, 0);
				break;
			case 52:
				settings = new Vector4(5, 6, 5, 0);
				break;
			case 53:
				settings = new Vector4(4, 3, 6, 0);
				break;
			case 54:
				settings = new Vector4(5, 2, 4, 0);
				break;
			case 55:
				settings = new Vector4(4, 8, 6, 0);
				break;
			case 56:
				settings = new Vector4(6, 6, 4, 0);
				break;
			case 57:
				settings = new Vector4(3, 4, 6, 0);
				break;
			case 58:
				settings = new Vector4(4, 8, 3, 0);
				break;
			case 59:
				settings = new Vector4(5, 2, 5, 0);
				break;
			case 60:
				settings = new Vector4(5, 5, 4, 0);
				break;
			case 61:
				settings = new Vector4(6, 7, 3, 0);
				break;
			case 62:
				settings = new Vector4(5, 6, 4, 0);
				break;
			case 63:
				settings = new Vector4(5, 8, 4, 0);
				break;

			
			//Ligeh Dasteh1
			case 64:
				settings = new Vector4(4, 3, 5, 0);
				break;
			case 65:
				settings = new Vector4(5, 5, 3, 0);
				break;
			case 66:
				settings = new Vector4(3, 6, 6, 0);
				break;
			case 67:
				settings = new Vector4(5, 3, 4, 0);
				break;
			case 68:
				settings = new Vector4(6, 3, 5, 0);
				break;
			case 69:
				settings = new Vector4(4, 7, 2, 0);
				break;
			case 70:
				settings = new Vector4(5, 5, 7, 0);
				break;
			case 71:
				settings = new Vector4(7, 4, 4, 0);
				break;
			case 72:
				settings = new Vector4(4, 3, 5, 0);
				break;
			case 73:
				settings = new Vector4(4, 4, 3, 0);
				break;
			case 74:
				settings = new Vector4(3, 3, 4, 0);
				break;
			case 75:
				settings = new Vector4(7, 7, 5, 0);
				break;
			case 76:
				settings = new Vector4(6, 5, 6, 0);
				break;
			case 77:
				settings = new Vector4(5, 5, 5, 0);
				break;
			case 78:
				settings = new Vector4(4, 4, 3, 0);
				break;
			case 79:
				settings = new Vector4(5, 3, 4, 0);
				break;
			case 80:
				settings = new Vector4(5, 5, 5, 0);
				break;
			case 81:
				settings = new Vector4(4, 4, 3, 0);
				break;
			case 82:
				settings = new Vector4(5, 3, 4, 0);
				break;
			case 83:
				settings = new Vector4(6, 3, 5, 0);
				break;
			case 84:
				settings = new Vector4(4, 7, 2, 0);
				break;
			case 85:
				settings = new Vector4(5, 5, 7, 0);
				break;
			case 86:
				settings = new Vector4(4, 3, 5, 0);
				break;
			case 87:
				settings = new Vector4(5, 5, 3, 0);
				break;
			case 88:
				settings = new Vector4(3, 6, 6, 0);
				break;
			case 89:
				settings = new Vector4(5, 3, 4, 0);
				break;
			case 90:
				settings = new Vector4(6, 3, 5, 0);
				break;
			case 91:
				settings = new Vector4(4, 7, 2, 0);
				break;
			
			//Offical
			case 92:
				settings = new Vector4(5, 6, 5, 0);
				break;
			case 93:
				settings = new Vector4(4, 8, 2, 0);
				break;
			case 94:
				settings = new Vector4(3, 6, 6, 0);
				break;
			case 95:
				settings = new Vector4(9, 3, 2, 0);
				break;
			case 96:
				settings = new Vector4(3, 10, 3, 0);
				break;
			case 97:
				settings = new Vector4(5, 7, 4, 0);
				break;
			case 98:
				settings = new Vector4(4, 9, 5, 0);
				break;
			case 99:
				settings = new Vector4(8, 3, 7, 0);
				break;
			case 100:
				settings = new Vector4(5, 6, 2, 0);
				break;
			case 101:
				settings = new Vector4(3, 9, 5, 0);
				break;
			case 102:
				settings = new Vector4(5, 6, 2, 0);
				break;
			case 103:
				settings = new Vector4(4, 8, 4, 0);
				break;
			case 104:
				settings = new Vector4(3, 6, 6, 0);
				break;
			case 105:
				settings = new Vector4(9, 3, 2, 0);
				break;
			case 106:
				settings = new Vector4(3, 10, 3, 0);
				break;
			case 107:
				settings = new Vector4(5, 7, 4, 0);
				break;
			
			default:
				settings = new Vector4(3, 3, 0, 0); 
				break;
		}
		return settings;
	}

}