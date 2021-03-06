using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameFormation : MonoBehaviour {

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
	public Button Formation_2,Formation_3,Formation_4,Formation_5,Formation_6,Formation_7,Formation_8,Formation_9,Formation_10,Formation_11,Formation_12,Formation_13,done;
	
	[Header("GameObject Canvas")]
	public GameObject tickGo;
	public Text requestByLabel;

	[Header("Manage Canvas")]
	public GameObject Formation;
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
		Formation_6.onClick.AddListener(() =>
		{
			saveNewFormationSetting (5);
			moveTickToPosition(Formation_6.gameObject.transform.position);
		});
		Formation_7.onClick.AddListener(() =>
		{
			saveNewFormationSetting (6);
			moveTickToPosition(Formation_7.gameObject.transform.position);
		});
		Formation_8.onClick.AddListener(() =>
		{
			saveNewFormationSetting (7);
			moveTickToPosition(Formation_8.gameObject.transform.position);
		});
		Formation_9.onClick.AddListener(() =>
		{
			saveNewFormationSetting (8);
			moveTickToPosition(Formation_9.gameObject.transform.position);
		});
		Formation_10.onClick.AddListener(() =>
		{
			saveNewFormationSetting (9);
			moveTickToPosition(Formation_10.gameObject.transform.position);
		});
		Formation_11.onClick.AddListener(() =>
		{
			saveNewFormationSetting (10);
			moveTickToPosition(Formation_11.gameObject.transform.position);
		});
		Formation_12.onClick.AddListener(() =>
		{
			saveNewFormationSetting (11);
			moveTickToPosition(Formation_12.gameObject.transform.position);
		});
		Formation_13.onClick.AddListener(() =>
		{
			saveNewFormationSetting (12);
			moveTickToPosition(Formation_13.gameObject.transform.position);
		});
		done.onClick.AddListener(() =>
		{
			Formation.SetActive(false);
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
