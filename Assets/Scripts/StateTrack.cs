using UnityEditor;
using UnityEngine;
namespace Lkey
{


    public class StateTrack : State
    {
        [SerializeField, Header("追蹤速度"), Range(0, 5)]
        private float speed = 3.5f;
        [SerializeField, Header("遊走狀態")]
        private StateWander stateWander;

        private Rigidbody2D rig;
        private string parWalk = "開關走路";

        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
        }

        public override State RunCurrentState()
        {
            ani.SetBool(parWalk, true);
            ani.speed = 5;
            rig.velocity = new Vector2(speed*stateWander.direction, rig.velocity.y);
            return this;
        }
    }
}