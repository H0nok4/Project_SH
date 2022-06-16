using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using Debug = UnityEngine.Debug;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update
    public Node[,] MapArray;
    
    void Start()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        MapArray = CreatMap();
        sw.Stop();
        Debug.Log("创建地图完成");
        Debug.Log($"创建地图花了:{sw.Elapsed}");


    }

    public Node[,] CreatMap() {
        var mapArray = new Node[1000, 1000];
        Vector3 pos = new Vector3();
        
        for (int i = 0; i < 1000; i += 1) {
            for (int j = 0; j < 1000; j += 1) {
                
                pos.x = 0.1f * i;
                pos.z = 0.1f * j;
                pos.y = 0;
                mapArray[i, j].x = pos.x;
                mapArray[i, j].y = pos.z;
                mapArray[i, j].CanPass = true;
                var overLap = Physics.OverlapSphere(pos, 0.05f);
                foreach (var collider in overLap) {
                    if (collider.CompareTag("CantPass")) {
                        mapArray[i, j].CanPass = false;
                        break;
                    }
                }
            }
        }

        return mapArray; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public struct Node {
    public float x;
    public float y;
    public bool CanPass;
}