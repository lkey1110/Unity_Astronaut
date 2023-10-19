using UnityEngine;
namespace Lkey
{


    public class StateAttack : State
    {
        private string parAttack = "觸發攻擊";

        public override State RunCurrentState()
        {
            ani.SetTrigger(parAttack);
            return this;
        }
    }
}