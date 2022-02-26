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


    Sequence seq;



    bool playerInTrigger;

    //public int workerPrice;

    public Transform way1;
    public Transform way2;
    public Transform way3;
    public Transform way4;

    private void Start()
    {
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

    void movingWorker()
    {
        if (workTime > 1)
        {
            seq = DOTween.Sequence();

            seq.Append(transform.DOMove(way2.transform.position, moveTime).SetEase(Ease.OutCubic))
            // TODO: OnComplete içinde func değiştirilecek. Uygun tracking noktaları eklendiğinde.
                .Append(transform.DOMove(way3.transform.position, moveTime).SetEase(Ease.OutCubic))
                .Append(transform.DOMove(way4.position, moveTime).SetEase(Ease.OutCubic).OnComplete(SleepWorker));
            workTime--;
        }
        else
        {
            // TODO Burası uyku noktası
            //this.gameObject.SetActive(false);
            StartCoroutine(SleepWorkerNum());

        }
    }

    void RestartWorker()
    {
        if (workTime > 0)
        {
            seq = DOTween.Sequence();

            seq.Append(transform.DOMove(way3.transform.position, moveTime).SetEase(Ease.OutCubic))
            // TODO: OnComplete içinde func değiştirilecek. Uygun tracking noktaları eklendiğinde.
                .Append(transform.DOMove(way2.transform.position, moveTime).SetEase(Ease.OutCubic))
                .Append(transform.DOMove(way1.position, moveTime).SetEase(Ease.OutCubic).OnComplete(movingWorker));
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
}
