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

    public GameObject takeOffMarket;

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
        else
        {
            for (int i = 0; i < BoxesList.Count; i++)
            {
                if (BoxesList[i].transform.gameObject.activeInHierarchy)
                {
                    gameObject.tag = "HaveBox";
                }
                /*else if (ProductList[i].transform.gameObject.activeInHierarchy)
                {
                    gameObject.tag = "HaveProduct";
                }*/
            }
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
        if (canCollect)
        {
            ProductList[BoxesListLine].transform.gameObject.SetActive(true);
            BoxesListLine++;
        }
    }
    public void SetDeactivatedProductObject()
    {
        if (BoxesListLine >= 0)
        {
            BoxesListLine--;
        }
        ProductList[BoxesListLine].transform.gameObject.SetActive(false);

        //if (BoxesListLine == 0)
        //{
        //    ProductList[BoxesListLine].transform.gameObject.SetActive(false);
        //    BoxesListLine = -1;
        //}
        takeOffMarket.gameObject.GetComponent<BoxCollider>().enabled = false;
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
