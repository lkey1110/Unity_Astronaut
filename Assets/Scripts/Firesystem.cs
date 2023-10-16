
using UnityEngine;
namespace Lkey
{
    /// <summary>
    /// �}�j�t��
    /// </summary>
    public class fireSystem : MonoBehaviour
    {
        [SerializeField, Header("�l�u�w�s��")]
        private GameObject prefabBullet;
        [SerializeField, Header("�ͦ��l�u��m")]
        private Transform pointBullet;
        [SerializeField, Header("�o�g�l�u�O�D"), Range(0, 5000)]
        private float powerBullet = 1000;

        private Animator ani;
        private string parFire = "openFire";

        private void Awake()
        {
            ani = GetComponent<Animator>();
        }

        private void Update()
        {
            Fire();
        }
        /// <summary>
        /// �}�j
        /// </summary>
        private void Fire() 
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ani.SetTrigger(parFire);
                GameObject tempBullet = Instantiate(prefabBullet, pointBullet.position, transform.rotation);
                tempBullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * powerBullet);
            }
        }

    }

}
