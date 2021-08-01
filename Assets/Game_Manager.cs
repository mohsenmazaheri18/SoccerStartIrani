using System.Collections;
using System.Collections.Generic;
using FiroozehGameService.Core;
using FiroozehGameService.Handlers;
using FiroozehGameService.Models.GSLive;
using FiroozehGameService.Models.GSLive.TB;
using UnityEngine;


public class Game_Manager : MonoBehaviour
{
	private bool gameIsFinished;

	public class TurnedPlayer1
	{
		//Turns in flags

		public Texture2D[] AvailableFlags; //array of all available teams
		public static bool PlayersTurn;
		public static bool OpponentsTurn;
		public GameObject[] PlayerTeam;
		public static int PlayerFormation;			//player-1 formation
		public static int PlayerFlag;				//player-1 team flag

		public TurnedPlayer1(bool playersTurn, bool opponentsTurn, Texture2D[] availableFlags)
		{
			this.AvailableFlags = availableFlags;
			
			if (PlayersTurn)
			{
				PlayersTurn = playersTurn;
				PlayersTurn = true;
				playerController.canShoot = true;
				OpponentsTurn = opponentsTurn;
				PlayerFlag = PlayerPrefs.GetInt("PlayerFlag");
				PlayerFormation = PlayerPrefs.GetInt("PlayerFormation");
				PlayerTeam = GameObject.FindGameObjectsWithTag("Player");
				changeFormation(PlayerTeam, PlayerFormation, 1, 1);
				goToPosition(new GameObject[playerShoots], new Vector3(0, 0, 0), 1);
				;
				int i = 1;
				foreach (GameObject unit in PlayerTeam)
				{
					//Optional
					unit.name = "PlayerUnit-" + i;
					unit.GetComponent<playerController>().unitIndex = i;
					unit.GetComponent<Renderer>().material.mainTexture = availableFlags[PlayerFlag];
					i++;
				}

				if (playerController.canShoot)
				{
					GameService.GSLive.TurnBased().ChooseNext();
					TurnBasedEventHandlers.ChoosedNext += ChoosedNext;
				}
			}
			else

			{
				PlayersTurn = playersTurn;
				PlayersTurn = false;
				playerController.canShoot = false;
				OpponentsTurn = opponentsTurn;
				OpponentsTurn = true;
				OpponentAI.opponentCanShoot = true;
				PlayerFlag = PlayerPrefs.GetInt("PlayerFlag");
				PlayerFormation = PlayerPrefs.GetInt("PlayerFormation");
				PlayerTeam = GameObject.FindGameObjectsWithTag("Player");
				changeFormation(PlayerTeam, PlayerFormation, 1, 1);
				;
				int i = 1;
				foreach (GameObject unit in PlayerTeam)
				{
					//Optional
					unit.name = "PlayerUnit-" + i;
					unit.GetComponent<playerController>().unitIndex = i;
					unit.GetComponent<Renderer>().material.mainTexture = availableFlags[PlayerFlag];
					i++;
				}
				if (playerController.canShoot)
				{
					GameService.GSLive.TurnBased().ChooseNext();
					TurnBasedEventHandlers.ChoosedNext += ChoosedNext;
				}
			}
		}

