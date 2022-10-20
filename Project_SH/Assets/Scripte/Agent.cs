//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Agent : MonoBehaviour {
//    private Rigidbody rig;

//    public List<Vector3> MoveVec = new List<Vector3>() {
//        new Vector3(-1,0, 0),
//        new Vector3(-1,0, 1),
//        new Vector3(0,0, 1),
//        new Vector3(1,0, 1),
//        new Vector3(1,0, 0),
//        new Vector3(1,0, -1),
//        new Vector3(0,0, -1),
//        new Vector3(-1,0, -1)
//    };

//    void Awake() {
//        rig = GetComponent<Rigidbody>();
//    }
//    void Update() {
//        //每秒更
//    }

//    void FixedUpdate() {
//        if (PathFinding.Instance.CanMove) {
//            //每物理帧更新速度
//            var node = Map.Instance.MapArray[(int) (transform.position.x * 10), (int) (transform.position.z * 10)];
//            if(node.CanPass && node.Vec != Vector2.zero) {
//                node.Vec.Normalize();
//                rig.velocity = new Vector3(node.Vec.x * 10, 0, node.Vec.y * 10);
//            }

//            //TODO:还需要不要靠近墙壁

//        }

//    }
//}
