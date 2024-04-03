using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronSword : DummyItem
{
    
    // Start is called before the first frame update
   protected override void stats()
    {
        description = "+2 Atk, +1 Def";
        atk = 2;
        mag = 0;
        def = 1;
        res = 0;
        spd = 0;
        crit = 0;
        eva = 0;

    }


}
