using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmITired : BTNode {
    
	Transform play;
	private StatsAi aiStatus;
	
	public AmITired(Transform play)
    {
			this.play = play;
			aiStatus = play.GetComponent<StatsAi>();
    }

    public override EstadoNode Tick()
    {
		if(aiStatus.tired > 70)
		{
			return EstadoNode.SUCCESS;
		}
		else return EstadoNode.FAILURE;
    }

    
}
