using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancel : Action {

	// Use this for initialization
	void Start () {
	}

	public override int cost (int frame){
		return 0;
	}
}
