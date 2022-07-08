using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelTransitioner : MonoBehaviour
{
    public string nextSceneName;

    bool inRangeToMove = false;
    TMP_Text floatingText;

    private void Start()
    {
        floatingText = GetComponentInChildren<TMP_Text>();
        floatingText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("In range");
            inRangeToMove = true;
            floatingText.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRangeToMove = false;
            floatingText.enabled = false;
        }
    }

    private void Update()
    {
        if(inRangeToMove)
        {
            if(Input.GetKey("e"))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
