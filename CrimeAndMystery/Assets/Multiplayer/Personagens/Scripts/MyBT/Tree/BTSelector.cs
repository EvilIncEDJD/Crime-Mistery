using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSelector : BTComposite
{
	public BTSelector (List<BTNode> nodes)
    {
        this.nodes = nodes;
    }

    public override EstadoNode Tick()
    {
         foreach(BTNode child in nodes)
        {
            estado = child.Tick();

            if (estado == EstadoNode.SUCCESS)
            {
                return estado;
            }
        }

        return EstadoNode.FAILURE;
    }
	
    }
