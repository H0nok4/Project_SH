using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tile {
    Grass,
    GrassSide,
    GrassBottom
}
public class TilePos {
    public int xPos, yPos;
    public Vector2[] uvs;

    public TilePos(int xPos, int yPos) {
        this.xPos = xPos;
        this.yPos = yPos;
        uvs = new Vector2[] {
            new Vector2(xPos / 2f + .001f,yPos / 2f + .001f),
            new Vector2(xPos / 2f + .001f,(yPos + 1) /  2f - .001f),
            new Vector2((xPos + 1) / 2f - .001f,(yPos + 1) / 2f - .001f),
            new Vector2((xPos + 1) / 2f - .001f,(yPos) / 2f + .001f)
        };
    }

    public Vector2[] GetUVs() {
        return uvs;
    }

    public static Dictionary<Tile, TilePos> Tiles = new Dictionary<Tile, TilePos>() {
        {Tile.Grass, new TilePos(0, 0)},
        {Tile.GrassBottom, new TilePos(1, 0)},
        {Tile.GrassSide, new TilePos(0, 1)}
    };
}
