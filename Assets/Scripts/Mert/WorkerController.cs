using System;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class WorkerController : MonoBehaviour
{
    private NavMeshAgent worker;
    
    float workTimeTemp;
    Animator animator;

    BoxesController boxesController;

    Sequence seq;

    Transform lookTrans;

    bool playerInTrigger;

    //public int workerPrice;

    public Transform way1;
    public Transform way2;

    private void Start()
    {
        animator = GetComponent<Animator>();
        boxesController = GetComponent<BoxesController>();

        worker = GetComponent<NavMeshAgent>();
        worker.SetDestination(way1.position);
    }

    private void Update()
    {
        WalkEnemyToWay();
    }

    public void AnimationTrigger()
    {
        if (boxesController.BoxesListLine > 0)
        {
            animator.SetTrigger("TransportationTrigger");
        }
        else
        {
            animator.SetTrigger("runningTrigger");
        }
    }

    private void WalkEnemyToWay()
    {
        if (way1.position.x == transform.position.x && way1.position.z == transform.position.z)
        {
            worker.SetDestination(way2.position);
        }else if (way1.position.x == transform.position.x && way1.position.z == transform.position.z)
        {
            worker.SetDestination(way1.position);
        }
    }
}
