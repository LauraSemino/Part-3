using System;
using System.Collections;
using System.Collections.Generic;
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
    

    // Start is called before the first frame update
    void Start()
    {
        inventorySlot = 0;
        menuSlot = 0;
        isSelected = false;
        cursorColor.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        if (cursor.selection == inventorySlot && Input.GetKeyDown(KeyCode.Z) && cursor.menu == menuSlot)
        {
            isSelected = true;
        }
        if (isSelected == true )
        {
            pos.x = cursor.transform.position.x + 2;
            pos.y = cursor.transform.position.y;
            cursorColor.color = Color.yellow;
            
        }
        if(isSelected == true && Input.GetKeyDown(KeyCode.Z) && (cursor.selection != inventorySlot || cursor.menu != menuSlot))
        {
           isSelected = false;
           inventorySlot = cursor.selection;
           menuSlot = cursor.menu;
        }
        if (isSelected == true && Input.GetKeyDown(KeyCode.X))
        {
            isSelected = false;
            lastItemPosition();
        }
        if (isSelected == false)
        {
            cursorColor.color = Color.white;
        }
       

        transform.position = pos;
    }
    void lastItemPosition()
    {
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
