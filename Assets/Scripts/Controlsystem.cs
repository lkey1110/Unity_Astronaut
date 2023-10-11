
using UnityEngine;

namespace Lkey.TwoD

{
    /// <summary>
    /// 2D橫向卷軸控制系統:移動、跳躍與動畫
    /// </summary>
    public class C : MonoBehaviour
    {
        [SerializeField, Header("移動速度"), Range(0, 50)]
        private float moveSpeed = 3.5f;

        private Rigidbody2D rig;
        private Animator ani;
        private string parRun = "on/off run";
        private void Awake()
        {
           // print("<color=yellow>喚醒事件</color>");

            rig = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
        }
        private void Start()
        {
            //print("<color=yellow>開始事件</color>");
        }
        private void Update()
        {
            //print("<color=yellow>更新事件</color>");

            MoveAndFlip();
        }

        /// <summary>
        /// 移動與翻面
        /// </summary>
        private void MoveAndFlip()
        {
            //float v = Input.GetAxis("Vertiacl");
            //print("<color=#f66>垂直的值:" + v + "</color>");

            float h = Input.GetAxis("Horizontal");
            rig.velocity = new Vector2(h * moveSpeed, rig.velocity.y);

            if (Input.GetKeyDown(KeyCode.A))
            {
                print("按下A");
                transform.eulerAngles = Vector3.zero;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                print("按下D");
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

            ani.SetBool(parRun, h != 0);
        }
    }

}

