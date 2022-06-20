using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    // Start is called before the first frame update
    public bool CanMove;
    public static PathFinding Instance;
    [SerializeField]private GameObject Player;
    private long FindingTimes;

    public List<Vector3> MoveVec;

    public GameObject[] go = new GameObject[8];
    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }

    }

    void Start() {
        MoveVec = new List<Vector3>() {
            new Vector3(-1,0, 0),

            new Vector3(0,0, 1),

            new Vector3(1,0, 0),

            new Vector3(0,0, -1),

        };
        CreatField((int)(Player.gameObject.transform.position.x * 10), (int)(Player.gameObject.transform.position.z * 10));
    }

    public void CreatField(int startX,int startY) {
        if (Player == null) {
            return;
        }

        FindingTimes++;
        //var startX = (int)(Player.gameObject.transform.position.x * 10);
        //var startY = (int)(Player.gameObject.transform.position.z * 10);
        Queue<Node> queue = new Queue<Node>();
        var startNode = Map.Instance.MapArray[startX, startY];
        queue.Enqueue(startNode);
        startNode.Distance = 0;
        int count = 0;
        while (queue.Count > 0) {
            count++;
            var node = queue.Dequeue();
            node.FindingTimes = FindingTimes;
            for (int i = 0; i < 4; i++) {
                var nextLeftPos = MoveVec[i];
                var nextX = (node.x + (int)nextLeftPos.x);
                var nextY = (node.y + (int)nextLeftPos.z);
                if (nextX >= 1000 || nextX < 0 || nextY >= 1000 || nextY < 0) {
                    continue;
                }
                var nextNode = Map.Instance.MapArray[nextX , nextY];
                if (nextNode.FindingTimes >= FindingTimes || nextNode.CanPass == false) {
                    continue;
                }

                nextNode.Distance = node.Distance + 1;
                nextNode.FindingTimes = FindingTimes;
                
                queue.Enqueue(nextNode);
            }
        }
        Debug.Log($"遍历了{count}个点");
        for (int i = 0; i < 1000; i++) {
            for (int j = 0; j < 1000; j++) {

                var node = Map.Instance.MapArray[i, j];
                
                if (i - 1 >= 0 && i + 1 < 1000) {
                    var leftNode = Map.Instance.MapArray[i - 1, j];
                    var rightNode = Map.Instance.MapArray[i + 1, j];
                    if (leftNode.CanPass && rightNode.CanPass) {
                        node.Vec.x = leftNode.Distance - rightNode.Distance;
                    }else if (!leftNode.CanPass) {
                        node.Vec.x = node.Distance - rightNode.Distance;
                    }
                    
                }else if (i - 1 < 0) {
                    var rightNode = Map.Instance.MapArray[i + 1, j];
                    if (rightNode.CanPass) {
                        node.Vec.x = node.Distance - rightNode.Distance;
                    }
                    else {
                        node.Vec.x = 0;
                    }

                }else if (i + 1 >= 1000) {
                    var leftNode = Map.Instance.MapArray[i - 1, j];
                    if (leftNode.CanPass) {
                        node.Vec.x = leftNode.Distance - node.Distance;
                    }
                    else {
                        node.Vec.x = 0;
                    }
                }

                if (j - 1 >= 0 && j + 1 < 1000) {
                    var leftNode = Map.Instance.MapArray[i, j + 1];
                    var rightNode = Map.Instance.MapArray[i, j - 1];
                    if (leftNode.CanPass && rightNode.CanPass) {
                        node.Vec.y = leftNode.Distance - rightNode.Distance;
                    }
                    else if (!leftNode.CanPass) {
                        node.Vec.y = node.Distance - rightNode.Distance;
                    }

                }
                else if (j - 1 < 0) {
                    var leftNode = Map.Instance.MapArray[i, j + 1];
                    if (leftNode.CanPass) {
                        node.Vec.y = leftNode.Distance - node.Distance ;
                    }
                    else {
                        node.Vec.y = 0;
                    }

                }
                else if (j + 1 >= 1000) {
                    var leftNode = Map.Instance.MapArray[i, j - 1];
                    if (leftNode.CanPass) {
                        node.Vec.y = node.Distance - leftNode.Distance ;
                    }
                    else {
                        node.Vec.y = 0;
                    }
                }
            }
        }
        this.CanMove = true;


    }
}
