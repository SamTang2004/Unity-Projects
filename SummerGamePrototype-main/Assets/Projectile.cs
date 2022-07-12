using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMF {
    public class Projectile : MonoBehaviour
    {


        public int enemyLayer = 7;
        public float damage = 1;
        private int bounceTimes = 0;
        public int maxBounceTimes = 5;

        public Vector3 initialVelocity;

        // Start is called before the first frame update
        void Start()
        {
            GetComponent<Rigidbody>().velocity = initialVelocity;
            Destroy(gameObject, 5);
        }

        // Update is called once per frame
        void Update()
        {

            
        }

        private void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.GetComponent<AdvancedWalkerController>())
            {

                Physics.IgnoreCollision(gameObject.GetComponent<CapsuleCollider>(), collision.gameObject.GetComponent<CapsuleCollider>());
            }

            if (collision.gameObject.layer == 7)
            {
                collision.gameObject.GetComponent<JumpEnemies>().health -= damage;
                Destroy(gameObject);

            }
            bounceTimes++;
            if (bounceTimes >= maxBounceTimes)
            {
                Destroy(gameObject);
            }
        }
    }
}