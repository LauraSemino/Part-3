using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    // Start is called before the first frame update
    public float selection;
    public float cursormove;
    public float menu;
    public InventoryManager inventory;
    public List<Vector2> occupiedslots;
    
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //up and down menu movement
        Vector2 pos = transform.position;

        if (Input.GetKeyDown(KeyCode.UpArrow) && selection != 0)
        {
            if (selection == 5 && menu == 1)
            {
                selection -= 2;
            }
            else
            {
                selection -= 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && (selection < 8 && menu == 0))
        {
            selection += 1;
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && (selection < 5 && menu == 1))
        {
            if (selection == 3)
            {
                selection += 2;
            }
            else
            {
                selection += 1;
            }
        }


        //switching between inventory and storage
        if (Input.GetKeyDown(KeyCode.RightArrow) && menu == 0)
        {
            selection = 0;
            menu = 1;
            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && menu == 1)
        {
            selection = 0;
            menu = 0;
        }
        if (menu == 0)
        {
            pos.x = -8.88f;
        }
        if (menu == 1)
        {
            pos.x = -1.35f;
        }
        
        pos.y = -selection + 3.75f; 
        transform.position = pos;

       
       
    }
    private void FixedUpdate()
    {
        
    }
    public void Occupied(Vector2 itempos)
    {
        Debug.Log(itempos);
        occupiedslots.Add(itempos);
    }
    public void UnOccupied (Vector2 itempos)
    {
        occupiedslots.Remove(itempos);
    }
    public void isEquipped(DummyItem item)
    {
        Debug.Log(item);
    }
    public void isWeapon(DummyItem item)
    {
        Debug.Log(item);
    }
}
