using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmILonely : BTNode {

	Transform play;
	private StatsAi aiStatus;
	
	public AmILonely(Transform play)
    {
			this.play = play;
			aiStatus = play.GetComponent<StatsAi>();
    }

    public override EstadoNode Tick()
    {
		if(aiStatus.lonely > 70)
		{
			return EstadoNode.SUCCESS;
		}
		else return EstadoNode.FAILURE;
    }
}