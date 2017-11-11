using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListener : KeyListener {

	string lastPressed;
	Hashtable table = new Hashtable();

	//called by GameLoop
	//RegistersCurrentKeyHits
	override public void update(){

	}

	override public Action getAction(){
		if (Input.anyKeyDown){
			print ("keypress");
			return testAction;
		}
		return null;
	}

	new public Action getRandom(){
		//note that this is a BS return val and this class does not work yet
		return null;
	}
}
