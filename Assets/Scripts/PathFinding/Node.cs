using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathFinding
{
    public class Node
    {
        public Vector3 WorldPosition;
        public bool Walkable; 
        public Node Parent; 
        public int GCost; // Cost from start node to current node
        public int HCost; // Cost from current node to end node
        
        public int fCost => GCost + HCost; // Total cost of the node
        
        public Node(Vector3 worldPosition, bool walkable)
        {
            WorldPosition = worldPosition;
            Walkable = walkable;
        }
    }
}

