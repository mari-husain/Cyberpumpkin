using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackEvent: GameEvent{

	Attack attack;
	double position;
	Player victim;
	int frame = 0;
	readonly int FRAMES;

	public AttackEvent(Attack attack, Player attacker, Player victim){
		FRAMES = attack.speed;
		this.attack = attack;
		this.position = victim.position;
		this.agent = attacker;
		this.victim = victim;
		Debug.Log("I'm in here");
	}

	override public void update(){
		if (frame == FRAMES-1) {
			GameLoop.endEvent (this);
		}
		double precision= 1-Math.Abs(victim.position-position);
		if (precision<0) precision = 0;
		victim.hit(precision*attack.strength(frame), precision*attack.weaken(frame));
		frame ++;
	}

	public Player getAttacker(){
		return agent;
	}

	public override int cost (){
		return attack.cost(frame);
	}

}
