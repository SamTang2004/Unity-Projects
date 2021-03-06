using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMF;
public class BearTrap : TrapsFather
{
    public ModifiedWalkerController playerMovementScript;
    //for player movement speed and jump chance
    public float playerspeed = 0.0f;
    public int playerMaxJump = 0;
    
    public bool destory = false;
    public float destoryTime = 5f;

    [SerializeField]public Animator trapAnimator;

    public GameObject stuckUi;

    private Vector3 initialTrapPosition;

    void Start()
    {
        initialTrapPosition = transform.position;
        playerMovementScript = GameObject.Find("Player").GetComponent<ModifiedWalkerController>();

        //set it to false so won't activate at beginning 
        trapAnimator.SetBool("playerEnter", false);
        //set it to player valuable 
        playerspeed = playerMovementScript.movementSpeed;
        playerMaxJump = playerMovementScript.maxJumps;
        //hide the "ouch" ui
        if(stuckUi != null)
        {
            stuckUi.SetActive(false);
        }
        
    }

    private bool hasTrapped = false;

    void beingTrap()
    {

            //set it to 0, so player cant move
            playerMovementScript.transform.position = initialTrapPosition + new Vector3(0, 2f, 0);
            playerMovementScript.movementSpeed = 0;
            playerMovementScript.SetMomentum(new Vector3());
            playerMovementScript.maxJumps = 0;

    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "PlayerLowerBoundTrigger")
        {
            //activate the trap
            trapAnimator.SetBool("playerEnter", true);
            //after amount of time the gameobject will destory
            destory = true;
            //shows the "ouch" ui
            if(!stuckUi.activeInHierarchy)
            {
                stuckUi.SetActive(true);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(destory == true)
        {
            beingTrap();
            destoryTime -= Time.deltaTime;
            if (destoryTime <= 0)
            {
                if(stuckUi.activeInHierarchy)
                {
                    stuckUi.SetActive(false);
                }
                //set it back
                playerMovementScript.movementSpeed = playerspeed;
                playerMovementScript.maxJumps = playerMaxJump;
                //object destory
                Destroy(gameObject);
                destory = false;
            }
        }
    }
}
