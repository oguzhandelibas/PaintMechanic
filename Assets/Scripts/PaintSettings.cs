using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaintSystem
{
    [CreateAssetMenu(menuName = "Paint Mechanic/Paint Settings")]
    public class PaintSettings : ScriptableObject
    {
        [SerializeField] private Color _color;
        private Mesh _targetMesh;

        [SerializeField] int[] totalTriangles;
        [SerializeField] float paintedTriangle;

        Vector3[] vertices;
        Color[] colorArray;
        

        public void Initialize(Mesh targetMesh)
        {
            paintedTriangle = 0;
            _targetMesh = targetMesh;
            vertices = targetMesh.vertices;
            totalTriangles = targetMesh.triangles;

            // create new colors array where the colors will be created
            colorArray = new Color[vertices.Length];
            for (int k = 0; k < vertices.Length; k++)
            {
                colorArray[k] = Color.white;
            }
            targetMesh.colors = colorArray;
        }

        public string Paint()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {

                var vertIndex1 = totalTriangles[hit.triangleIndex * 3 + 0];
                var vertIndex2 = totalTriangles[hit.triangleIndex * 3 + 1];
                var vertIndex3 = totalTriangles[hit.triangleIndex * 3 + 2];

                if (colorArray[vertIndex1] == Color.white)
                {
                    colorArray[vertIndex1] = Color.red;
                    paintedTriangle += 1;

                }

                if (colorArray[vertIndex2] == Color.white)
                {
                    colorArray[vertIndex2] = Color.red;
                    paintedTriangle += 1;
                }

                if (colorArray[vertIndex3] == Color.white)
                {
                    colorArray[vertIndex3] = Color.red;
                    paintedTriangle += 1;
                }

                float percent = (float)(paintedTriangle / vertices.Length) * 100;
                _targetMesh.colors = colorArray;
                return percent.ToString("F0") + "%";
            }
            else
            {
                Debug.Log("no hit");
                return null; 
            }
        }
    }
}
