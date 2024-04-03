using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireRing : DummyItem
{
    public Image FireATK;
    public Color visible;
    public Color invisible;
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
    protected override void BecomeWeapon()
    {
        if (isSelected == true && Input.GetKeyDown(KeyCode.Z) && (cursor.selection != inventorySlot || cursor.menu != menuSlot) && cursor.OccupiedListCheck() == false)
        {
            isSelected = false;
            anySelected = false;
            inventorySlot = cursor.selection;
            menuSlot = cursor.menu;
            cursor.Occupied(this.pos);
            if (inventorySlot == 5 && menuSlot == 1)
            {

                cursor.isWeapon(this);
            }
            if (inventorySlot < 4 && menuSlot == 1)
            {
                cursor.isEquipped(this);
            }

        }

        if (inventorySlot == 5 && menuSlot == 1)
        {
            isEquipped = true;
            FireATK.color = visible;
            

        }
        else
        {
            FireATK.color = invisible;
        }

        
        
    }

}
