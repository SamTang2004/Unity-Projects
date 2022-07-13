using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{

    public float slashAngle = 270f;
    public Collider coll;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isSlashing);
        if (Input.GetKeyDown(KeyCode.F) && !isSlashing)
        {
            StartCoroutine(SlashCoroutine());

        }

    }


    public float slashRate = 4;
    [SerializeField]
    private bool isSlashing = false;
    IEnumerator SlashCoroutine()
    {
        isSlashing = true;
        Quaternion startRotation = transform.localRotation;
        float endZRot = 270f;
        float duration = 1f;
        float t = 0;
        float time;
        while (t < 1f)
        {
            Debug.Log("slashing. " + transform.localRotation.eulerAngles);
            t += Time.deltaTime* slashRate;
            time = Mathf.Min(1f, t + Time.deltaTime / duration);
            Vector3 newEulerOffset = new Vector3(0,1,0) * (endZRot * t);
            // global z rotation
            //transform.localRotation = Quaternion.Euler(newEulerOffset) * startRotation;
            // local z rotation
            transform.localRotation = startRotation * Quaternion.Euler(newEulerOffset);
            yield return null;
        }

        endZRot = 0f;
        t = 0;
        while (t < 1f)
        {
            Debug.Log("slashing. " + transform.localRotation.eulerAngles);
            t += Time.deltaTime * slashRate;
            time = Mathf.Min(1f, t + Time.deltaTime / duration);
            Vector3 newEulerOffset = new Vector3(0, 1, 0) * (endZRot * t);
            // global z rotation
            //transform.localRotation = Quaternion.Euler(newEulerOffset) * startRotation;
            // local z rotation
            transform.localRotation = startRotation * Quaternion.Euler(newEulerOffset);
            yield return null;
        }

        isSlashing = false;
    }

    
}
