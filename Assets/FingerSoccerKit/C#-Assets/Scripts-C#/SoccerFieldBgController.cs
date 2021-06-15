using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerFieldBgController : MonoBehaviour {

	public Material[] availableFields;
	private int randomFieldId;				//if we want to use a random field for the game
	private int selectedFieldId;			//selected stadium in config scene

	void Start () {

		selectedFieldId = PlayerPrefs.GetInt ("GameField");			
		randomFieldId = Random.Range (0, availableFields.Length);

		//if this is a normal play, use the selected stadium
		GetComponent<Renderer> ().material = availableFields [selectedFieldId];

		//if this is a tournament match, use a random stadium
		if(PlayerPrefs.GetInt("IsTournament") == 1) {
			GetComponent<Renderer> ().material = availableFields [randomFieldId];
		}

	}

}
