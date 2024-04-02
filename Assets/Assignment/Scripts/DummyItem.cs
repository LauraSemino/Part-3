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
    protected Vector2 pos;
    public SpriteRenderer cursorColor;
    public bool isEquipped = false;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //inventorySlot = 0;
        //menuSlot = 0;
        isSelected = false;
        cursorColor.color = Color.white;
        pos = transform.position;
        cursor.Occupied(this.pos);
    }

    // Update is called once per frame
    void Update()
    {

        //lets items be moved
        pos = transform.position;

        if (cursor.selection == inventorySlot && Input.GetKeyDown(KeyCode.Z) && cursor.menu == menuSlot)
        {
            isSelected = true;
            cursor.UnOccupied(pos);
            
        }

        if (isSelected == true && Input.GetKeyDown(KeyCode.Z) && (cursor.selection != inventorySlot || cursor.menu != menuSlot) && cursor.OccupiedListCheck() == false)
        {
            isSelected = false;
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


        if (isSelected == true)
        {
            pos.x = cursor.transform.position.x + 2;
            pos.y = cursor.transform.position.y;
            cursorColor.color = Color.yellow;


        }

        
        
        
        if (isSelected == true && Input.GetKeyDown(KeyCode.X))
        {
            isSelected = false;
            lastItemPosition();
            if(pos.x == 0.65f && pos.y == -1.25f)
            {
                cursor.isWeapon(this);
            }
            cursor.Occupied(this.pos);
        }
        if (isSelected == false)
        {
            cursorColor.color = Color.white;
        }
        transform.position = pos;

        if (inventorySlot == 5 && menuSlot == 1)
        {
            isEquipped = true;
        }
    }
    void lastItemPosition()
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
    
}
