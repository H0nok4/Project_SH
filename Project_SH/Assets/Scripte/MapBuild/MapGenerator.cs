using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MapBuild
{
    public class MapGenerator : MonoBehaviour
    {

        public MapGeneratorType CurGeneratorType;

        private void Start()
        {
            CurGeneratorType = MapGeneratorType.Move;
        }

        private void Update() {
            //每一帧检测镜头到鼠标的一条射线，找到第一个碰撞到的面，根据当前的模式来等待执行

        }
    }

}
