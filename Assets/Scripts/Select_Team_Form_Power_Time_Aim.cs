using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Select_Team_Form_Power_Time_Aim : MonoBehaviour {
	


	private float buttonAnimationSpeed = 11;	//speed on animation effect when tapped on button
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
        for (int i = 0; i < 12; i++)
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
		Use_Team[0].onClick.AddListener(() =>
		{
			used_Team_After_Click[0].SetActive(true);
			used_Team_After_Click[1].SetActive(false);
			used_Team_After_Click[2].SetActive(false);
			used_Team_After_Click[3].SetActive(false);
			used_Team_After_Click[4].SetActive(false);
			used_Team_After_Click[5].SetActive(false);
			used_Team_After_Click[6].SetActive(false);
			used_Team_After_Click[7].SetActive(false);
			used_Team_After_Click[8].SetActive(false);
			used_Team_After_Click[9].SetActive(false);
			used_Team_After_Click[10].SetActive(false);
			used_Team_After_Click[11].SetActive(false);
			
			PlayerPrefs.SetInt("PlayerFlag", 0);
		});
		Use_Team[1].onClick.AddListener(() =>
		{
			used_Team_After_Click[1].SetActive(true);
			used_Team_After_Click[0].SetActive(false);
			used_Team_After_Click[2].SetActive(false);
			used_Team_After_Click[3].SetActive(false);
			used_Team_After_Click[4].SetActive(false);
			used_Team_After_Click[5].SetActive(false);
			used_Team_After_Click[6].SetActive(false);
			used_Team_After_Click[7].SetActive(false);
			used_Team_After_Click[8].SetActive(false);
			used_Team_After_Click[9].SetActive(false);
			used_Team_After_Click[10].SetActive(false);
			used_Team_After_Click[11].SetActive(false);
			PlayerPrefs.SetInt("PlayerFlag", 1);
		});
		Use_Team[2].onClick.AddListener(() =>
		{
			used_Team_After_Click[2].SetActive(true);
			used_Team_After_Click[1].SetActive(false);
			used_Team_After_Click[0].SetActive(false);
			used_Team_After_Click[3].SetActive(false);
			used_Team_After_Click[4].SetActive(false);
			used_Team_After_Click[5].SetActive(false);
			used_Team_After_Click[6].SetActive(false);
			used_Team_After_Click[7].SetActive(false);
			used_Team_After_Click[8].SetActive(false);
			used_Team_After_Click[9].SetActive(false);
			used_Team_After_Click[10].SetActive(false);
			used_Team_After_Click[11].SetActive(false);
			PlayerPrefs.SetInt("PlayerFlag", 2);
		});
		Use_Team[3].onClick.AddListener(() =>
		{
			used_Team_After_Click[3].SetActive(true);
			used_Team_After_Click[1].SetActive(false);
			used_Team_After_Click[0].SetActive(false);
			used_Team_After_Click[2].SetActive(false);
			used_Team_After_Click[4].SetActive(false);
			used_Team_After_Click[5].SetActive(false);
			used_Team_After_Click[6].SetActive(false);
			used_Team_After_Click[7].SetActive(false);
			used_Team_After_Click[8].SetActive(false);
			used_Team_After_Click[9].SetActive(false);
			used_Team_After_Click[10].SetActive(false);
			used_Team_After_Click[11].SetActive(false);
			PlayerPrefs.SetInt("PlayerFlag", 3);
		});
		Use_Team[4].onClick.AddListener(() =>
		{
			used_Team_After_Click[4].SetActive(true);
			used_Team_After_Click[1].SetActive(false);
			used_Team_After_Click[0].SetActive(false);
			used_Team_After_Click[3].SetActive(false);
			used_Team_After_Click[2].SetActive(false);
			used_Team_After_Click[5].SetActive(false);
			used_Team_After_Click[6].SetActive(false);
			used_Team_After_Click[7].SetActive(false);
			used_Team_After_Click[8].SetActive(false);
			used_Team_After_Click[9].SetActive(false);
			used_Team_After_Click[10].SetActive(false);
			used_Team_After_Click[11].SetActive(false);
			PlayerPrefs.SetInt("PlayerFlag", 4);
		});
		Use_Team[5].onClick.AddListener(() =>
		{
			used_Team_After_Click[5].SetActive(true);
			used_Team_After_Click[1].SetActive(false);
			used_Team_After_Click[0].SetActive(false);
			used_Team_After_Click[3].SetActive(false);
			used_Team_After_Click[4].SetActive(false);
			used_Team_After_Click[2].SetActive(false);
			used_Team_After_Click[6].SetActive(false);
			used_Team_After_Click[7].SetActive(false);
			used_Team_After_Click[8].SetActive(false);
			used_Team_After_Click[9].SetActive(false);
			used_Team_After_Click[10].SetActive(false);
			used_Team_After_Click[11].SetActive(false);
			PlayerPrefs.SetInt("PlayerFlag", 5);
		});
		Use_Team[6].onClick.AddListener(() =>
		{
			used_Team_After_Click[6].SetActive(true);
			used_Team_After_Click[1].SetActive(false);
			used_Team_After_Click[0].SetActive(false);
			used_Team_After_Click[3].SetActive(false);
			used_Team_After_Click[4].SetActive(false);
			used_Team_After_Click[5].SetActive(false);
			used_Team_After_Click[2].SetActive(false);
			used_Team_After_Click[7].SetActive(false);
			used_Team_After_Click[8].SetActive(false);
			used_Team_After_Click[9].SetActive(false);
			used_Team_After_Click[10].SetActive(false);
			used_Team_After_Click[11].SetActive(false);
			PlayerPrefs.SetInt("PlayerFlag", 6);
		});
		Use_Team[7].onClick.AddListener(() =>
		{
			used_Team_After_Click[7].SetActive(true);
			used_Team_After_Click[1].SetActive(false);
			used_Team_After_Click[0].SetActive(false);
			used_Team_After_Click[3].SetActive(false);
			used_Team_After_Click[4].SetActive(false);
			used_Team_After_Click[5].SetActive(false);
			used_Team_After_Click[6].SetActive(false);
			used_Team_After_Click[2].SetActive(false);
			used_Team_After_Click[8].SetActive(false);
			used_Team_After_Click[9].SetActive(false);
			used_Team_After_Click[10].SetActive(false);
			used_Team_After_Click[11].SetActive(false);
			PlayerPrefs.SetInt("PlayerFlag", 7);
		});
		Use_Team[8].onClick.AddListener(() =>
		{
			used_Team_After_Click[8].SetActive(true);
			used_Team_After_Click[1].SetActive(false);
			used_Team_After_Click[0].SetActive(false);
			used_Team_After_Click[3].SetActive(false);
			used_Team_After_Click[4].SetActive(false);
			used_Team_After_Click[5].SetActive(false);
			used_Team_After_Click[6].SetActive(false);
			used_Team_After_Click[7].SetActive(false);
			used_Team_After_Click[2].SetActive(false);
			used_Team_After_Click[9].SetActive(false);
			used_Team_After_Click[10].SetActive(false);
			used_Team_After_Click[11].SetActive(false);
			PlayerPrefs.SetInt("PlayerFlag", 8);
		});
		Use_Team[9].onClick.AddListener(() =>
		{
			used_Team_After_Click[9].SetActive(true);
			used_Team_After_Click[1].SetActive(false);
			used_Team_After_Click[0].SetActive(false);
			used_Team_After_Click[3].SetActive(false);
			used_Team_After_Click[4].SetActive(false);
			used_Team_After_Click[5].SetActive(false);
			used_Team_After_Click[6].SetActive(false);
			used_Team_After_Click[7].SetActive(false);
			used_Team_After_Click[8].SetActive(false);
			used_Team_After_Click[2].SetActive(false);
			used_Team_After_Click[10].SetActive(false);
			used_Team_After_Click[11].SetActive(false);
			PlayerPrefs.SetInt("PlayerFlag", 9);
		});
		Use_Team[10].onClick.AddListener(() =>
		{
			used_Team_After_Click[10].SetActive(true);
			used_Team_After_Click[1].SetActive(false);
			used_Team_After_Click[0].SetActive(false);
			used_Team_After_Click[3].SetActive(false);
			used_Team_After_Click[4].SetActive(false);
			used_Team_After_Click[5].SetActive(false);
			used_Team_After_Click[6].SetActive(false);
			used_Team_After_Click[7].SetActive(false);
			used_Team_After_Click[8].SetActive(false);
			used_Team_After_Click[9].SetActive(false);
			used_Team_After_Click[2].SetActive(false);
			used_Team_After_Click[11].SetActive(false);
			PlayerPrefs.SetInt("PlayerFlag", 10);
		});
		Use_Team[11].onClick.AddListener(() =>
		{
			used_Team_After_Click[11].SetActive(true);
			used_Team_After_Click[1].SetActive(false);
			used_Team_After_Click[0].SetActive(false);
			used_Team_After_Click[3].SetActive(false);
			used_Team_After_Click[4].SetActive(false);
			used_Team_After_Click[5].SetActive(false);
			used_Team_After_Click[6].SetActive(false);
			used_Team_After_Click[7].SetActive(false);
			used_Team_After_Click[8].SetActive(false);
			used_Team_After_Click[9].SetActive(false);
			used_Team_After_Click[10].SetActive(false);
			used_Team_After_Click[2].SetActive(false);
			PlayerPrefs.SetInt("PlayerFlag", 11);
		});
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