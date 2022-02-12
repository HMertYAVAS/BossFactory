using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BantController : MonoBehaviour
{
    public TakeOffAreaController takeOffAreaController;
    public List<GameObject> boxesList;

    public bool canWork
    {
        get
        {
            return takeOffAreaController.takeOffAreaBoxesLine >= 0;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(takeOffAreaController.takeOffAreaBoxesLine);
            SetDeActiveTakeOffAreaBoxes();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SetActiveBoxes();
        }
    }
    public void SetActiveBoxes()
    {
        if (canWork)
        {
            boxesList[takeOffAreaController.takeOffAreaBoxesLine].gameObject.SetActive(true);
            
        }
    }
    public void SetDeActiveTakeOffAreaBoxes()
    {
        if (canWork)
        {
            takeOffAreaController.takeOffAreaBoxesLine--;
            takeOffAreaController.takeOffAreaBoxesList[takeOffAreaController.takeOffAreaBoxesLine].SetActive(false);
        }
    }
}
