using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSequence : BTComposite {
    
	public BTSequence(List<BTNode> nodes)
    {
		this.nodes = nodes;
    }

    public override EstadoNode Tick()
    {
        foreach(BTNode child in nodes)
        {
            estado = child.Tick();

            if (estado == EstadoNode.FAILURE)
            {
                return estado;
            }
        }

        return EstadoNode.SUCCESS;
    }

    
}
