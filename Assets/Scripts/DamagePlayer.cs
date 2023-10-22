using Fungus;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Lkey
{
    /// <summary>
    /// 玩家受傷
    /// </summary>
    public class DamagePlayer : DamageSystem
    {
        [SerializeField, Header("血條")]
        private Image imgHp;
        [SerializeField, Header("遊戲管理器")]
        protected Flowchart fungusGM;
        [SerializeField, Header("受傷著色器材質球")]
        private Material mHurt;


        private void OnEnable()
        {
            mHurt.SetFloat("_Hurt", 0);
        }
        private void OnDisable()
        {
            mHurt.SetFloat("_Hurt", 0);
        }

        public override void Damage(float getDamage)
        {
            base.Damage(getDamage); //父類別原有內容

            imgHp.fillAmount = hp / hpMax;

            StartCoroutine(DamageEffect());
        }

        protected override void Dead()
        {
            fungusGM.SendFungusMessage("遊戲失敗");
            Destroy(gameObject);
        }

        private IEnumerator DamageEffect()
        {

            mHurt.SetFloat("_Hurt", 0.3f);
            yield return new WaitForSeconds(0.1f);
            mHurt.SetFloat("_Hurt", 0);
            yield return new WaitForSeconds(0.1f);
            
        }
    }
}

