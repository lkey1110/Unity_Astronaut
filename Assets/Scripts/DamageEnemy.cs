using Lkey;
using UnityEngine;
namespace Lkey
{
    /// <summary>
    /// 敵人受傷
    /// </summary>
    public class DamageEnemy : DamageSystem
    {
        [SerializeField, Header("狀態管理")]
        private StateManager stateManager;
        [SerializeField, Header("受傷狀態")]
        private StateHit stateHit;
        [SerializeField, Header("掉落道具")]
        private GameObject prefabItem;

        private string nameBullet = "子彈";
        private Animator ani;
        private string parDead = "開關死亡";
        private StateManager stateManger; //不能取stateManager跟狀蓋管理名稱重複
        private Rigidbody2D rig;
        private Collider2D col;

        private void Start()
        {
            ani = GetComponent<Animator>();
            stateManger = GetComponent<StateManager>();
            rig = GetComponent<Rigidbody2D>();
            col = GetComponent<Collider2D>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name.Contains(nameBullet))
            {
                float bulletAttack = collision.gameObject.GetComponent<Bullet>().dataPlayer.attack;
                Damage(bulletAttack);
                Destroy(collision.gameObject);
                stateManager.stateDefault = stateHit; //受傷時狀態改為受傷
            }
        }
        protected override void Dead()
        {
            ani.SetBool(parDead, true);
            stateManger.enabled = false;
            rig.bodyType = RigidbodyType2D.Kinematic;
            col.enabled = false;
            rig.velocity = Vector3.zero;
            GameObject tempItem = Instantiate(prefabItem, transform.transform.position + Vector3.up, Quaternion.identity);
            tempItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 100));
            //Destroy(gameObject);
        }


    }

}