		private void ChoosedNext(object sender, Member member)
		{
			if (member.User.IsMe)
			{
				PlayersTurn = false;
				playerController.canShoot = true;
				OpponentsTurn = true;
				OpponentAI.opponentCanShoot = false;
				playerShoots = 1;
				if (playerShoots==1)
				{
					PlayersTurn = true;
					playerController.canShoot = false;
					OpponentsTurn = false;
					OpponentAI.opponentCanShoot = true;
					playerShoots = 0;
				}
			}
			else
			{
				PlayersTurn = true;
				playerController.canShoot = false;
				OpponentsTurn = true;
				OpponentAI.opponentCanShoot = false;
				playerShoots = 1;
				if (playerShoots==1)
				{
					PlayersTurn = false;
					playerController.canShoot = true;
					OpponentsTurn = false;
					OpponentAI.opponentCanShoot = true;
					playerShoots = 0;
				}
			}
		}
		public IEnumerator changeFormation ( GameObject[] _team ,   int _formationIndex ,   float _speed ,   int _dir  ){

			//cache the initial position of all units
			List<Vector3> unitsSartingPosition = new List<Vector3>();
			foreach(GameObject unit in _team) {
				unitsSartingPosition.Add(unit.transform.position); //get the initial postion of this unit for later use.
				unit.GetComponent<MeshCollider>().enabled = false;	//no collision for this unit till we are done with re positioning.
			}
		
			float t = 0;
			while(t < 1) {
				t += Time.deltaTime * _speed;
				for(int cnt = 0; cnt < _team.Length; cnt++) {
					_team[cnt].transform.position = new Vector3(	 Mathf.SmoothStep(	unitsSartingPosition[cnt].x, 
							FormationManager.getPositionInFormation(_formationIndex, cnt).x * _dir,
							t),
						Mathf.SmoothStep(	unitsSartingPosition[cnt].y, 
							FormationManager.getPositionInFormation(_formationIndex, cnt).y,
							t),
						FormationManager.fixedZ );
				}		
				yield return 0;
			}
		
			if(t >= 1) {
				foreach(GameObject unit in _team)
					unit.GetComponent<MeshCollider>().enabled = true; //collision is now enabled.
			}
		}
		public IEnumerator goToPosition ( GameObject[] unit, Vector3 pos,   float _speed  ){

			//first we need to completely freeze the unit
			unit[0].GetComponent<Rigidbody>().velocity = Vector3.zero;
			unit[0].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			print (unit[0].name + " position is fixed.");

			Vector3 unitsSartingPosition = unit[0].transform.position;
			unit[0].GetComponent<MeshCollider>().enabled = false;	//no collision for this unit till we are done with re positioning.

			float t = 0;
			while(t < 1) {
				t += Time.deltaTime * _speed;
				unit[0].transform.position = new Vector3( Mathf.SmoothStep(unitsSartingPosition.x, pos.x, t),
					Mathf.SmoothStep(unitsSartingPosition.y, pos.y, t),
					unitsSartingPosition.z );
				
				yield return 0;
			}

			if(t >= 1) {
				unit[0].GetComponent<MeshCollider>().enabled = true;
			}
		}
	}
	

	// fill time bar 

	//available time to think and shoot
	private float _p1ShootTime; //additional time (based on the selected team) for p1
	private float _p2ShootTime; //additional time (based on the selected team) for p2 or AI
	public GameObject p1TimeBar;
	public GameObject p2TimeBar;
	private float _p1TimeBarInitScale;
	private float _p1TimeBarCurrentScale;
	private float _p2TimeBarInitScale;
	private float _p2TimeBarCurrentScale;

	//Special occasions
	public  bool goalHappened;
	private static bool _shootHappened;
	private static int goalLimit = 10; //To finish the game quickly, without letting the GameTime end.

	//Game Status
	private static int _playerGoals;
	private static int _opponentGoals;
	private static float _gameTime; //Main game timer (in seconds). Always fixed.
	
	//mamixmu distance that players can drag away from selected unit to shoot the ball (is in direct relation with shoot power)
	public static float maxDistance = 3.0f;


	//After players did their shoots, the round changes after this amount of time.
	private static float timeStepToAdvanceRound = 3;

	//AudioClips
	public AudioClip startWistle;
	public AudioClip finishWistle;
	public AudioClip[] goalSfx;
	public AudioClip[] goalHappenedSfx;
	public AudioClip[] crowdChants;
	private bool _canPlayCrowdChants;

	//gameObject references
	private GameObject _playerAIController;
	private GameObject _opponentAIController;
	public GameObject goalPlane;

	public static float baseShootTime = 15;		//fixed shoot time for all players and AI
	
	//ball
	private GameObject _ball;
	private Vector3 _ballStartingPosition;

	//Public references
	public GameObject gameStatusPlane; //user to show win/lose result at the end of match
	public GameObject statusTextureObject; //plane we use to show the result texture in 3d world
	public Texture2D[] statusModes; //Available status textures
	
