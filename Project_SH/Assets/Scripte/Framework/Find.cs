using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Find {
    public static RayCaster RayCaster;

    public static void Init() {
        RayCaster = GameObject.Find("RayCaster").GetComponent<RayCaster>();
    }
}
