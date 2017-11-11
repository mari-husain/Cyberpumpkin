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
		frame++;
		if (frame <=0){
			agent.position += (double)dir/(double)move.movement(frame);
		}
		if (frame == FRAMES) {
			GameLoop.endEvent (this);
		}
	}

	public override int cost (){
		return move.cost(frame);
	}

}
