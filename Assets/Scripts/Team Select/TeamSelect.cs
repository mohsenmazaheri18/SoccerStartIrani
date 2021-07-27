using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeamSelect : MonoBehaviour {
	

	
	private int barScaleDivider = 10;			//we divide actual time/power setting of each team by this number
	private bool  canTap = true;				//flag to prevent double tap
	
	[Header("Sound")]
	public AudioClip tapSfx;					//tap sound for buttons click

	[Header("Button To Use")]
	public Button[] Use_Team;
	public GameObject[] used_Team_After_Click;
	
	[Header("GameObject Team Details")]
	public GameObject[] p1PowerBar;
	public GameObject[] p1TimeBar;
    public GameObject[] p1AimBar;
    
    

	void Awake ()
	{


		PlayerPrefs.SetInt("Used_Click", 0);

			//The Slider Power & Aim & Time in my profile mohreh
        for (int i = 0; i < 108; i++)
        {
	        p1PowerBar[i].transform.localScale = new Vector3(
		        TeamsManager.getTeamSettings(i).x / barScaleDivider,
		        p1PowerBar[i].transform.localScale.y,
		        p1PowerBar[i].transform.localScale.z);

	        p1TimeBar[i].transform.localScale = new Vector3(
		        TeamsManager.getTeamSettings(i).y / barScaleDivider,
		        p1TimeBar[i].transform.localScale.y,
		        p1TimeBar[i].transform.localScale.z);

	        p1AimBar[i].transform.localScale = new Vector3(
		        TeamsManager.getTeamSettings(i).z / barScaleDivider,
		        p1AimBar[i].transform.localScale.y,
		        p1AimBar[i].transform.localScale.z);
        }

	}

	void Start()
	{
		//use team when click in profile Mohreh and player prefs actived!
		for (int i = 0; i < Use_Team.Length; i++)
		{
			Use_Team[i].onClick.AddListener(() =>
			{
				button_True_False(true);
				PlayerPrefs.SetInt("PlayerFlag", Use_Team.Length);
			});
		}
	}


	//check if the selected team is locked or selectable
	void checkTeamLockState(GameObject teamLock, int teamCounter) {
		//check for initial team lock settings
		print(teamLock.name + " (" + teamCounter + ") state is: " + TeamsManager.getTeamSettings (teamCounter).w);
		if (TeamsManager.getTeamSettings (teamCounter).w == 1) {
			teamLock.SetActive (false);

		} else {
			//now check for shop settings if user has purchased this team
			if (PlayerPrefs.GetInt ("shopTeam-" + teamCounter.ToString ()) == 1) {
				print ("Player has already purchased this team!");
				teamLock.SetActive (false);
			} else
				teamLock.SetActive (true);
		}			
	}

	void button_True_False(bool falsed)
	{
		used_Team_After_Click[0].SetActive(falsed);
	}

	//*****************************************************************************
	// Play sound clips
	//*****************************************************************************
	void playSfx ( AudioClip _clip  ){
		GetComponent<AudioSource>().clip = _clip;
		if(!GetComponent<AudioSource>().isPlaying) {
			GetComponent<AudioSource>().Play();
		}
	}

}