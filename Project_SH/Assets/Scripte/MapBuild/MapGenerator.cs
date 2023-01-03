using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MapBuild
{
    public class MapGenerator : MonoBehaviour {
        private float _interval = 0.1f;
        private float _time = 0.1f;

        private MapGeneratorType _curGeneratorType;
        public MapGeneratorType CurGeneratorType {
            get {
                return _curGeneratorType;
            }
            set {
                _curGeneratorType = value;
                Debug.Log($"当前GeneratorMode为{_curGeneratorType}");
                Mode = GetMapGeneratorModeByType(value);
            }
        }

        //TODO:需要一个统一管理的资源
        public GameObject Block;
        public GameObject BlockPrefab;

        private IMapGeneratorMode Mode;

        public Map Map;
        public GameObject MapObject;

        private void Start()
        {
            CurGeneratorType = MapGeneratorType.DrawTile;
            Mode = new DrawMode();
            Map = new Map(10, 10, 10);
        }

        private void Update() {
            //每一帧检测镜头到鼠标的一条射线，找到第一个碰撞到的面，根据当前的模式来等待执行
            _time += Time.deltaTime;
            while (_time >= _interval) {
                _time -= _interval;
                Show(Mode);
                Run(Mode);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                Find.MapGenerator.CurGeneratorType = MapGeneratorType.EarseTile;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                Find.MapGenerator.CurGeneratorType = MapGeneratorType.DrawTile;
            }
        }
        public void RefreshMesh() {
            var mesh = GridGenerator.BuildMesh(Find.MapGenerator.Map);
            var meshCom = Find.MapGenerator.MapObject.GetComponent<MeshFilter>();
            meshCom.mesh = mesh;
            var collider = Find.MapGenerator.MapObject.GetComponent<MeshCollider>();
            var meshRenderer = Find.MapGenerator.MapObject.GetComponent<MeshRenderer>();
            collider.sharedMesh = mesh;
            collider.material = new PhysicMaterial();
        }

        public void Run(IMapGeneratorMode mode) {
            mode?.Run();
        }

        public void Show(IMapGeneratorMode mode) {
            mode?.Show();
        }

        private IMapGeneratorMode GetMapGeneratorModeByType(MapGeneratorType type) {
            switch (type) {
                case MapGeneratorType.DrawTile:
                    return new DrawMode();
                case MapGeneratorType.EarseTile:
                    return new EarseMode();
                default:
                    return null;
            }
        }
    }
}
