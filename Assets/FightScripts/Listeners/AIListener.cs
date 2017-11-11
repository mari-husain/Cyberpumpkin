using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIListener : KeyListener{

	public override Action getAction(){
		return null;
	}

	//called by GameLoop
	//RegistersCurrentKeyHits
	override public void update(){

	}
}