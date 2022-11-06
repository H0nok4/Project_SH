using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapBuild
{
    public class Tile
    {
        public TileType Top, Down;//上下
        public TileType Left, Right, Forward, Behind;//左右前后

        public Tile(TileType topDown,TileType other)
        {
            Top = Down = topDown;
            Left = Right = Forward = Behind = other;
        }

        public Tile(TileType top,TileType down,TileType left,TileType right,TileType forward,TileType behind)
        {
            Top=top;
            Down=down;
            Left=left;
            Right=right;
            Forward=forward;
            Behind=behind;
        }
    }

}
