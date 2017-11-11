using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public string pName;

	public Hashtable table = new Hashtable();

	public bool isEnemy;

	public Player enemy;

	public BodyPart rightArm;
	public BodyPart leftArm;
	public BodyPart leftLeg;
	public BodyPart rightLeg;
	public BodyPart[] limbs;
	public Heart heart;

	public double heartPoints; 
	public double position;//normally in integer positions, but when dodging/side-stepping, in-between positions

	public KeyListener listener;

	bool regen;

	public int updateCount = 0;

	public GameEvent performing;

	// Use this for initialization
	void Awake() {
		
		heartPoints = heart.MAX;

		regen = true;
		limbs = new BodyPart[]{rightArm, leftArm, rightLeg, leftLeg};
		foreach (BodyPart bp in limbs){
			foreach (Action a in bp.attacks){
					string s = "";
					foreach (char c in a.keys){
						s += c;
					}
				if (!table.ContainsKey(s)){
					table.Add(s, a);
				}
			}
			foreach (Action a in bp.moves){
					string s = "";
					foreach (char c in a.keys){
						s += c;
					}
				if (!table.ContainsKey(s)){
					table.Add(s, a);
				}
			}
		}
		foreach (string s in table.Keys){
			print(s);
		}
	}

	public void update(){
		addHeart();
		//you can always do any action, and it will just bring your heart points down to 1 until next update cycle
		//except some attacks have a minimum-points cutoff
		//turn regen off during an attack/motion
		pendingAction();

	}

	public void addHeart(){
		if (regen){
			if (updateCount >= heart.tempo()){

				heartPoints += heart.beat();
				updateCount = 0;
			}
			else{
				updateCount++;
			}
		}
		heart.update();
		if (heartPoints > heart.getPointMax()){
			heartPoints = heart.getPointMax();
		}
	}

	//take damage from a hit
	public void hit(double strength, double weaken){
		//TODO: factor in whether this player is facing the right dir. If sides, do bonus damage, if facing backwards do extra critical damage
		heart.decrease(strength);
		heartPoints -= weaken;
		if (heartPoints <= 0){
			GameLoop.knockout(pName);
		}
	}

	public void fatigue(double weaken){
		heartPoints -= weaken;
		if (heartPoints <= 0) {heartPoints = 1;}
	}

	public void tieListener(KeyListener listener){
		this.listener = listener;
		listener.player = this;
	}

	public Action listen(){

		if (isEnemy) 
			return null; //TODO implement AI

		if (Input.inputString.Length > 0){

			List<char> keys = new List<char>();
			foreach (char c in Input.inputString){
				keys.Add(c);
			}
			keys.Sort();

			string s = "";
			foreach (char c in keys){
				s += c;
			}

			if (s.Length > 0){
				print("Keystring [" + s + "] has been pressed");
			}

			return (Action)table[s];
		}
		return null;
	}

	//Take move that has been keyed in and charge for it
	public void pendingAction(){
		//always do move, bring heartPoints as low as 1, if need be
		Action pendingAction = listen();
			
		if (pendingAction == null) {
			//No valid keys pressed
		}
		else if (pendingAction is Cancel){
			GameLoop.endEvent(performing); 
		}
			
		else if (pendingAction is Attack) {
			AttackEvent e = new AttackEvent ((Attack)pendingAction, this, enemy);
			GameLoop.addToList (e);
			performing = e;
		}

		else if (pendingAction is Move) {
			MoveEvent e = new MoveEvent (this, (Move)pendingAction);
			GameLoop.addToList (e);
			performing = e;
		}
	}

}
