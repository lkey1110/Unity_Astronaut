using UnityEngine;
namespace Lkey
{
    /// <summary>
    /// 受傷狀態
    /// </summary>
    /// <returns></returns>
    public class StateHit : State
    {
        private string parHit = "觸發受傷";
        private bool isHit;
        private float timeHit = 0.6f;
        private float timer;

        [SerializeField, Header("遊走狀態")]
        private StateWander stateWander;
        [SerializeField, Header("攻擊狀態")]
        private StateAttack stateAttack;

        private Transform player;
        private void Start()
        {
            player = GameObject.Find("太空員").transform;
        }
        public override State RunCurrentState()
        {
            if (!isHit)
            {
                isHit = true;
                ani.SetTrigger(parHit);
                FlipToPlayer();
                stateAttack.ResetAttackState();
            }

            if (isHit)
            {
                timer += Time.deltaTime;
                if (timer > timeHit)
                {
                    isHit =false;
                    return stateWander;
                }
            }

            return this;
        }

        private void FlipToPlayer()
        {
            if (transform.position.x > player.position.x)
            {
                stateWander.direction = -1;
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (transform.position.x < player.position.x)
            {
                stateWander.direction = 1;
                transform.eulerAngles = Vector3.zero;
            }
        }
    }
}