	//summary information
	public static int playerPasses;
	public static int playerShoots;
	public static int playerShootToGate;
	public static int opponentPasses;
	public static int opponentShoots;
	public static int opponentShootToGate;

	// Start is called before the first frame update
	async void Start()
	{
		await GameService.GSLive.TurnBased().TakeTurn(typeof(TurnedPlayer1).ToString());
		TurnBasedEventHandlers.TakeTurn += TakeTurn;

		await GameService.GSLive.TurnBased().GetRoomMembersDetail();
		TurnBasedEventHandlers.RoomMembersDetailReceived += RoomMembersDetailReceived;
		
	}

	private void RoomMembersDetailReceived(object sender, List<Member> memberse)
	{
		if (memberse[0].User.IsMe)
		{
			playerOneName.GetComponent<TextMesh>().text = memberse[0].Name;
			playerTwoName.GetComponent<TextMesh>().text = memberse[1].Name;
		}

		if (!memberse[1].User.IsMe) return;
		playerOneName.GetComponent<TextMesh>().text = memberse[1].Name;
		playerTwoName.GetComponent<TextMesh>().text = memberse[0].Name;

	}

	private void TakeTurn(object sender, Turn turn)
	{

		if (turn.WhoTakeTurn.User.IsMe)
		{
			TurnedPlayer1.PlayersTurn = true;
			TurnedPlayer1.OpponentsTurn = false;
			_p1TimeBarCurrentScale = _p1TimeBarInitScale;
			p1TimeBar.transform.localScale = new Vector3(1, 1, 1);
		}
		else
		{
			TurnedPlayer1.PlayersTurn = false;
			TurnedPlayer1.OpponentsTurn = true;
			_p2TimeBarCurrentScale = _p2TimeBarInitScale;
			p2TimeBar.transform.localScale = new Vector3(1, 1, 1);
		}
	}

	//manage post shooting
	public IEnumerator ManagePostShoot(string shootBy)
	{

		_shootHappened = true;

		//get who is did the shoot
		//if we had a goal after the shoot was done and just before the round change, leave the process to other controllers.
		float t = 0;
		while (t < timeStepToAdvanceRound)
		{
			t += Time.deltaTime;
			if (goalHappened)
			{
				yield break;
			}

			yield return 0;
		}

		//we had a simple shoot with no goal result
		if (!(t >= timeStepToAdvanceRound)) yield break;
		//add to round counters
		switch (shootBy)
		{
			case "Player":
				TurnedPlayer1.PlayersTurn = true;
				TurnedPlayer1.OpponentsTurn = true;
				break;
			case "Player_2":
				TurnedPlayer1.PlayersTurn = false;
				TurnedPlayer1.OpponentsTurn = true;
				break;
		}

		//let the units get to their positions
		yield return new WaitForSeconds(0.5f);

		GameService.GSLive.TurnBased().TakeTurn(typeof(TurnedPlayer1).ToString());
		TurnBasedEventHandlers.TakeTurn += TakeTurn;
	}

	//set new round in game

	private async void SetNewRound(int id)
	{
		switch (id)
		{
			case 1:
				TurnedPlayer1.OpponentsTurn = false;
				TurnedPlayer1.PlayersTurn = true;
				break;
			case 2:
				TurnedPlayer1.OpponentsTurn = true;
				TurnedPlayer1.PlayersTurn = false;
				break;
		}

		await GameService.GSLive.TurnBased().TakeTurn(typeof(TurnedPlayer1).ToString());
		TurnBasedEventHandlers.TakeTurn += TakeTurn;
	}

	//manage post goal

