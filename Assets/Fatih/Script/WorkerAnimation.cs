using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerAnimation : MonoBehaviour
{
    //public static BossAnimation bossAnimation;
    Animator animator;
    public enum AnimationType  { transportationDontwalkTrigger, TransportationTrigger, runningTrigger, idleTrigger };
    string AnimationFormerChech="";


    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine("RoutineAnimationChech");
    }
    

   /* private void OnEnable()
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
    }*/


    IEnumerator RoutineAnimationChech()
    {
        yield return new WaitForSeconds(2);
        AniamtionChech();
        StartCoroutine("RoutineAnimationChech");
    }

    void  AniamtionChech()
    {
        if (this.tag== "HaveBox" && AnimationFormerChech!= "HaveBox")
        {
            AnimationFormerChech = "HaveBox";
            AnimationTrigger(AnimationType.TransportationTrigger);
        }
        else if (this.tag == "Player" && AnimationFormerChech != "Player")
        {
            AnimationFormerChech = "Player";
            AnimationTrigger(AnimationType.runningTrigger);
        }
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
