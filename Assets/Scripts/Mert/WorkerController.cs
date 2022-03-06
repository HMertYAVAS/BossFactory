using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerController : MonoBehaviour
{
    public float moveTime;
    public float workTime;
    float workTimeTemp;
    Animator animator;

    BoxesController boxesController;

    Sequence seq;

    Transform lookTrans;

    bool playerInTrigger;

    //public int workerPrice;

    public Transform way1;
    public Transform way2;
    public Transform way3;
    public Transform way4;

    private void Start()
    {
        animator = GetComponent<Animator>();
        boxesController = GetComponent<BoxesController>();
        DOTween.Init();
        workTimeTemp = workTime;
        movingWorker();
    }

    //public void BuyToWorkerCoroutine()
    //{
    //    StartCoroutine(BuyToWorker());
    //}


    //IEnumerator BuyToWorker()
    //{
    //    yield return new WaitForSeconds(1f);
    //    if (workerPrice <= MoneyController.instance.money)
    //    {
    //        MoneyController.instance.money -= workerPrice;
    //        movingWorker();

    //    }
    //}

    private void Update() {
        transform.LookAt(lookTrans);
    }

    void movingWorker()
    {
        if (workTime > 1)
        {
            if (boxesController.BoxesListLine > 0)
            {
                animator.SetTrigger("TransportationTrigger");
            }
            else
            {
                animator.SetTrigger("runningTrigger");
            }

            seq = DOTween.Sequence();
            
            seq.Append(transform.DOMove(way2.transform.position, moveTime)).OnComplete(() => LookAtWorker(way3)).OnStart(() => LookAtWorker(way1))
            // TODO: OnComplete i�inde func de�i�tirilecek. Uygun tracking noktalar� eklendi�inde.
                .Append(transform.DOMove(way3.transform.position, moveTime)).OnComplete(() => LookAtWorker(way4))
                .Append(transform.DOMove(way4.position, moveTime).OnComplete(SleepWorker));
            workTime--;
        }
        else
        {
            // TODO Buras� uyku noktas�
            //this.gameObject.SetActive(false);
            StartCoroutine(SleepWorkerNum());

        }
    }

    void RestartWorker()
    {
        if (workTime > 0)
        {
            seq = DOTween.Sequence();

            
            seq.Append(transform.DOMove(way3.transform.position, moveTime)).OnComplete(() => LookAtWorker(way2)).OnStart(() => LookAtWorker(way4))
            // TODO: OnComplete i�inde func de�i�tirilecek. Uygun tracking noktalar� eklendi�inde.
                .Append(transform.DOMove(way2.transform.position, moveTime)).OnComplete(() => LookAtWorker(way1))
                .Append(transform.DOMove(way1.position, moveTime).OnComplete(movingWorker));
            workTime--;
        }
    }

    void SleepWorker()
    {
        StartCoroutine(SleepWorkerNum());
    }

    IEnumerator SleepWorkerNum()
    {
        yield return new WaitForSeconds(2);
        workTime = workTimeTemp;
        RestartWorker();
    }

    void LookAtWorker(Transform look){
        lookTrans = look;
    }

    // void WorkerAnimationControl()
    // {

    //     if ((dynamicJoystick.Horizontal + dynamicJoystick.Vertical) != 0 && run)
    //     {
    //         if (boxesController.BoxesListLine > 0 && run)
    //         {
    //             animator.SetTrigger("TransportationTrigger");
    //         }
    //         else
    //         {
    //             animator.SetTrigger("runningTrigger");
    //         }
    //         run = false;
    //     }
    //     else if (dynamicJoystick.Horizontal + dynamicJoystick.Vertical == 0 && !run)
    //     {
    //         if (boxesController.BoxesListLine > 0)
    //         {
    //             animator.SetTrigger("transportationDontwalkTrigger");
    //         }
    //         else
    //         {
    //             animator.SetTrigger("idleTrigger");
    //         }
    //         run = true;
    //     }
    // }
}
