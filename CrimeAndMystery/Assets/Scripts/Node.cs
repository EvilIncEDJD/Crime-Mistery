using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node  {

	
    public bool walkable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;
    public int gCost;
    public int hCost;
    public Node parent;
    
    public Node(bool _walkable, Vector3 worldPos, int _gridX, int _gridY)
    {
        walkable = _walkable;
        worldPosition = worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }

    public int fCost
    {
        get { return gCost + hCost; }
        
    }

    

    public int CompareTo(Node NodeToCompare)
    {
        int compare = fCost.CompareTo(NodeToCompare.fCost);

        if(compare == 0)
        {
            compare = hCost.CompareTo(NodeToCompare.hCost);
        }

        return -compare;
    }
}
