using UnityEngine;
namespace Lkey
{
    public class StateWander : State
    {
        [SerializeField, Header("角色的初始座標")]
        private Vector3 pointOriginal;

        private string parWalk = "開關走路";
        private Rigidbody2D rig;

        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
        }

        public override State RunCurrentState()
        {
            ani.SetBool(parWalk, true);
            return this;
        }

        [ContextMenu("取得角色原始座標")]
        private void GetOriginalpoint()
        {
            pointOriginal = transform.position;
        }
    }
}
