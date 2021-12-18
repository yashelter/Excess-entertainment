using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideController : MonoBehaviour
{

    public bool ToxicIn = false;
    public List<ToxicZoneCore> blackList;
    public List<ToxicZoneTile> tilesList;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("ToxicGenerator"))
        {
            ToxicIn = true;
            blackList.Add(collision.GetComponent<ToxicZoneCore>());
        }
        if (collision.CompareTag("ToxicZoneTile"))
        {
            tilesList.Add(collision.GetComponent<ToxicZoneTile>());
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ToxicGenerator"))
        {
            blackList.Remove(collision.GetComponent<ToxicZoneCore>());
            ToxicIn = false;
        }
        if (collision.CompareTag("ToxicZoneTile"))
        {
            tilesList.Remove(collision.GetComponent<ToxicZoneTile>());
        }
    }
    public void ClearToxics(List<ToxicZoneCore> lst)
    {
        for (int i = 0; i < lst.Count; i++)
        {
            for (int j = 0; j < tilesList.Count; j++)
            {
                if (tilesList[j].parent == lst[i].gameObject)
                {
                    Destroy(tilesList[j].gameObject);
                    j--;
                }
                
            }

        
        }
        
    }
}
