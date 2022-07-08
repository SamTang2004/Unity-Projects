using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMF
{
    public class AirControlPowerup : MonoBehaviour
    {
        public float addedAirControlRate = 25;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<AdvancedWalkerController>())
            {

                other.gameObject.GetComponent<AdvancedWalkerController>().airControlRate += addedAirControlRate;
                Destroy(gameObject);
            }
        }
    }
}