using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBandController : MonoBehaviour
{
    public List<GameObject> myBoxesList;
    public int myBoxesListLine;
    void Start()
    {
        myBoxesListLine = -1;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FrontBandBoxe"))
        {
            SetActiveBackBoxes();
        }
    }
    public void SetActiveBackBoxes()
    {
        if (myBoxesListLine < myBoxesList.Count - 1)
        {
            myBoxesListLine++;
        }
        else
        {
            myBoxesListLine = 0;
        }
        myBoxesList[myBoxesListLine].transform.gameObject.SetActive(true);
    }
}
