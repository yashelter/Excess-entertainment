using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barier : MonoBehaviour
{
    public int depth = 1;
    public SideController LD;
    public SideController LU;
    public SideController RD;
    public SideController RU;

    //public void Update()
    //{
    //    if (LD.ToxicIn)
    //    {
    //        RU.ClearToxics(LD.blackList);
    //    }
    //    if (RU.ToxicIn)
    //    {
    //        LD.ClearToxics(RU.blackList);
    //    }
    //    if (LU.ToxicIn)
    //    {
    //        RD.ClearToxics(LU.blackList);
    //    }
    //    if (RD.ToxicIn)
    //    {
    //        LU.ClearToxics(RD.blackList);
    //    }
    //}
}
