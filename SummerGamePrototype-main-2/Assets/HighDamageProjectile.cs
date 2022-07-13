using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMF {
    public class HighDamageProjectile :Projectile
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            GetComponent<Rigidbody>().velocity = initialVelocity;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Enemies>())
            {
                collision.gameObject.GetComponent<Enemies>().onHit(damage);
            }
            Destroy(gameObject);
        }

    }

}
