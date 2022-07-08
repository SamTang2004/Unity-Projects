using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationDoor : MonoBehaviour
{

    public Transform doorModel;
    public bool frontDoorPushed;
    public bool backDoorPushed;

    IEnumerator rotationCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator openForward()
    {

        yield return null;

    }



}
