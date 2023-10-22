using UnityEngine;

namespace Lkey
{
    /// <summary>
    /// 子彈
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        [Header("玩家資料")]
        public DataBasic dataPlayer;

        private void Awake()
        {
            Destroy(gameObject, 5); //子彈存活5秒後刪除
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }
    }

}

