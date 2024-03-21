using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    public TMPro.TextMeshProUGUI currentSelection;
    public TMP_Dropdown droplist;
    public static CharacterControl Instance;
    public static Villager SelectedVillager { get; private set; }
    public Villager Archer;
    public Villager Merchant;
    public Villager Thief;

    private void Start()
    {
        Instance = this;
    }
    public static void SetSelectedVillager(Villager villager)
    {
        Debug.Log(villager.ToString());
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        Instance.currentSelection.text = villager.ToString();
    }
    public void DropdownSelection(Int32 value)
    {
        Debug.Log(value);
        if(value == 0)
        {
            SetSelectedVillager(Archer);
        }
        if (value == 1)
        {
           SetSelectedVillager(Merchant);
        }
        if (value == 2)
        {
            SetSelectedVillager(Thief);
        }
    }

    //private void Update()
    //{
    //    if(SelectedVillager != null)
    //    {
    //        currentSelection.text = SelectedVillager.GetType().ToString();
    //    }
   // }
}
