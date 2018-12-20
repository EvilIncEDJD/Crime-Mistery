using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmIBored : BTNode {

Transform play;
	private StatsAi aiStatus;
	
	public AmIBored(Transform play)
    {
			this.play = play;
			aiStatus = play.GetComponent<StatsAi>();
    }

    public override EstadoNode Tick()
    {
		if(aiStatus.bored > 70)
		{
			return EstadoNode.SUCCESS;
		}
		else return EstadoNode.FAILURE;
    }
}
