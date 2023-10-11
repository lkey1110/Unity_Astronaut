
using UnityEditor;
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
        [SerializeField, Header("檢查地板尺寸")]
        private Vector3 v3CheckGroundSize = Vector3.one;
        [SerializeField, Header("檢查地板位移")]
        private Vector3 v3CheckGroundoffset = Vector3.zero;
        [SerializeField, Header("要偵測的地板圖層")]
        private LayerMask layerCheckGround;
        [SerializeField, Header("跳躍力道"), Range(0, 3000)]
        private float jumpPower = 1000;

        private Rigidbody2D rig;
        private Animator ani;
        private string parRun = "on/off run";

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0, 0.3f, 0.5f);
            Gizmos.DrawCube(transform.position + v3CheckGroundoffset, v3CheckGroundSize);
        }
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
            //CheckGround();
            Jump();
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

        private void Jump()
        {
            if (CheckGround() && Input.GetKeyDown(KeyCode.space))
            {
                rig.AddForce(new Vector2(0, jumpPower));
            }
        }

        private bool CheckGround()
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + v3CheckGroundoffset, v3CheckGroundSize, 0, layerCheckGround);
            //print($"<color~#69f>碰到的物件 : {hit.name}</color>");
            return hit;
        }
    }

}

