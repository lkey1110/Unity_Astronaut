using UnityEngine;
namespace Lkey
{
    public class StateAttack : State
    {
        public override State RunCurrentState()
        {
            return this;
        }
    }
}
