using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Block {
    public Tile Top, Side, Bottom;
    public TilePos TopPos, SidePos, BottomPos;

    public Block(Tile top,Tile side,Tile bottom) {
        this.Top = top;
        Side = side;
        Bottom = bottom;
        GetPosition();
    }

    public void GetPosition() {
        TopPos = TilePos.Tiles[Top];
        SidePos = TilePos.Tiles[Side];
        BottomPos = TilePos.Tiles[Bottom];
    }

    public static Dictionary<BlockType, Block> Blocks = new Dictionary<BlockType, Block>() {
        {BlockType.Default, new Block(Tile.Grass, Tile.GrassSide, Tile.GrassBottom)}
    };
}
