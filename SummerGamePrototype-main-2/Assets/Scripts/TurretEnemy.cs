using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMF
{
    public class TurretEnemy : Enemies
    {

        public Transform turretModel;
        public float rotateSpeed = 10;
        public float attackInterval = 1;
        public GameObject projectile;
        public Collider detectionRange;
        public Transform playerTransform;
        private float nextAttackTime;
        public float projectileSpeed = 200;
        // Start is called before the first frame update
        void Start()
        {
            nextAttackTime = Time.time;
            playerTransform = GameObject.Find("PlayerCenter").transform;
        }

        public override void Attack()
        {
            //Debug.Log("Next attack in: " + nextAttackTime);
            GameObject proj = Instantiate(projectile, transform.position, new Quaternion());
            proj.GetComponent<Projectile>().initialVelocity = (playerTransform.position - proj.transform.position).normalized * projectileSpeed;
            //Debug.Log("Attacking player " + playerTransform.position + " Launching at " + (proj.transform.position + playerTransform.position));

        }

        // Update is called once per frame
        void Update()
        {
            turretModel.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
            if (Time.time >= nextAttackTime && (detectionRange.ClosestPoint(playerTransform.position) == playerTransform.position))
            {
                //Debug.Log("Attack called at time " + nextAttackTime);
                Attack();
                nextAttackTime =Time.time +  attackInterval;
            }
        }
    }
}
