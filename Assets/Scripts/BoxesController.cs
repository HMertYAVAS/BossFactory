using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For Player Or Worker 
public class BoxesController : MonoBehaviour
{
    public List<GameObject> BoxesList;
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
        BoxesListLine = 0;
    }
    public Vector3 GetBoxesLinePosition()
    {
        if (canCollect)
        {
            position = BoxesList[BoxesListLine].transform.position;
        }
        return position;
    }
    public void SetActiveBoxesObject()
    {
        if (canCollect)
        {
            BoxesList[BoxesListLine].transform.gameObject.SetActive(true);
            BoxesListLine++;
        }
    }
}
