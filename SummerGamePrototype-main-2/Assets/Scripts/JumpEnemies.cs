using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CMF {
    public class JumpEnemies : MonoBehaviour
    {

        public float health = 2;
        public float maxHealth = 2;
        public float jumpStrength = 10;
        public float attackInvulnerabilityTime = 0.2f;
        public float attackDamage = 1;
        [SerializeField]
        private bool canBeAttacked = true;
        private bool waiting = false;

        // knockback stuff
        public int knockbackStrength = 20;
        public int knockbackHeight = 10;


        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PlayerLowerBoundTrigger"))
            {
                if (other.transform.parent.CompareTag("Player"))
                {

                    ModifiedWalkerController AWC = other.GetComponentInParent<ModifiedWalkerController>();
                    AWC.SetMomentum(new Vector3(AWC.GetMomentum().x, AWC.GetMomentum().y + jumpStrength, AWC.GetMomentum().z));
                    CombatSystem CS = other.GetComponentInParent<CombatSystem>();
                    if (canBeAttacked)
                    {
                        health -= CS.attackDamage;
                    }
                    if (!waiting)
                    {
                        StartCoroutine(waitCoroutine());
                    }

                    if (health <= 0)
                    {
                        Destroy(gameObject);
                    }
                }

            }

        }
        IEnumerator waitCoroutine() {
            waiting = true;
            canBeAttacked = false;
            yield return new WaitForSeconds(attackInvulnerabilityTime);
            canBeAttacked = true;
            waiting = false;
        }
    }
}