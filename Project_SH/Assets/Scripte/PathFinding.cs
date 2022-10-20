//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;

//public class PathFinding : MonoBehaviour
//{
//    // Start is called before the first frame update
//    public bool CanMove;
//    public static PathFinding Instance;
//    [SerializeField]private GameObject Player;
//    private long FindingTimes;

//    public List<Vector3> MoveVec;

//    public GameObject[] go = new GameObject[8];
//    void Awake() {
//        if (Instance == null) {
//            Instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else {
//            Destroy(gameObject);
//        }

//    }

//    void Start() {
//        MoveVec = new List<Vector3>() {
//            new Vector3(-1,0, 0),

//            new Vector3(0,0, 1),

//            new Vector3(1,0, 0),

//            new Vector3(0,0, -1),

//        };
//        CreatField((int)(Player.gameObject.transform.position.x * 10), (int)(Player.gameObject.transform.position.z * 10));
//    }

//    public void CreatField(int startX,int startY) {
//        if (Player == null) {
//            return;
//        }

//        FindingTimes++;
//        //var startX = (int)(Player.gameObject.transform.position.x * 10);
//        //var startY = (int)(Player.gameObject.transform.position.z * 10);
//        Queue<Node> queue = new Queue<Node>();
//        var startNode = Map.Instance.MapArray[startX, startY];
//        queue.Enqueue(startNode);
//        startNode.Distance = 0;
//        int count = 0;

//        while (queue.Count > 0) {
//            count++;
//            var node = queue.Dequeue();
//            node.FindingTimes = FindingTimes;
//            for (int i = 0; i < 4; i++) {
//                var nextLeftPos = MoveVec[i];
//                var nextX = (node.x + (int)nextLeftPos.x);
//                var nextY = (node.y + (int)nextLeftPos.z);
//                if (nextX >= 1000 || nextX < 0 || nextY >= 1000 || nextY < 0) {
//                    continue;
//                }
//                var nextNode = Map.Instance.MapArray[nextX , nextY];
//                if (nextNode.FindingTimes >= FindingTimes || nextNode.CanPass == false) {

//                    continue;
//                }

//                nextNode.Distance = node.Distance + 1;
//                nextNode.FindingTimes = FindingTimes;
                
//                queue.Enqueue(nextNode);
//            }
//        }
//        Debug.Log($"遍历了{count}个点");
//        for (int i = 0; i < 1000; i++) {
//            for (int j = 0; j < 1000; j++) {

//                var node = Map.Instance.MapArray[i, j];
//                Node leftNode = null;
//                Node rightNode = null;
//                Node upNode = null;
//                Node downNode = null;
//                if (i - 1 >= 0 && i + 1 < 1000) {
//                    leftNode = Map.Instance.MapArray[i - 1, j];
//                    rightNode = Map.Instance.MapArray[i + 1, j];
//                    //if (leftNode.CanPass && rightNode.CanPass) {
//                    //    node.Vec.x = leftNode.Distance - rightNode.Distance;
//                    //}else if (!leftNode.CanPass) {
//                    //    node.Vec.x = node.Distance - rightNode.Distance;
//                    //}
                    
//                }else if (i - 1 < 0) {
//                     rightNode = Map.Instance.MapArray[i + 1, j];
//                    if (rightNode.CanPass) {
//                        node.Vec.x = node.Distance - rightNode.Distance;
//                    }
//                    else {
//                        node.Vec.x = 0;
//                    }

//                }else if (i + 1 >= 1000) {
//                    leftNode = Map.Instance.MapArray[i - 1, j];
//                    if (leftNode.CanPass) {
//                        node.Vec.x = leftNode.Distance - node.Distance;
//                    }
//                    else {
//                        node.Vec.x = 0;
//                    }
//                }

//                if (j - 1 >= 0 && j + 1 < 1000) {
//                    upNode = Map.Instance.MapArray[i, j + 1];
//                    downNode = Map.Instance.MapArray[i, j - 1];
//                    //if (upNode.CanPass && downNode.CanPass) {
//                    //    node.Vec.y = upNode.Distance - downNode.Distance;
//                    //}
//                    //else if (!upNode.CanPass) {
//                    //    node.Vec.y = node.Distance - downNode.Distance;
//                    //}else if (!downNode.CanPass) {
//                    //    node.Vec.y = upNode.Distance - node.Distance;
//                    //}

//                }
//                else if (j - 1 < 0) {
//                    upNode = Map.Instance.MapArray[i, j + 1];
//                    //if (upNode.CanPass) {
//                    //    node.Vec.y = upNode.Distance - node.Distance ;
//                    //}
//                    //else {
//                    //    node.Vec.y = 0;
//                    //}

//                }
//                else if (j + 1 >= 1000) {
//                    downNode = Map.Instance.MapArray[i, j - 1];
//                    //if (downNode.CanPass) {
//                    //    node.Vec.y = node.Distance - downNode.Distance ;
//                    //}
//                    //else {
//                    //    node.Vec.y = 0;
//                    //}
//                }

//                if (leftNode != null && leftNode.CanPass &&leftNode.Distance < node.Distance) {
//                    node.Vec = new Vector2(-1, 0);
//                }else if (upNode != null && upNode.CanPass &&  upNode.Distance < node.Distance) {
//                    node.Vec = new Vector2(0, 1);
//                }else if (rightNode != null && rightNode.CanPass&& rightNode.Distance < node.Distance) {
//                    node.Vec = new Vector2(1, 0);
//                }else if (downNode != null &&downNode.CanPass &&downNode.Distance < node.Distance) {
//                    node.Vec = new Vector2(0,-1);
//                }
//            }
//        }
//        this.CanMove = true;


//    }
//}
