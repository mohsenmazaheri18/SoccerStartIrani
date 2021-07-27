﻿using UnityEngine;
using System.Collections;

public class GoalKeeperController : MonoBehaviour
{

	/// <summary>
	/// This class gives the goalkeepers a simple AI which moves them inside the gate 
	/// to avoid the shooter to have an easy direct shot. You can edit the moveSpeed to come up with a 
	/// smarter/dumber goalkeeper.
	/// </summary>
/*
	public bool isGoalkeeper = false;
	[Range(0.7f, 2.0f)]
	public float moveSpeed = 1.2f;		//increasing this parameter will result in a better reflex of goalkeeper

	private bool canMove = false;
	private float startDelay = 3.0f;

    private bool showOnceFlag;              //we need to show the helper only once in each game
    private GameObject penaltyHelperArrow;  //helper arrow we use to let the player know he can drag the gk around by finger
    //Manual movement settings
    private Camera cam;


    void Awake()
    {
        penaltyHelperArrow = GameObject.FindGameObjectWithTag("PenaltyHelperArrow");
        showOnceFlag = false;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    IEnumerator Start () {
		//This class only works in Penalty Mod
		if(!Game_Manager.isPenaltyKick)
			this.enabled = false;

        if (penaltyHelperArrow)
            penaltyHelperArrow.SetActive(false);

        yield return new WaitForSeconds(startDelay);
		canMove = true;
	}
	
	void Update () {

		checkIsGoalKeeper();

        //Use this for the old automatic goalkeeper
		//if(isGoalkeeper && canMove && !Game_Manager.goalHappened && !Game_Manager.gameIsFinished)
        //{
        //   StartCoroutine(moveGoalkeeper());
        //}
			

        //Use this for new V1.8.2 manual goalkeeper
        if (isGoalkeeper && canMove && !Game_Manager.goalHappened && !Game_Manager.gameIsFinished)
        {
            //automatic goalkeeper - for AI & P2
            if (this.gameObject.tag == "Opponent" || this.gameObject.tag == "Player_2")
                StartCoroutine(moveGoalkeeper());

            //manual goalkeeper - Only when player 1s is the goalkeeper
            if (this.gameObject.tag == "Player")
                manualGoalkeeper();
        }

    }

	/// <summary>
	/// Checks if this object is the goal keeper
	/// </summary>
	void checkIsGoalKeeper () {

		//in even rounds, player 1 is the goalkeeper
		//in odd rounds, player-2/AI is goalkeeper

		if(PenaltyController.penaltyRound % 2 == 1) {
			if(this.gameObject.tag == "Opponent" || this.gameObject.tag == "Player_2")
				isGoalkeeper = true;
			else 
				isGoalkeeper = false;
		}

		if(PenaltyController.penaltyRound % 2 == 0) {
			if(this.gameObject.tag == "Player")
				isGoalkeeper = true;
			else 
				isGoalkeeper = false;
		}
	}


	/// <summary>
	/// Moves the goalkeeper inside the gate
	/// </summary>
	public IEnumerator moveGoalkeeper() {

		if(canMove)
			canMove = false;

		Vector3 cPos = transform.position;
		Vector3 dest = getNewDestination(transform.position);
		//print ("Destination: " + dest);

		float t = 0;
		while(t < 1) {
			t += Time.deltaTime * moveSpeed;
			transform.position = new Vector3(dest.x,
			                                 Mathf.SmoothStep(cPos.y, dest.y, t),
			                                 dest.z);
			yield return 0;
		}

		if(t >= 1) {
			canMove = true;
			yield break;
		}
	}


	/// <summary>
	/// Gets a new destination after each move
	/// </summary>
	Vector3 getNewDestination(Vector3 p) {

		int dir = 1;

		if(p.y >= 0)
			dir = -1;
		else 
			dir = 1;

		return new Vector3(13, Mathf.Abs(UnityEngine.Random.Range(-4.0f, 4.0f)) * dir, p.z);
	}



    /// <summary>
	/// Manual movement of goalkeeper by dragging him with finger
	/// </summary>
	private RaycastHit hitInfo;
    private Ray ray;
    void manualGoalkeeper()
    {
        //print ("Manual move activated...");

        //show helper test
        if (penaltyHelperArrow)
        {
            if (!showOnceFlag)
                penaltyHelperArrow.SetActive(true);
            else
                penaltyHelperArrow.SetActive(false);
        }


        if (Input.touches.Length > 0 && Input.touches[0].phase == TouchPhase.Moved)
            ray = cam.ScreenPointToRay(Input.touches[0].position);
        else if (Input.GetMouseButtonDown(0))
            ray = cam.ScreenPointToRay(Input.mousePosition);
        else
            return;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject objectHit = hitInfo.transform.gameObject;
            print("objectHit: " + objectHit.name);
            if (objectHit.tag == "Player" &&
                objectHit.name == gameObject.name)
            {
                StartCoroutine(dragGK());
            }
        }
    }



    private Vector3 _Pos;
    IEnumerator dragGK()
    {

        //let the player move the gk until the turn is over
        while (!Game_Manager.shootHappened isGoalkeeper)
        {

            //follow mouse or touch
            float tmpZ = 19.0f + (Input.mousePosition.y / 37);
            _Pos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, tmpZ));
            _Pos = new Vector3(_Pos.x, _Pos.y, -0.5f);
            print("Drag Player pos: " + _Pos);

            //Limit X-Y movements
            // X is set from Game_Manager.penaltyKickGKPosition
            // Y should be in this range : -4 ~ +2.5 (new setting: -7 ~ +6)
            float newPosY = _Pos.y;

            //big size
            if (_Pos.y < -7.0f)
                newPosY = -7.0f;
            if (_Pos.y > 6.0f)
                newPosY = 6.0f;

            _Pos = new Vector3(Game_Manager.penaltyKickGKPosition.x, newPosY, -0.5f);

            //follow player's finger
            transform.position = _Pos + new Vector3(0, 0, 0);

            //disable the helper arrow system
            showOnceFlag = true;

            //Reset GK position once the input is lost
            if (Input.touches.Length < 1 && !Input.GetMouseButton(0))
            {
                resetGkPosition();
            }

            yield return 0;
        }
    }


    void resetGkPosition()
    {
        transform.position = Game_Manager.penaltyKickGKPosition;
    }*/

}