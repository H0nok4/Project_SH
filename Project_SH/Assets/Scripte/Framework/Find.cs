using System.Collections;
using System.Collections.Generic;
using MapBuild;
using UnityEngine;

public static class Find {
    public static RayCaster RayCaster;
    public static MapGenerator MapGenerator; 
    public static void Init() {
        RayCaster = GameObject.Find("Root").GetComponent<RayCaster>();
        MapGenerator = GameObject.Find("Root").GetComponent<MapGenerator>();
    }
}
