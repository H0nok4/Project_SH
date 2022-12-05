using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator{

    public static Mesh BuildMesh(Map map) {
        Mesh mesh = new Mesh();

        List<Vector3> verts = new List<Vector3>();
        List<int> tris = new List<int>();
        List<Vector2> uvs = new List<Vector2>();

        for (int x = 1; x < map.Blocks.GetLength(0); x++) {
            for (int z = 1; z < map.Blocks.GetLength(0); z++) {
                for (int y = 0; y < map.Blocks.GetLength(1); y++) {
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
                            uvs.AddRange(Block.Blocks[BlockType.Default].TopPos.GetUVs());
                        }

                        if (map.Blocks[x + 1, y, z] == BlockType.Air) {
                            //右方
                            verts.Add(blockPos + new Vector3(1, 0, 0));
                            verts.Add(blockPos + new Vector3(1, 1, 0));
                            verts.Add(blockPos + new Vector3(1, 1, 1));
                            verts.Add(blockPos + new Vector3(1, 0, 1));

                            numFaces++;
                            uvs.AddRange(Block.Blocks[BlockType.Default].SidePos.GetUVs());
                        }

                        if (map.Blocks[x - 1, y, z] == BlockType.Air) {
                            //左方
                            verts.Add(blockPos + new Vector3(0, 0, 1));
                            verts.Add(blockPos + new Vector3(0, 1, 1));
                            verts.Add(blockPos + new Vector3(0, 1, 0));
                            verts.Add(blockPos + new Vector3(0, 0, 0));

                            numFaces++;
                            uvs.AddRange(Block.Blocks[BlockType.Default].SidePos.GetUVs());
                        }

                        if (map.Blocks[x, y, z + 1] == BlockType.Air) {
                            //前方
                            verts.Add(blockPos + new Vector3(1, 0, 1));
                            verts.Add(blockPos + new Vector3(1, 1, 1));
                            verts.Add(blockPos + new Vector3(0, 1, 1));
                            verts.Add(blockPos + new Vector3(0, 0, 1));

                            numFaces++;
                            uvs.AddRange(Block.Blocks[BlockType.Default].SidePos.GetUVs());
                        }

                        if (map.Blocks[x, y , z - 1] == BlockType.Air) {
                            //前方
                            verts.Add(blockPos + new Vector3(0, 0, 0));
                            verts.Add(blockPos + new Vector3(0, 1, 0));
                            verts.Add(blockPos + new Vector3(1, 1, 0));
                            verts.Add(blockPos + new Vector3(1, 0, 0));

                            numFaces++;
                            uvs.AddRange(Block.Blocks[BlockType.Default].SidePos.GetUVs());
                        }

                        if (y == 0) {
                            //下方
                            verts.Add(blockPos + new Vector3(0, 0, 0));
                            verts.Add(blockPos + new Vector3(1, 0, 0));
                            verts.Add(blockPos + new Vector3(1, 0, 1));
                            verts.Add(blockPos + new Vector3(0, 0, 1));

                            numFaces++;
                            uvs.AddRange(Block.Blocks[BlockType.Default].BottomPos.GetUVs());
                        }

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
        mesh.uv = uvs.ToArray();

        mesh.RecalculateNormals();

        return mesh;
    }


}
