using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    Animator animator;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        gameObject.GetComponent<Animator>().SetTrigger("doorTrigger");
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<Animator>().SetTrigger("doorclose");
    }
}
