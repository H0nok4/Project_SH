using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using Debug = UnityEngine.Debug;

public enum Direction {
    Left,

    Up,

    Right,

    Down,

}

public class Map : MonoBehaviour
{
    // Start is called before the first frame update
    public Node[,] MapArray;

    public static Map Instance;


    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
        Stopwatch sw = new Stopwatch();
        sw.Start();
        MapArray = CreatMap();
        sw.Stop();
        Debug.Log("创建地图完成");
        Debug.Log($"创建地图花了:{sw.Elapsed}");

    }

    void Start()
    {




    }

    public Node[,] CreatMap() {
        var mapArray = new Node[1000, 1000];
        Vector3 pos = new Vector3();
        int count = 0;
        for (int i = 0; i < 1000; i += 1) {
            for (int j = 0; j < 1000; j += 1) {
                pos.x = i * 0.1f;
                pos.y = 0;
                pos.z = j * 0.1f;
                mapArray[i, j] = new Node();
                mapArray[i, j].x = i;
                mapArray[i, j].y = j;
                mapArray[i, j].CanPass = true;
                var overLap = Physics.OverlapSphere(pos, 1.5f);
                foreach (var collider in overLap) {
                    if (collider.CompareTag("CantPass")) {
                        count++;
                        mapArray[i, j].CanPass = false;
                        break;
                    }
                }
            }
        }
        Debug.Log($"有{count}个不能行走的格子");

        return mapArray; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Node {
    public int x;
    public int y;
    public bool CanPass;
    public int Distance;
    public Vector2 Vec;
    public long FindingTimes;
}