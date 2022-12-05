using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    private Camera Camera {
        get {
            return Camera.main;
        }
    }

    private Vector3 _point;
    private bool _hasPoint;

    public Vector3 Point {
        get {
            return _point;
        }
    }

    public bool HasPoint {
        get {
            return _hasPoint;
        }
    }

    // Update is called once per frame
    void Update() {
        _hasPoint = GetPoint();
    }

    public bool GetPoint() {
        if (Input.mousePosition == Vector3.zero) {
            return false;
        }

        if (Camera == null) {
            return false;
        }

        var ray = Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        var getHits = Physics.RaycastAll(ray, 1000f);

        if (getHits.Length <= 0) {
            return false;
        }

        Debug.Log($"总共碰撞了{getHits.Length}个");
        for (int i = getHits.Length- 1; i >= 0; i--) {
            var gameObject = getHits[i].collider.gameObject;
            if (!gameObject.tag.StartsWith("Map")) {
                continue;
            }


            _point.x = (int) (getHits[i].point.x - 0.5f);
            _point.y = (int) (getHits[i].point.y );
            _point.z = (int) (getHits[i].point.z - 0.5f);
            return true;
        }

        return false;
    }
}
