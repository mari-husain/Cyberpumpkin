using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManagerScript : MonoBehaviour {

	private Queue<string> dialogueText;

	// Use this for initialization
	void Start () {
		dialogueText = new Queue<string> ();
	}

}
