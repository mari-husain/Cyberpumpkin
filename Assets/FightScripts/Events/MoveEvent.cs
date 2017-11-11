using System;

public class MoveEvent: GameEvent{

	Move move;
	int frame = 0;
	readonly int FRAMES;
	int dir;

	public MoveEvent(Player mover, Move move){
		this.agent = mover;
		this.move = move;
		FRAMES = move.frames;
		dir = move.dir;
	}

	override public void update(){
		if (frame == FRAMES) {
			GameLoop.endEvent (this);
		}

		agent.fatigue(move.cost(frame));
		agent.position += (double)dir/(double)move.movement(frame);

		if (agent.heartPoints <= 0) agent.heartPoints = 1;

		frame++;
	}

	public override int cost (){
		return move.cost(frame);
	}

}
