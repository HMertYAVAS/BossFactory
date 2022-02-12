using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    public static BossAnimation bossAnimation;
    Animator animator;
    public enum AnimationType  { transportationDontwalkTrigger, TransportationTrigger, runningTrigger, idleTrigger };
   
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
       
    }
    

    private void OnEnable()
    {
        if (bossAnimation == null)
        {
            bossAnimation = this;
        }
        else
        {
            if (bossAnimation != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void AnimationTrigger(AnimationType animationType)
    {
        switch (animationType)
        {
            case AnimationType.transportationDontwalkTrigger:
                animator.SetTrigger("transportationDontwalkTrigger");
                break;
            case AnimationType.TransportationTrigger:
                animator.SetTrigger("TransportationTrigger");
                break;
            case AnimationType.runningTrigger:
                animator.SetTrigger("runningTrigger");
                break;
            case AnimationType.idleTrigger:
                animator.SetTrigger("idleTrigger");
                break;
        }
    }

}
