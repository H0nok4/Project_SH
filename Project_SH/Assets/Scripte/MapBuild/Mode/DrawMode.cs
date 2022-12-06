using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMode : IMapGeneratorMode
{
    public void Run() {
        //TODO:点击按键时，在鼠标的位置生成一个Block
        if (Input.GetKey(KeyCode.Mouse0)) {
            Debug.Log($"生成一个方块网格在 {Find.RayCaster.Point}");
            if (Find.RayCaster.HasPoint) {
                var point = Find.RayCaster.Point;
                var normal = Find.RayCaster.Normal;
                var pos = new Vector3(point.x + (normal.x*0.5f),point.y,point.z + (normal.z*0.5f));

                Find.MapGenerator.Map.Blocks[Mathf.FloorToInt(pos.x) , (int)pos.y, Mathf.FloorToInt(pos.z)] = BlockType.Default;
                var mesh = GridGenerator.BuildMesh(Find.MapGenerator.Map);
                var meshCom = Find.MapGenerator.MapObject.GetComponent<MeshFilter>();
                meshCom.mesh = mesh;
                var collider = Find.MapGenerator.MapObject.GetComponent<MeshCollider>();
                var meshRenderer = Find.MapGenerator.MapObject.GetComponent<MeshRenderer>();
                collider.sharedMesh = mesh;
                collider.material = new PhysicMaterial();
            }

        }
    }

    public void Show() {
        //TODO:显示预览
        if (Find.RayCaster.HasPoint) {
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
