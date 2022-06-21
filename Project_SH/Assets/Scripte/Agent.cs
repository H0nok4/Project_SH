using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {
    private Rigidbody rig;

    public List<Vector3> MoveVec = new List<Vector3>() {
        new Vector3(-1,0, 0),
        new Vector3(-1,0, 1),
        new Vector3(0,0, 1),
        new Vector3(1,0, 1),
        new Vector3(1,0, 0),
        new Vector3(1,0, -1),
        new Vector3(0,0, -1),
        new Vector3(-1,0, -1)
    };

    void Awake() {
        rig = GetComponent<Rigidbody>();
    }
    void Update() {
        //ÿ���
    }

    void FixedUpdate() {
        if (PathFinding.Instance.CanMove) {
            //ÿ����֡�����ٶ�
            var node = Map.Instance.MapArray[(int) (transform.position.x * 10), (int) (transform.position.z * 10)];
            node.Vec.Normalize();
            rig.velocity = new Vector3(node.Vec.x * 5,0,-node.Vec.y * 5);
        }

    }
}
