using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : DummyItem
{
    // Start is called before the first frame update
    protected override void stats()
    {
        description = "No Effect";
        atk = 0;
        mag = 0;
        def = 0;
        res = 0;
        spd = 0;
        crit = 0;
        eva = 0;

    }
    protected override void BecomeWeapon()
    {
        if (isSelected == true && Input.GetKeyDown(KeyCode.Z) && (cursor.selection != inventorySlot || cursor.menu != menuSlot) && cursor.OccupiedListCheck() == false && unequippable() == true)
        {
            isSelected = false;
            anySelected = false;
            inventorySlot = cursor.selection;
            menuSlot = cursor.menu;
            cursor.Occupied(this.pos);
            cursor.isEquipped(this);

        }
    }
    public bool unequippable()
    {
        if (cursor.selection == 5 && cursor.menu == 1)
        {
            return false;
        }
        return true;
    }
}
