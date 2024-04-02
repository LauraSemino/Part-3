using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Cursor : MonoBehaviour
{
    // Start is called before the first frame update
    public float selection;
    public float cursormove;
    public float menu;
    public Vector2 pos;
    public InventoryManager inventory;
    public List<Vector2> occupiedslots;

    //stats
    public TextMeshProUGUI ItemDesc;
    public TextMeshProUGUI ItemATK;
    public TextMeshProUGUI ItemMAG;
    public TextMeshProUGUI ItemDEF;
    public TextMeshProUGUI ItemRES;
    public TextMeshProUGUI ItemSPD;
    public TextMeshProUGUI ItemCRIT;
    public TextMeshProUGUI ItemEVA;


    Rigidbody2D rb;
    SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        //up and down menu movement
        pos = transform.position;

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

       //add other items
       if (DummyItem.anySelected == true)
       {
            sr.color = Color.yellow;
       }
       else
        {
            sr.color = Color.white;
        }
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
        
        if(itempos.x == 0.65f && itempos.y == -1.25f)
        {
            ItemDesc.text = "10";
            ItemATK.text = "10";
            ItemMAG.text = "10";
            ItemDEF.text = "10";
            ItemRES.text = "10";
            ItemSPD.text = "10";
            ItemCRIT.text = "10";
            ItemEVA.text = "10";
            StartCoroutine(inventory.UnLoadDesc());
        }
        occupiedslots.Remove(itempos);
    }
    public void isEquipped(DummyItem item)
    {
        Debug.Log(item);
        //change description text
        
    }
    public void isWeapon(DummyItem item)
    {
        Debug.Log(item);
        ItemDesc.text = item.description;
        ItemATK.text = item.atk.ToString();
        ItemMAG.text = item.mag.ToString();
        ItemDEF.text = item.def.ToString();
        ItemRES.text = item.res.ToString();
        ItemSPD.text = item.spd.ToString();
        ItemCRIT.text = item.crit.ToString();
        ItemEVA.text = item.eva.ToString();
        


        StartCoroutine(inventory.LoadDesc());
    }

    public bool OccupiedListCheck()
    {
        for (int i = 0; i < occupiedslots.Count; i++)
        {
            Debug.Log(occupiedslots.Count);
            if(pos.x + 2 == occupiedslots[i].x && pos.y == occupiedslots[i].y)
            {
               return (true);

            }

        }
        
        return (false);
    }

}
