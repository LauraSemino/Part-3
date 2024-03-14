using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public TextMeshProUGUI PrintSelected;
    public static CharacterControl instance;
    public static Villager SelectedVillager { get; private set; }

    private void Start()
    {
        instance = this;
        PrintSelected = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {

        
    }
    public static void SetSelectedVillager(Villager villager)
    {
        if (SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        print(SelectedVillager);
        
        instance.PrintSelected.text = (villager.name);
    }

}
