using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CMF {
    public class FrontDoorCollider : MonoBehaviour
    {

        public RotationDoor rd;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerStay(Collider other)
        {
            
            if (other.gameObject.GetComponent<AdvancedWalkerController>() && Input.GetKey(KeyCode.F))
            {
                

                rd.frontDoorPushed = true;
                
            }
            else
            {
                rd.frontDoorPushed = false;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<AdvancedWalkerController>())
            {
                rd.frontDoorPushed = false;
            }
        }
    }
}
