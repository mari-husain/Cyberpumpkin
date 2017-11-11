using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour {

	public abstract int cost(int frame);
	public List<char> keys;

	void Start(){
		keys.Sort();
	}

}
