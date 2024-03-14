using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Thief : Villager
{
    public GameObject DaggerPrefab;
    public Transform spawnPoint;
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }

    protected override void Attack()
    {
        speed = 6;
        destination = transform.position;
        base.Attack();
        Invoke("spawnDagger", 0.2f);
        Invoke("spawnDagger", 0.4f);
        //did two so it kinda matches the animation :D
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void spawnDagger()
    {
        Instantiate(DaggerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
