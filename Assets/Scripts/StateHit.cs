using UnityEngine;
namespace Lkey
{


    public class StateHit : State
    {
        public override State RunCurrentState()
        {
            return this;
        }
    }
}