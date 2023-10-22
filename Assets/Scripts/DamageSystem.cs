﻿using TMPro;
using UnityEngine;
namespace Lkey
{
    /// <summary>
    /// 受傷系統 : 血量、受傷方法、死亡方法
    /// </summary>
    public class DamageSystem : MonoBehaviour
    {
        [SerializeField, Header("資料")]
        private DataBasic data;
        [SerializeField, Header("傷害值文字預製物")]
        private GameObject prefabDamage;

        protected float hp;
        protected float hpMax;

        private void Awake()
        {
            hp = data.hp;
            hpMax = hp;
        }
        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="getDamage">受到的傷害</param>
        public virtual void Damage(float getDamage)
        {
            hp -= getDamage;

            GameObject tempDamage = Instantiate(prefabDamage, transform.position + Vector3.up, Quaternion.identity);
            tempDamage.transform.GetChild(0).GetComponent<TextMeshPro>().text = getDamage.ToString();
            Destroy(tempDamage, 1.5f );

            if (hp <= 0) Dead();
        }
        /// <summary>
        /// 死亡
        /// </summary>
        protected virtual void Dead()
        {
            
        }
    }

}

