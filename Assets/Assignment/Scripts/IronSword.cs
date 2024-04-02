using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronSword : DummyItem
{
    
    // Start is called before the first frame update
   protected override void stats()
    {
        description = "+2 Atk, +1 Def";
        atk = 12;
        mag = 10;
        def = 11;
        res = 10;
        spd = 10;
        crit = 10;
        eva = 10;

    }


}
