using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutGameFormation : MonoBehaviour {

	/// <summary>
	/// In-game formation manager
	/// </summary>

	//we need to know if player-1 or player-2 are changing their formation!
	//so we assign an ID for each one to know who is sending the request.
	// ID 1 = Player-1
	// ID 2 = Player-2
	
	public static int formationChangeRequestID;
	
	[Header("Button Canvas Foramtion In Game")]
	public Button Formation_1;
	public Button Formation_2,Formation_3,Formation_4,Formation_5,done;
	
	[Header("GameObject Canvas")]
	public GameObject tickGo;
	public Text requestByLabel;

	[Header("Manage Canvas")]
	public Canvas Formation;
	public Canvas profile;
	private int player1Formation;
	private int player2Formation;


	void Start () {

		//fetchFormations ();
		
		Formation_1.onClick.AddListener(() =>
		{
			saveNewFormationSetting (0);
			moveTickToPosition(Formation_1.gameObject.transform.position);
		});
		Formation_2.onClick.AddListener(() =>
		{
			saveNewFormationSetting (1);
			moveTickToPosition(Formation_2.gameObject.transform.position);
		});
		Formation_3.onClick.AddListener(() =>
		{
			saveNewFormationSetting (2);
			moveTickToPosition(Formation_3.gameObject.transform.position);
		});
		Formation_4.onClick.AddListener(() =>
		{
			saveNewFormationSetting (3);
			moveTickToPosition(Formation_4.gameObject.transform.position);
		});
		Formation_5.onClick.AddListener(() =>
		{
			saveNewFormationSetting (4);
			moveTickToPosition(Formation_5.gameObject.transform.position);
		});
		done.onClick.AddListener(() =>
		{
			Formation.enabled = false;
			profile.enabled = true;
		});
		
	}

	void OnEnable() {

		fetchFormations ();
	}


	/// <summary>
	/// Restore previous formation settings for each player upon formation change
	/// </summary>
	void fetchFormations() {
		
		//get current formation
		player1Formation = PlayerPrefs.GetInt("PlayerFormation");
		player2Formation = PlayerPrefs.GetInt("Player2Formation");

		print ("formationChangeRequestID: " + formationChangeRequestID);
		print ("player1FormationID: " + player1Formation + " | player2FormationID: " + player2Formation);

	/*	if (formationChangeRequestID == 1)
			moveTickToPosition ( Formation_1[player1Formation].transform.position );
		else if (formationChangeRequestID == 2)
			moveTickToPosition ( Formation_1[player2Formation].transform.position );	
*/
	}
		
	
	void Update () {
		
		//monitor request label text
		requestByLabel.text = "(Player " + formationChangeRequestID + ")";
	}


	/// <summary>
	/// move tick over the selected formation image
	/// </summary>
	/// <param name="newPos">New position.</param>
	void moveTickToPosition(Vector3 newPos) {
		

		//move tick over the selected formation image
		tickGo.transform.position = newPos + new Vector3 (0, 0, -1);

	}


	/// <summary>
	/// Saves the new formation setting for the player who requested it
	/// </summary>
	void saveNewFormationSetting(int newFormationID) {

		//save
		if(formationChangeRequestID == 1)
			PlayerPrefs.SetInt("PlayerFormation", newFormationID);
		if(formationChangeRequestID == 2)
			PlayerPrefs.SetInt("Player2Formation", newFormationID);

		//debug
		print("New formation setting has been saved for Player " + formationChangeRequestID + " | Formation ID: " + newFormationID);

	}
}
