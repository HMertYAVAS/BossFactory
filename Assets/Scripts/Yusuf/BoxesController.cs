using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For Player Or Worker 
public class BoxesController : MonoBehaviour
{
    public List<GameObject> BoxesList;
    public List<Vector3> BoxesListMainPosition;
    public int BoxesListLine;

    Vector3 position;

    public bool canCollect
    {
        get
        {
            return BoxesListLine < BoxesList.Count;
        }
    }

    private void Start()
    {
        BoxesListLine = -1;

        for (int i = 0; i < BoxesList.Count; i++)
        {
            BoxesListMainPosition.Add(BoxesList[i].transform.localPosition);
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
    public void SetActiveBoxesObject()
    {
        if (canCollect && BoxesListLine < BoxesList.Count - 1)
        {
            BoxesList[BoxesListLine].transform.gameObject.SetActive(true);
            BoxesListLine++;
        }
    }
    //býrakma bölgesinde býrakýlan kutularýn kapanmasýna yarýyor
    public void SetDeactivatedBoxesObject()
    {
        if (canCollect)
        {
            BoxesList[BoxesListLine].transform.gameObject.SetActive(false);
            if (BoxesListLine >= 0)
            {
                BoxesListLine--;
            }
        }
    }
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
