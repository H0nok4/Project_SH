using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarseMode : IMapGeneratorMode
{
    public void Run() {
        if (Input.GetKey(KeyCode.Mouse0)) {
            if (Find.RayCaster.HasPoint) {
                var point = Find.RayCaster.Point;
                var normal = Find.RayCaster.Normal;
                var pos = new Vector3(point.x - (normal.x * 0.5f), point.y - (normal.y * 0.5f), point.z - (normal.z * 0.5f));
                if (Find.MapGenerator.Map.Blocks[(int)pos.x, Math.Clamp((int)pos.y, 0, 255), (int)pos.z] != BlockType.Air) {
                    Debug.Log($"在{pos}位置有一个方块");
                    Find.MapGenerator.Map.Blocks[(int) pos.x, Math.Clamp((int) pos.y, 0, 255), (int) pos.z] =
                        BlockType.Air;
                }

            }
        }
    }

    public void Show() {
        if (Find.RayCaster.HasPoint) {
            var normal = Find.RayCaster.Normal;
            var point = Find.RayCaster.Point;
            var pos = new Vector3(point.x - (normal.x * 0.5f), point.y - (normal.y * 0.5f), point.z - (normal.z * 0.5f));
            if (Find.MapGenerator.Map.Blocks[(int)pos.x,Math.Clamp((int)pos.y,0,255),(int)pos.z] != BlockType.Air) {
                Debug.Log($"在{pos}位置有一个方块");
            }
            Find.MapGenerator.Block.transform.position = Find.RayCaster.Point;
        }

    }
}
