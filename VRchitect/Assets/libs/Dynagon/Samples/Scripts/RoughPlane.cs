using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dynagon;

namespace Dynagon.Sample
{

    public class RoughPlane : MonoBehaviour
    {

        public float tileSize = 5f;
        public int numTiles = 10;
        public float interval = 2f;

        Polygon polygon;
        float timer = 0f;

        private void Start()
        {
            


            
            var vertices = new List<Vector3>();
            
            
            vertices.Add(new Vector3(0, 0, 0));
            vertices.Add(new Vector3(0, 0, 5));
            vertices.Add(new Vector3(0, 5, 0));
            vertices.Add(new Vector3(0, 5, 5));
            vertices.Add(new Vector3(5, 5, 0));
            vertices.Add(new Vector3(5, 5, 5));
            vertices.Add(new Vector3(2.5f, 10, 0));
            vertices.Add(new Vector3(2.5f, 10, 5));
            vertices.Add(new Vector3(5, 0, 0));
            
            
            
            
            
            vertices.Add(new Vector3(5, 0, 5));
      
            Factory.Create("Floor", vertices);
        }


        




    }

}