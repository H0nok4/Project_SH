using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {
    public GameObject obj;

    public int Width = 10;

    public int Height = 10;

    
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init() {
        //var meshFilter = obj.AddComponent<MeshFilter>();
        //var meshRenderer = obj.AddComponent<MeshRenderer>();
        //meshFilter.mesh = new Mesh();
        //meshFilter.mesh.name = "Test Mesh";

        //var vertices = new Vector3[4]{ new Vector3(0, 0, 0),new Vector3(1,0,0),new Vector3(0, 1, 0),new Vector3(1,1,0)};
        //meshFilter.mesh.vertices = vertices;
        //int[] triangle = new int[6];
        //triangle[0] = 0;
        //triangle[1] = 1;
        //triangle[2] = 2;
        //triangle[3] = 2;
        //triangle[4] = 1;
        //triangle[5] = 3;
        //meshFilter.mesh.triangles = triangle;
        Map map = new Map(Width,Width,Height);

        var mesh = BuildMesh(map);
        var filter = obj.AddComponent<MeshFilter>();
        var render = obj.AddComponent<MeshRenderer>();
        filter.mesh = mesh;


    }

    public Mesh BuildMesh(Map map) {
        Mesh mesh = new Mesh();

        List<Vector3> verts = new List<Vector3>();
        List<int> tris = new List<int>();

        for (int x = 1; x < Width; x++) {
            for (int z = 1; z < Width; z++) {
                for (int y = 0; y < Height - 1; y++) {
                    if (map.Blocks[x,y,z] != BlockType.Air) {
                        Vector3 blockPos = new Vector3(x, y, z);
                        int numFaces = 0;
                        if (map.Blocks[x, y + 1, z] == BlockType.Air) {
                            //上方
                            verts.Add(blockPos + new Vector3(0, 1, 0));
                            verts.Add(blockPos + new Vector3(0, 1, 1));
                            verts.Add(blockPos + new Vector3(1, 1, 1));
                            verts.Add(blockPos + new Vector3(1, 1, 0));

                            numFaces++;
                        }

                        if (map.Blocks[x + 1, y, z] == BlockType.Air) {
                            //右方
                            verts.Add(blockPos + new Vector3(1, 0, 0));
                            verts.Add(blockPos + new Vector3(1, 1, 0));
                            verts.Add(blockPos + new Vector3(1, 1, 1));
                            verts.Add(blockPos + new Vector3(1, 0, 1));

                            numFaces++;
                        }

                        if (map.Blocks[x - 1, y, z] == BlockType.Air) {
                            //左方
                            verts.Add(blockPos + new Vector3(0, 0, 0));
                            verts.Add(blockPos + new Vector3(0, 0, 1));
                            verts.Add(blockPos + new Vector3(0, 1, 1));
                            verts.Add(blockPos + new Vector3(0, 1, 0));

                            numFaces++;
                        }

                        //if (map.Blocks[x, z + 1, y] == BlockType.Air) {
                        //    //前方
                        //    verts.Add(blockPos + new Vector3(0, 1, 0));
                        //    verts.Add(blockPos + new Vector3(0, 1, 1));
                        //    verts.Add(blockPos + new Vector3(1, 1, 1));
                        //    verts.Add(blockPos + new Vector3(1, 1, 0));

                        //    numFaces++;
                        //}

                        //if (map.Blocks[x, z - 1, y] == BlockType.Air) {
                        //    //前方
                        //    verts.Add(blockPos + new Vector3(0, 0, 0));
                        //    verts.Add(blockPos + new Vector3(0, 0, 1));
                        //    verts.Add(blockPos + new Vector3(1, 0, 1));
                        //    verts.Add(blockPos + new Vector3(1, 0, 0));

                        //    numFaces++;
                        //}

                        //if (y == 0) {
                        //    //下方
                        //    verts.Add(blockPos + new Vector3(0, 0, 0));
                        //    verts.Add(blockPos + new Vector3(0, 1, 0));
                        //    verts.Add(blockPos + new Vector3(1, 1, 0));
                        //    verts.Add(blockPos + new Vector3(1, 0, 0));

                        //    numFaces++;
                        //}

                        int tl = verts.Count - 4 * numFaces;
                        for (int i = 0; i < numFaces; i++) {
                            tris.AddRange(new int[] { tl + i * 4, tl + i * 4 + 1, tl + i * 4 + 2, tl + i * 4, tl + i * 4 + 2, tl + i * 4 + 3 });
                        }
                    }

                }
            }
        }

        mesh.vertices = verts.ToArray();
        mesh.triangles = tris.ToArray();

        mesh.RecalculateNormals();

        return mesh;
    }


}
