using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Animator animator;
    public void OpenSettingsAnim()
    {
        animator.SetTrigger("rotate");
    }
}
