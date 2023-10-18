
using Fungus;
using UnityEngine;
namespace Lkey
{


    public class StateIdle : State
    {

        [SerializeField, Header("遊走狀態")]
        private StateWander stateWander;
        [SerializeField, Header("是否開始游走")]
        private bool starWander;
        [SerializeField, Header("等待狀態的時間範圍")]
        private Vector2 rangeIdleTime = new Vector2(0, 3);
        [SerializeField, Header("追蹤狀態")]
        private StateTrack stateTrack;

        private float timeIdle;
        private float timer;

        private void Start()
        {
            timeIdle = Random.Range(rangeIdleTime.x, rangeIdleTime.y);
            //print($"<color=#d6f>隨機等待時間 : {timeIdle}</color>");
        }

        public override State RunCurrentState()
        {
            timer += Time.deltaTime;
           // print($"<color=#69f>計時器 :{timer}</color>");

            if (timer >= timeIdle) starWander = true;

            if (stateWander.TrackTarget())
            {
               ResetState();
                return stateTrack;
            }

            else if (starWander)
            {
                ResetState();
                return stateWander;
            }

            else
            {
                return this;
            }
        }

        private void ResetState()
        {
            timer = 0;
            starWander = false;
            timeIdle = Random.Range(rangeIdleTime.x, rangeIdleTime.y);
        }
    }
}
