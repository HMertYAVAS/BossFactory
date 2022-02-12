using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    Animator animator;


    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<Animator>().SetTrigger("doorTrigger");
    }
}
