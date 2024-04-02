using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Cursor cursor;
    public Transform descbox;
    public Vector2 pos;


    float speed = 0.1f;
    //public List<GameObject> 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       pos = descbox.position;
       
    }
    public IEnumerator LoadDesc()
    {
        //pull up the description tab
        
        while (pos.x > 5.6)
        {
            pos.x -= speed;
            descbox.transform.position = pos;
            yield return null;

        }

        
    }
    public IEnumerator UnLoadDesc()
    {
        
        while (pos.x < 13.1)
        {
            pos.x += speed;
            descbox.transform.position = pos;
            yield return null;

        }
       
    }
}
