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

        foreach (var raycastHit in getHits) {
            var gameObject = raycastHit.collider.gameObject;
            if (!gameObject.name.StartsWith("Plane")) {
                continue;
            }


            _point.x = (int) raycastHit.point.x;
            _point.y = (int) raycastHit.point.y;
            _point.z = (int) raycastHit.point.z;
            return true;
        }

        return false;
    }
}
