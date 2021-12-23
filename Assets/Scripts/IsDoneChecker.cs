using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDoneChecker : MonoBehaviour
{
    public RoomController[] allSpawners;
    public GameObject levelCompletePortal;

    public void Start()
    {
        StartCoroutine(Checker());
    }
    public IEnumerator Checker()
    {
        yield return new WaitForSeconds(3f);
        allSpawners = FindObjectsOfType<RoomController>();
        while (true)
        {
            yield return new WaitForSeconds(3f);
            
            if (Check())
            {
                Instantiate(levelCompletePortal, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -1), Quaternion.identity);
                StopAllCoroutines();
            }
        }
        
    }
    public bool Check()
    {
        foreach (RoomController room in allSpawners)
        {
            if (!(room == null || room.isSeen)) { return false; }
        }
        return FindObjectsOfType<Enemy>().Length == 0;
    }
}
