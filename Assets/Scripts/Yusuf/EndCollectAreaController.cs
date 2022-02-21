using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCollectAreaController : MonoBehaviour
{
    public List<GameObject> collectOfBoxesList;
    public int collectObjectListLine;
    public List<Vector3> collectOfBoxesListMainPosition;

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
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    AddBoxe();
        //}
        //Objeleri sýrayla almasý için sürekli aç kapa yapýyoruz
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        triggerObject = other.transform.gameObject;
        BoxesController = triggerObject.GetComponent<BoxesController>();
        if (triggerObject.CompareTag("Player") && canCollect || triggerObject.CompareTag("Worker") && canCollect)
        {
            collectObjectListLine--;
            collectOfBoxesList[collectObjectListLine].transform.DOMove(BoxesController.GetBoxesLinePosition(), 0.15f).OnComplete(() => CollectObject());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < collectOfBoxesList.Count; i++)
        {
            if (collectOfBoxesList[i].transform.gameObject.activeInHierarchy)
            {
                collectOfBoxesList[i].transform.position = collectOfBoxesListMainPosition[i];
            }
        }
    }
    void CollectObject()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        if (collectObjectListLine > -1)
        {
            collectOfBoxesList[collectObjectListLine].transform.gameObject.SetActive(false);
            collectOfBoxesList[collectObjectListLine].transform.position = collectOfBoxesListMainPosition[collectObjectListLine];
            BoxesController.SetActiveBoxesObject();
        }

    }
    public Vector3 GetActiveLinePosition()
    {
        return collectOfBoxesListMainPosition[collectObjectListLine];
    }
    public void AddBoxe()
    {
        if (canAddBoxe)
        {
            collectOfBoxesList[collectObjectListLine].transform.gameObject.SetActive(true);
            collectObjectListLine++;
        }
    }
}
