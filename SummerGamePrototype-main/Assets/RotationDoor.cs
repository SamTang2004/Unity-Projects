using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationDoor : MonoBehaviour
{

    public Transform doorModel;
    public bool frontDoorPushed;
    public bool backDoorPushed;

    IEnumerator rotationCoroutine;

    // slave object of the colliders. turns on their command.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void openForwardStarter()
    {
        StopCoroutine(rotationCoroutine);
        rotationCoroutine = openForward();
        StartCoroutine(rotationCoroutine);

    }

    public float rotationRate = 1f;
    IEnumerator openForward()
    {
        float y = transform.rotation.y;
        while (transform.rotation.y - 90 >= 0.02)
        {
            y = Mathf.Lerp(y, 90, Time.deltaTime * rotationRate);
            yield return null;

        }
        transform.rotation = new Quaternion(transform.rotation.x, 90, transform.rotation.z, transform.rotation.w);

        yield return null;

    }



}