	public IEnumerator ManagePostGoal(string goalBy)
	{
		//get who did the goal.

		//avoid counting a goal as two or more
		if (goalHappened)
			yield break;

		//soft pause the game for reformation and other things...
		goalHappened = true;
		_shootHappened = false;

		//add to goal counters
		switch (goalBy)
		{
			case "Player":
				_playerGoals++;
				TurnedPlayer1.PlayersTurn = true;
				TurnedPlayer1.OpponentsTurn = false;
				break;
			case "Opponent":
				_opponentGoals++;
				TurnedPlayer1.OpponentsTurn = true;
				TurnedPlayer1.PlayersTurn = false;
				break;
		}

		//wait a few seconds to show the effects , and physics cooldown
		PlaySfx(goalSfx[Random.Range(0, goalSfx.Length)]);
		GetComponent<AudioSource>().PlayOneShot(goalHappenedSfx[Random.Range(0, goalHappenedSfx.Length)], 1);
		//yield return new WaitForSeconds(1);
		//activate the goal event plane
		GameObject gp = null;
		gp = Instantiate(goalPlane, new Vector3(30, 0, -2), Quaternion.Euler(0, 180, 0)) as GameObject;
		float t = 0;
		float speed = 2.0f;
		while (t < 1)
		{
			t += Time.deltaTime * speed;
			gp.transform.position = new Vector3(Mathf.SmoothStep(30, 0, t), 0, -2);
			yield return 0;
		}

		yield return new WaitForSeconds(0.75f);
		float t2 = 0;
		while (t2 < 1)
		{
			t2 += Time.deltaTime * speed;
			gp.transform.position = new Vector3(Mathf.SmoothStep(0, -30, t2), 0, -2);
			yield return 0;
		}

		Destroy(gp, 1.5f);

		PlayerPrefs.GetInt("PlayerFormation");

		//bring the ball back to it's initial position
		_ball.GetComponent<TrailRenderer>().enabled = false;
		_ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
		_ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

		_ball.transform.position = _ballStartingPosition; //go to the center of field

		yield return new WaitForSeconds(1);
		_ball.GetComponent<TrailRenderer>().enabled = true;

		yield return new WaitForSeconds(2);

		//check if the game is finished or not
		if (_playerGoals > goalLimit || _opponentGoals > goalLimit)
		{
			gameIsFinished = true;
			ManageGameFinishState();
			yield break;
		}

		//else, continue to the next round
		goalHappened = false;
		GameService.GSLive.TurnBased().TakeTurn(typeof(TurnedPlayer1).ToString());
		TurnBasedEventHandlers.TakeTurn += TakeTurn;
		PlaySfx(startWistle);
	}


	//Play Audio when playing

	void PlaySfx(AudioClip clip)
	{
		GetComponent<AudioSource>().clip = clip;
		if (!GetComponent<AudioSource>().isPlaying)
		{
			GetComponent<AudioSource>().Play();
		}
	}

	//Manage Game Finish 

	public void ManageGameFinishState()
	{
		//Play gameFinish wistle
		PlaySfx(finishWistle);
		print("GAME IS FINISHED.");

		//show gameStatusPlane
		gameStatusPlane.SetActive(true);

		if (_playerGoals > _opponentGoals)
		{
			print("Player 1 is the winner!!");
			statusTextureObject.GetComponent<Renderer>().material.mainTexture = statusModes[2];
		}
		else if (_playerGoals == _opponentGoals)
		{
			print("(Two-Player) We have a Draw!");
			statusTextureObject.GetComponent<Renderer>().material.mainTexture = statusModes[4];
		}
		else if (_playerGoals < _opponentGoals)
		{
			print("Player 2 is the winner!!");
			statusTextureObject.GetComponent<Renderer>().material.mainTexture = statusModes[3];
		}
	}



	//play crowd chants in game sound

	IEnumerator PlayCrowdChants()
	{
		if (!_canPlayCrowdChants) yield break;
		_canPlayCrowdChants = false;
		GetComponent<AudioSource>().PlayOneShot(crowdChants[Random.Range(0, crowdChants.Length)], 1);
		yield return new WaitForSeconds(Random.Range(15, 35));
		_canPlayCrowdChants = true;
	}



	//Game Status Manager

	public GameObject timeText; //UI 3d text object
	public GameObject playerGoalsText; //UI 3d text object
	public GameObject opponentGoalsText; //UI 3d text object
	public GameObject playerOneName; //UI 3d text object
	public GameObject playerTwoName; //UI 3d text object

