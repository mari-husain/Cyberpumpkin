using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

	public int RATE; //heart speed
	public int STRENGTH;//points per batch
	public double MAX;
	public double STAMINA;

	public double pointMax;
	public double heartPoints;

	// Use this for initialization
	void Start () {
		pointMax = MAX;
	}

	public double getPointMax(){
		return pointMax;
	}

	public int tempo(){
		return RATE;
	}

	public int beat(){
		return STRENGTH;
	}

	public void update(){
		pointMax -= 1/STAMINA;
	}

	public void decrease(double amount){
		pointMax -= amount;
	}
}