using UnityEngine;
using Random = UnityEngine.Random;

public enum Direction {
    Left,

    Up,

    Right,

    Down,

}

public class Map : MonoBehaviour {

    public BlockType[,,] Blocks;
    
    public Map(int maxX, int maxZ, int maxY) {

        Blocks = new BlockType[maxX + 2, maxY + 1, maxZ + 2];

    }

}

public class Node {
    
}

public class BlockPos {
    public int PosX, PosY;
    public int Height;

    public BlockPos(int posX, int posY, int height) {
        PosX = posX;
        PosY = posY;
        Height = height;
    }

}

public enum BlockType {
    Air,Default
}

//public class Node {
//    public int x;
//    public int y;
//    public bool CanPass;
//    public int Distance;
//    public Vector2 Vec;
//    public long FindingTimes;
//}