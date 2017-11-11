using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//note that this class expects a player parameter:
//this is with multiplayer in mind:
//can use the same keylistener class, one instance for each player
public abstract class KeyListener : MonoBehaviour {

	public Player player;

	string lastPressed;
	public Action testAction; //this is a BS action for testing. Delete it

	void Start(){

	}

	//called by GameLoop
	//RegistersCurrentKeyHits
	public abstract void update();

	public abstract Action getAction ();

	public Action getRandom(){
		return null;
	}
}
