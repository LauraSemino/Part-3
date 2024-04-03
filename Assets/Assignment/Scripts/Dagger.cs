using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Dagger : DummyItem
{
    // Start is called before the first frame update
    protected override void stats()
    {
        description = "+1 Atk, +1 Spd";
        atk = 1;
        mag = 0;
        def = 0;
        res = 0;
        spd = 1;
        crit = 0;
        eva = 0;

    }
}
