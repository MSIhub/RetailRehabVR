using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;

public class ItemRecognition : MonoBehaviour
{
    [SerializeField] private ItemListUI _itemListUI;
    [SerializeField] private TextMeshProUGUI _costUI;
    private float _costRemaining = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        var str = string.Join("", _costUI.text.ToCharArray().Where(Char.IsDigit));
        _costRemaining = float.Parse(str);
    }

    // Update is called once per frame
    void Update()
    {
        ShoppingCompletedChecker();
    }

    private void ShoppingCompletedChecker()
    {
        if (_itemListUI.listItems.Count != 0) return;
        _costUI.text = "Congratulations!";
        _itemListUI.GetComponent<TextMeshProUGUI>().fontSize = 8;
        _itemListUI.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
        _itemListUI.GetComponent<TextMeshProUGUI>().text = "Shopping Completed";
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.TryGetComponent<MarketStockItem>(out var item))
        {
            other.transform.parent = transform;
            for (var index = 0; index < _itemListUI.listItems.Count; index++)
            {
                var itemUI = _itemListUI.listItems[index];
                var valueTuple = itemUI;
                var cond = String.Compare(item.itemName, valueTuple.Item1, CultureInfo.CurrentCulture,
                    CompareOptions.IgnoreCase | CompareOptions.IgnoreSymbols) == 0;
                if (cond)
                {
                    //item in basket in in the list
                   // valueTuple.Item2 -= 1;
                    _itemListUI.listItems.Remove(valueTuple);
                    //at the moment only one number per item
                    _costRemaining -= item.cost; // decrease the overall cost remaining
                }

                _costUI.text = "Money left: € " + _costRemaining.ToString();

            }
            
        }
        
        _itemListUI.UpdateUIPanelList();

    }
}
