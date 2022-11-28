using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMode : IMapGeneratorMode
{
    public void Run() {
        //TODO:点击按键时，在鼠标的位置生成一个Block
        if (Input.GetKey(KeyCode.Mouse0)) {
            Debug.Log($"生成一个方块网格在 {Find.RayCaster.Point}");
        }
    }

    public void Show() {
        //TODO:显示预览
        if (Find.RayCaster.HasPoint) {
            Debug.Log($"当前有碰撞点 Point = {Find.RayCaster.Point}");
            if (Find.MapGenerator.Block == null) {
                Find.MapGenerator.Block = GameObject.Instantiate(Find.MapGenerator.BlockPrefab);
            }

            if (!Find.MapGenerator.Block.activeSelf) {
                Find.MapGenerator.Block.SetActive(true);
            }

            Find.MapGenerator.Block.transform.position = Find.RayCaster.Point;
        }
        else {
            if (Find.MapGenerator.Block == null) {
                return;
            }

            Find.MapGenerator.Block.SetActive(false);
        }

    }
}