	///Game timer vars
	private static float _gameTimer; //in seconds

	private string _remainingTime;
	private int _seconds;
	private int _minutes;

	void ManageGameStatus()
	{

		_seconds = Mathf.CeilToInt(_gameTimer - Time.timeSinceLevelLoad) % 60;
		_minutes = Mathf.CeilToInt(_gameTimer - Time.timeSinceLevelLoad) / 60;

		if (_seconds == 0 && _minutes == 0)
		{
			gameIsFinished = true;
			ManageGameFinishState();
		}

		_remainingTime = $"{_minutes:00} : {_seconds:00}";
		timeText.GetComponent<TextMesh>().text = _remainingTime.ToString();

		playerGoalsText.GetComponent<TextMesh>().text = _playerGoals.ToString();
		opponentGoalsText.GetComponent<TextMesh>().text = _opponentGoals.ToString();
	}


// when first in game

	void Awake()
	{

		//debug
		//PlayerPrefs.DeleteAll();

		//init
		goalHappened = false;
		_shootHappened = false;
		gameIsFinished = false;
		_playerGoals = 0;
		_opponentGoals = 0;
		_gameTime = 0;
		TurnedPlayer1.PlayersTurn = true;
		TurnedPlayer1.OpponentsTurn = false;
		_seconds = 0;
		_minutes = 0;
		_canPlayCrowdChants = true;

		//reset summary info
		playerPasses = 0;
		playerShoots = 0;
		playerShootToGate = 0;
		opponentPasses = 0;
		opponentShoots = 0;
		opponentShootToGate = 0;


		//get additonal time for each player and AI
		_p1ShootTime = baseShootTime + TeamsManager.getTeamSettings(PlayerPrefs.GetInt("PlayerFlag")).y;
		_p2ShootTime = baseShootTime + TeamsManager.getTeamSettings(PlayerPrefs.GetInt("Player2Flag")).y;
		print("P1 shoot time: " + _p1ShootTime + " // " + "P2 shoot time: " + _p2ShootTime);

		//hide gameStatusPlane
		gameStatusPlane.SetActive(false);

		//Translate gameTimer index to actual seconds
		switch (PlayerPrefs.GetInt("GameTime"))
		{
			case 0:
				_gameTimer = 180;
				break;
			case 1:
				_gameTimer = 300;
				break;
			case 2:
				_gameTimer = 480;
				break;

			//You can add more cases and options here.
		}

		//only for debug
		//gameTimer = 20;

		//fill player shoot timer to full (only in normal game mode, where these objects are available)

		var localScale = p1TimeBar.transform.localScale;
		_p1TimeBarInitScale = localScale.x;
		_p1TimeBarCurrentScale = localScale.x;
		var scale = p2TimeBar.transform.localScale;
		_p2TimeBarInitScale = scale.x;
		_p2TimeBarCurrentScale = scale.x;
		localScale = new Vector3(1, 1, 1);
		p1TimeBar.transform.localScale = localScale;
		scale = new Vector3(1, 1, 1);
		p2TimeBar.transform.localScale = scale;

		_playerAIController = GameObject.FindGameObjectWithTag("playerAI");
		
		_ball = GameObject.FindGameObjectWithTag("ball");
		_ballStartingPosition = new Vector3(0, -0.81f, -0.7f); //for normal play mode
	}
}


// if player turn
/*
p1TimeBarCurrentScale -= Time.deltaTime / p1ShootTime;
p1TimeBar.transform.localScale = new Vector3(p1TimeBarCurrentScale, p1TimeBar.transform.localScale.y, p1TimeBar.transform.localScale.z);
fillTimeBar(2);
*/

// if oppenent turn
/*
p2TimeBarCurrentScale -= Time.deltaTime / p2ShootTime;
p2TimeBar.transform.localScale = new Vector3(p2TimeBarCurrentScale, p2TimeBar.transform.localScale.y, p2TimeBar.transform.localScale.z);
fillTimeBar(1);
*/

