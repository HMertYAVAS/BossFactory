using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class CollectOfBoxesController : MonoBehaviour
{
    public List<GameObject> collectOfBoxesList;
    public int collectObjectListLine;
    public List<Vector3> collectOfBoxesListMainPosition;


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
        //Objeleri sýrayla almasý için sürekli aç kapa yapýyoruz
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        triggerObject = other.transform.gameObject;
        BoxesController = triggerObject.GetComponent<BoxesController>();
        if (triggerObject.CompareTag("Player") && canCollect || triggerObject.CompareTag("Worker") && canCollect || triggerObject.CompareTag("HaveBox") && canCollect)
        {
            other.gameObject.tag = "HaveBox";
            collectObjectListLine--;
            collectOfBoxesList[collectObjectListLine].transform.DOMove(BoxesController.GetBoxesLinePosition(), 0.15f).OnComplete(() => CollectObject());
        }
    }
    void CollectObject()
    {
        if (collectObjectListLine > -1)
        {
            collectOfBoxesList[collectObjectListLine].transform.gameObject.SetActive(false);
            collectOfBoxesList[collectObjectListLine].transform.position = collectOfBoxesListMainPosition[collectObjectListLine];
            BoxesController.SetActiveBoxesObject();
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
}
