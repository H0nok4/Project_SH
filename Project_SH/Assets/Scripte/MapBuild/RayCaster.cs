using System;
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
    private Vector3 _normal;
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

    public Vector3 Normal {
        get {
            return _normal;
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

        for (int i = getHits.Length- 1; i >= 0; i--) {
            var gameObject = getHits[i].collider.gameObject;
            if (!gameObject.tag.StartsWith("Map")) {
                continue;
            }

            _normal.x = getHits[i].normal.x;
            _normal.y = getHits[i].normal.y;
            _normal.z = getHits[i].normal.z;
            _point.x = Mathf.FloorToInt(getHits[i].point.x);
            _point.y = Mathf.FloorToInt(getHits[i].point.y + 0.001f);
            _point.z = Mathf.FloorToInt(getHits[i].point.z);
            return true;
        }

        return false;
    }
}
