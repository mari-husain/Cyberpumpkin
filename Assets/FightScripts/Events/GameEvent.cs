using System;
	
public abstract class GameEvent{
		
	public Player agent;

	public abstract void update();

	public abstract int cost();
}

