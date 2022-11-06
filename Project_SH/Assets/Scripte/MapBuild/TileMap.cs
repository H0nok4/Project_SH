using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapBuild
{
    public class TileMap
    {
        public Tile[,,] Map;

        public TileMap(int x, int y, int z)
        {
            Map = new Tile[x, y, z];
        }
    }
}

