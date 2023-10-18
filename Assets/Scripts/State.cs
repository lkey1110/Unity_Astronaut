
using UnityEngine;
namespace Lkey
{
    /// <summary>
    /// 狀態抽象類別
    /// </summary>
    public abstract class State : MonoBehaviour
    {
        /// <summary>
        /// 執行當前的狀態
        /// </summary>
        /// <teturns>當前的狀態</teturns>
        public abstract State RunCurrentState();

        /// <summary>
        /// 動畫控制元件(唯讀)
        /// </summary>
        protected Animator ani { get; private set; }

        protected void Awake()
        {
            ani = GetComponent<Animator>();
        }
    }
}

