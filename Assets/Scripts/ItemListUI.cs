using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemListUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textInfo;
    public List<(string, int)> listItems;

    // Start is called before the first frame update
    void Start()
    {
        listItems = new List<(string, int)>();
        PopulateList();
        UpdateUIPanelList();
    }

    private void PopulateList()
    {
        listItems.Add(("Soft Paper", 1));
        listItems.Add(("EggSandwiches", 1));
        listItems.Add(("Cafe", 1));
        listItems.Add(("WaterBottle", 1));
        /*listItems.Add(("Water Bottle", 1));
        listItems.Add(("Corn Friends", 1));
        listItems.Add(("Milk Chocolate", 1));
        listItems.Add(("Cafe", 1));
        listItems.Add(("EggSandwiches", 1));*/
    }

    public void UpdateUIPanelList()
    {
        string itemCombo = null;
        foreach (var item in listItems)
        {
            itemCombo += (item.Item1.ToString() + ":\t\t" + item.Item2.ToString() + "\n");
        }

        _textInfo.text = itemCombo;
    }
}
