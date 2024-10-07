using UnityEditor;
using UnityEngine;

namespace PathFinding
{
    [CustomEditor(typeof(AStar))]
    public class AStarEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            GUILayout.Space(10);
            
            AStar aStar = (AStar) target;
            
            if(GUILayout.Button("Create Grid"))
            {
                aStar.CreateGrid();
            }
        }
    }
}
