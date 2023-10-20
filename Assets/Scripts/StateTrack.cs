using UnityEngine;
namespace Lkey
{
    public class StateTrack : State
    {
        public override State RunCurrentState()
        {
            return this;
        }
    }
}
