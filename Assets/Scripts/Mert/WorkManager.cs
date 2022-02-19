using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkManager : MonoBehaviour
{
        #region instance Control
    static public WorkManager instance;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }
    #endregion

    public List<GameObject> colletBoxesList;
    public List<Vector3> colletBoxesListPosition;
    public List<GameObject> sentBoxesList;



    [Header("SpawnValues")]

    public int SpawnBoxesLimit;
    public int SpawnBoxesCount;

    public int takeOffBoxAreaCount;
    public int takeOffBoxAreaLimit;
}
