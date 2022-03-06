using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class EndCollectAreaController : MonoBehaviour
{
    public List<GameObject> collectOfBoxesList;
    public int collectObjectListLine;
    public List<Vector3> collectOfBoxesListMainPosition;

    SoundManager SoundManager;
    public bool canWorktoBand
    {
        get
        {
            return collectObjectListLine < collectOfBoxesList.Count - 1;
        }
    }
    public bool canCollect
    {
        get
        {
            return collectObjectListLine > 0 && BoxesController.BoxesListLine < BoxesController.BoxesList.Count && collectObjectListLine <= collectOfBoxesList.Count;
        }
    }
    public bool canAddBoxe
    {
        get
        {
            return collectObjectListLine < collectOfBoxesList.Count;
        }
    }

    GameObject triggerObject;
    BoxesController BoxesController;

    void Start()
    {
        SoundManager = GameObject.FindObjectOfType<SoundManager>();
        collectObjectListLine = 0;
        for (int i = 0; i < collectOfBoxesList.Count; i++)
        {
            collectOfBoxesListMainPosition.Add(collectOfBoxesList[i].transform.position);
            if (collectOfBoxesList[i].transform.gameObject.activeInHierarchy)
            {
                collectObjectListLine++;
            }
        }
    }
    private void Update()
    {
        //Objeleri s�rayla almas� i�in s�rekli a� kapa yap�yoruz
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        triggerObject = other.transform.gameObject;
        BoxesController = triggerObject.GetComponent<BoxesController>();
        if (triggerObject.CompareTag("Player") && canCollect || triggerObject.CompareTag("Worker") && canCollect || triggerObject.CompareTag("HaveProduct") && canCollect)
        {
            triggerObject.gameObject.tag = "HaveProduct";
            collectObjectListLine--;
            collectOfBoxesList[collectObjectListLine].transform.DOMove(BoxesController.GetBoxesLinePosition(), 0.15f).OnComplete(() => CollectObject());
        }
    }
    void CollectObject()
    {
        if (collectObjectListLine > -1)
        {
            SoundManager.PlayBoxesCollectSound();
            collectOfBoxesList[collectObjectListLine].transform.gameObject.SetActive(false);
            collectOfBoxesList[collectObjectListLine].transform.position = collectOfBoxesListMainPosition[collectObjectListLine];
            BoxesController.SetActiveProductObject();
        }
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    public void AddBoxe()
    {
        if (canAddBoxe)
        {
            collectOfBoxesList[collectObjectListLine].transform.gameObject.SetActive(true);
            collectObjectListLine++;
        }
    }
    public Vector3 GetActiveLinePosition()
    {
        return collectOfBoxesListMainPosition[collectObjectListLine];
    }
}
