using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For Player Or Worker 
public class BoxesController : MonoBehaviour
{
    public List<GameObject> BoxesList;
    public List<Vector3> BoxesListMainPosition;
    public List<GameObject> ProductList;
    public int BoxesListLine;

    Vector3 position;

    public bool canCollect
    {
        get
        {
            return BoxesListLine <= BoxesList.Count;
        }
    }

    private void Start()
    {
        for (int i = 0; i < BoxesList.Count; i++)
        {
            BoxesListMainPosition.Add(BoxesList[i].transform.localPosition);
        }
    }

    private void Update()
    {
        if (BoxesListLine == 0)
        {
            gameObject.tag = "Player";
        }
    }
    public Vector3 GetBoxesLinePosition()
    {
        if (canCollect)
        {
            if (BoxesListLine < 0)
            {
                BoxesListLine++;
            }
            position = BoxesList[BoxesListLine].transform.position;
        }
        return position;
    }
    #region MethodsForProductList
    public void SetActiveProductObject()
    {
        ProductList[BoxesListLine].transform.gameObject.SetActive(true);
        BoxesListLine++;
    }
    public void SetDeactivatedProductObject()
    {
        ProductList[BoxesListLine].transform.gameObject.SetActive(false);
        if (BoxesListLine > 0)
        {
            BoxesListLine--;
        }
        if (BoxesListLine == 0)
        {
            ProductList[BoxesListLine].transform.gameObject.SetActive(false);
            BoxesListLine = -1;
        }
    }
    #endregion
    #region MethodsForBoxesList
    public void SetActiveBoxesObject()
    {
        if (canCollect)
        {
            BoxesList[BoxesListLine].transform.gameObject.SetActive(true);
            BoxesListLine++;
        }
    }

    //býrakma bölgesinde býrakýlan kutularýn kapanmasýna yarýyor
    public void SetDeactivatedBoxesObject()
    {
        Debug.Log("çali");
        BoxesList[BoxesListLine].transform.gameObject.SetActive(false);
        BoxesListLine--;
    }
    #endregion
    public void ComeBackMainPosition()
    {
        for (int i = 0; i < BoxesList.Count; i++)
        {
            BoxesList[i].transform.localPosition = BoxesListMainPosition[i];
        }
    }

    public GameObject GetBoxesObject()
    {
        return BoxesList[BoxesListLine].transform.gameObject;
    }
}
