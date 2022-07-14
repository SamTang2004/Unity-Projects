using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMF
{
    public class ProjectileLauncher : MonoBehaviour
    {
        public Camera view;
        public Transform crosshair;


        [SerializeField]
        private GameObject Projectile;
        public GameObject projectileCasing;
        public Animator anim;
        public AnimationClip shoot;
        public float fireDelay = 0.2f; // delay.
        public float nextFireTime;
        public float bulletSpeed = 4;
        public LayerMask whatIsBoundingBox;
        public Transform muzzlePosition;

        public GameObject[] ammunitionTypes;
        private int indexOfProjectile = 0;


        private Vector3 RelativePosition;
        private Vector3 originalRelativePosition;
        // Start is called before the first frame update
        void Start()
        {
            RelativePosition = transform.localPosition;
            originalRelativePosition = transform.localPosition;
        }



        public float raiseAmount = 0.26f;
        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (indexOfProjectile < ammunitionTypes.Length-1)
                {
                    indexOfProjectile += 1;
                }
                else
                {
                    indexOfProjectile = 0;
                }
                Projectile = ammunitionTypes[indexOfProjectile];
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                if (indexOfProjectile == 0)
                {
                    indexOfProjectile = ammunitionTypes.Length - 1;
                }
                else
                {
                    indexOfProjectile -= 1;
                }
                Projectile = ammunitionTypes[indexOfProjectile];
            }


            if (Input.GetMouseButton(1))
            {
                RelativePosition = new Vector3(0, -1.118f, 0.5f);
            }
            else
            {
                RelativePosition = originalRelativePosition;
            }
            if (GetComponentInParent<ModifiedWalkerController>().getCrouchState())
            {
                Vector3 _resizeY = new Vector3(RelativePosition.x,
                    RelativePosition.y / GetComponentInParent<ModifiedWalkerController>().crouchHeightModifier + raiseAmount,
                    RelativePosition.z);
                transform.localPosition = _resizeY;
            }
            else
            {
                transform.localPosition = RelativePosition;
            }

            


            GameObject pauseMenuUI = GameObject.Find("GameManager").transform.Find("PauseMenuUI").gameObject;
            RaycastHit hit;
            Physics.Raycast(view.ScreenPointToRay(crosshair.position), out hit, float.PositiveInfinity, whatIsBoundingBox);
            //Debug.Log(Physics.Raycast(view.ScreenPointToRay(crosshair.position), out hit, float.PositiveInfinity, whatIsBoundingBox));
            //Debug.DrawRay(view.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 1)), transform.forward);

            //Debug.Log(hit.point);
            //transform.rotation = Quaternion.Lerp( transform.rotation, cam.rotation, Time.deltaTime * 10);

            transform.LookAt(hit.point);

            if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime && !pauseMenuUI.activeInHierarchy)
            {
                Debug.Log("fired");

                nextFireTime = Time.time + fireDelay;
                GameObject firedProjectile = Instantiate(Projectile, muzzlePosition.position, muzzlePosition.rotation);
                if (!Input.GetMouseButton(1))
                {
                    firedProjectile.GetComponent<Projectile>().initialVelocity = transform.forward * bulletSpeed + getRandomVector3InMagnitudeRange(bulletSpread);

                }
                else
                {
                    firedProjectile.GetComponent<Projectile>().initialVelocity = transform.forward * bulletSpeed;
                }
            }


        
        
        }

        public float bulletSpread = 4;
        Vector3 getRandomVector3InMagnitudeRange(float range)
        {

            return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));


        }
    }
}
