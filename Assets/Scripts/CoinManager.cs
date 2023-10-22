
using Fungus;
using LKey;
using TMPro;
using UnityEngine;

namespace Lkey
{
    public class CoinManager : MonoBehaviour
    {
        [SerializeField, Header("遊戲管理器")]
        private Flowchart flowchatGM;

        private TextMeshProUGUI textCoin;
        private int coinCurrent;
        private int coinTotal = 10;

        private void Awake()
        {
            textCoin = GameObject.Find("金幣數量").GetComponent<TextMeshProUGUI>();
            textCoin.text = $"金幣數量 : {coinCurrent}/{coinTotal}";
        }

        private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
        {
            if (collision.gameObject.name.Contains("金幣")) EatCoin(collision.gameObject);
        }
        private void EatCoin(GameObject coin)
        {
            AudioClip sound = SoundManager.instance.soundCoin;
            SoundManager.instance.PlaySound(sound, 0.7f, 1.7f);

            Destroy(coin);
            textCoin.text = $"金幣數量:{++coinCurrent}/{coinTotal}";

            if (coinCurrent >= coinTotal)
            {
                AudioClip soundWin = SoundManager.instance.soundWin;
                SoundManager.instance.PlaySound(sound, 0.7f, 1.7f);
                flowchatGM.SendFungusMessage("遊戲勝利");
            }
        }
    }

}

