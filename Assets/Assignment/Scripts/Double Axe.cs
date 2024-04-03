using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleAxe : DummyItem
{
    // Start is called before the first frame update
    protected override void stats()
    {
        description = "+4 Atk, -2 Res";
        atk = 4;
        mag = 0;
        def = 0;
        res = -2;
        spd = 0;
        crit = 0;
        eva = 0;

    }
}
