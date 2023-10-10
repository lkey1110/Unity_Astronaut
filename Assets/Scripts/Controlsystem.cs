
using UnityEngine;

namespace Lkey.TwoD

{
    /// <summary>
    /// 2D橫向卷軸控制系統:移動、跳躍與動畫
    /// </summary>
    public class C : MonoBehaviour
    {
        [SerializeField, Header("移動速度"), Range(0, 500)]
        private float moveSpeed = 3.5f;

        private Rigidbody2D rig;

        private void Awake()
        {
           // print("<color=yellow>喚醒事件</color>");

            rig = GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            //print("<color=yellow>開始事件</color>");
        }
        private void Update()
        {
            //print("<color=yellow>更新事件</color>");

            //float v = Input.GetAxis("Vertiacl");
            //print("<color=#f66>垂直的值:" + v + "</color>");

            float h = Input.GetAxis("Horizontal");
            rig.velocity = new Vector2 (h* moveSpeed, rig.velocity.y);
        }
    }

}

