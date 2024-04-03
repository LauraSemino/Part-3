using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRing : DummyItem
{
    // Start is called before the first frame update
    protected override void stats()
    {
        description = "+4 Mag, -1 def, -1 spd. Allows casting of fire";
        atk = 0;
        mag = 4;
        def = -1;
        res = 0;
        spd = -1;
        crit = 0;
        eva = 0;

    }
}
