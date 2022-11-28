using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MapBuild
{
    public class MapGenerator : MonoBehaviour {
        private float _interval = 0.1f;
        private float _time = 0.1f;
        public MapGeneratorType CurGeneratorType;

        private void Start()
        {
            CurGeneratorType = MapGeneratorType.Move;
        }

        private void Update() {
            //每一帧检测镜头到鼠标的一条射线，找到第一个碰撞到的面，根据当前的模式来等待执行
            _time += Time.deltaTime;
            while (_time >= _interval) {
                CheckMousePosition();
            }
        }

        public void CheckMousePosition() {
            if (Find.RayCaster.HasPoint) {
                Debug.Log($"当前有碰撞点 Point = {Find.RayCaster.Point}");
            }
        }
    }

}
