using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DummyItem : MonoBehaviour
{
    public float inventorySlot;
    public float menuSlot;
    public Cursor cursor;
    public bool isSelected;
    public static bool anySelected;
    protected Vector2 pos;
    
    public bool isEquipped = false;

    //stats
    public string description;
    public float atk;
    public float mag;
    public float def;
    public float res;
    public float spd;
    public float crit;
    public float eva;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //inventorySlot = 0;
        //menuSlot = 0;
        isSelected = false;
        
        pos = transform.position;
        cursor.Occupied(this.pos);

        stats();
        
    }

    // Update is called once per frame
    void Update()
    {

        //lets items be moved
        pos = transform.position;

        if (cursor.selection == inventorySlot && Input.GetKeyDown(KeyCode.Z) && cursor.menu == menuSlot)
        {
            isSelected = true;
            anySelected = true;
            cursor.UnOccupied(pos);
            
        }

        BecomeWeapon();



        if (isSelected == true)
        {
            pos.x = cursor.transform.position.x + 2;
            pos.y = cursor.transform.position.y;
            

        }

        
        
        
        if (isSelected == true && Input.GetKeyDown(KeyCode.X))
        {
            anySelected = false;
            isSelected = false;
            lastItemPosition();
            if(pos.x == 0.65f && pos.y == -1.25f)
            {
                cursor.isWeapon(this);
                cursor.Occupied(pos);
            }
            else
            {
                cursor.Occupied(pos);
            }
            

        }
        
        transform.position = pos;

        
    }
    protected void lastItemPosition()
    {
        //sends a item back to where you grabbed it from
        pos.y = -inventorySlot + 3.75f;
        if (menuSlot == 0)
        {
            pos.x = -6.88f;
        }
        if(menuSlot == 1)
        {
            pos.x = 0.65f;
        }
        
    }
    protected virtual void stats()
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

    protected virtual void BecomeWeapon()
    {

        if (isSelected == true && Input.GetKeyDown(KeyCode.Z) && (cursor.selection != inventorySlot || cursor.menu != menuSlot) && cursor.OccupiedListCheck() == false)
        {
            isSelected = false;
            anySelected = false;
            inventorySlot = cursor.selection;
            menuSlot = cursor.menu;
            cursor.Occupied(pos);
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

        }
    }
}
