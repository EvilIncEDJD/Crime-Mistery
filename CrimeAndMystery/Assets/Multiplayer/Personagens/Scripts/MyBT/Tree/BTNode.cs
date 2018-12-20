using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EstadoNode
{
	FAILURE,
    SUCCESS,
    RUNNING
}
public abstract class BTNode  {

	public EstadoNode estado;
	public abstract EstadoNode Tick();

}

public abstract class BTComposite : BTNode
{
    protected List<BTNode> nodes = new List<BTNode>();
    public virtual void Composite(params BTNode[] nodes)
    {
       foreach (BTNode btn in nodes)
	   {
		   this.nodes.Add(btn);
	   }
    }
}

public abstract class BTDecorator : BTNode
{
	public BTNode node;

	 public BTDecorator(BTNode node) {
        this.node = node;
    }
}


