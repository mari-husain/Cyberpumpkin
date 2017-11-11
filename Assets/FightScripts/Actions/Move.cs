using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Action {

	public int frames; //how many frames
	public int dir; //1 for right, -1 for left
	//note that all of these properties do depend on the weight of the player, but this should get factored in in the player-class 

	public int[] costList; //price per frame
	public int[] moveList; //qty of motion per frame 

	// Use this for initialization
	void Start () {
		costList = new int[frames];
		moveList = new int[frames];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override int cost (int frame){
		return costList[frame];
	}

	public int movement(int frame){
		return moveList[frame];
	}
}
