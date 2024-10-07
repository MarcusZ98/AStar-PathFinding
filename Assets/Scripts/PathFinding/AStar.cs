using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathFinding;

namespace PathFinding
{
    public class AStar : MonoBehaviour
    {
        public int gridSizeX;
        public int gridSizeY;
        public float nodeSize;
        public Vector3 gridOrigin;
        public LayerMask unwalkableMask;
        
        private Node[,] _grid;

        [ContextMenu("CreateGrid")]
        public void CreateGrid()
        {
            _grid = new Node[gridSizeX, gridSizeY];
            
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    Vector3 worldPoint = new Vector3(x * nodeSize, 0, y * nodeSize) + gridOrigin;
                    bool walkable = !Physics.CheckSphere(worldPoint, nodeSize / 2, unwalkableMask);
                    _grid[x, y] = new Node(worldPoint, walkable);

                }
            }
        }
        
    }
    
    
    
    
    
    
    
    
    
}


