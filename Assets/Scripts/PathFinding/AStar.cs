using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathFinding;

namespace PathFinding
{
    public class AStar : MonoBehaviour
    {
        public float totalGridSizeX = 10f; // Total size of the grid in the X direction (world units)
        public float totalGridSizeY = 10f; // Total size of the grid in the Y direction (world units)
        public float nodeSize = 1f;        // Size of each node
        public Vector3 gridOrigin;         // Bottom left corner of the grid
        public LayerMask unwalkableMask;   // Layer mask for unwalkable objects
        
        private Node[,] _grid; // 2D array of nodes
        private int gridSizeX; // Dynamically calculated grid size X
        private int gridSizeY; // Dynamically calculated grid size Y

        public void CreateGrid()
        {
            // Calculate the number of nodes based on the total grid size and node size
            gridSizeX = Mathf.RoundToInt(totalGridSizeX / nodeSize);
            gridSizeY = Mathf.RoundToInt(totalGridSizeY / nodeSize);

            _grid = new Node[gridSizeX, gridSizeY];
            
            for (var x = 0; x < gridSizeX; x++)
            {
                for (var y = 0; y < gridSizeY; y++)
                {
                    var worldPoint = new Vector3(x * nodeSize, 0, y * nodeSize) + gridOrigin;
                    var walkable = !Physics.CheckSphere(worldPoint, nodeSize / 2, unwalkableMask);
                    _grid[x, y] = new Node(worldPoint, walkable);
                }
            }
        }
        
        private void OnDrawGizmos()
        {
            // Ensure the grid has been created
            if (_grid == null) return;
            
            for (var x = 0; x < gridSizeX; x++)
            {
                for (var y = 0; y < gridSizeY; y++)
                {
                    var node = _grid[x, y];

                    // Set the Gizmo color based on whether the node is walkable
                    Gizmos.color = node.Walkable ? Color.white : Color.red;

                    // Draw a flat plane (thin cube) for each node
                    var planeSize = new Vector3(nodeSize * 0.9f, 0.1f, nodeSize * 0.9f); // Slightly smaller to prevent overlap
                    Gizmos.DrawCube(node.WorldPosition, planeSize);
                }
            }
        }
    }
    
    
    
    
    
    
    
    
    
}


