using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MarketStockItem: MonoBehaviour
{
    public int itemCode;
    public float cost;
    public string itemName;

    private void Start()
    {
        itemName = string.Join("", name.ToCharArray().Where(char.IsLetter));//extract only letters
    }
}
