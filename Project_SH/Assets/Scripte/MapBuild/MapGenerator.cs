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
            //ÿһ֡��⾵ͷ������һ�����ߣ��ҵ���һ����ײ�����棬���ݵ�ǰ��ģʽ���ȴ�ִ��

        }
    }

}
