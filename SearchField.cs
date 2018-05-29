using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class SearchField : MonoBehaviour
{

    public GameObject Menu;

    public InputField mainInputField;

    // Use this for initialization
    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;
        mainInputField.onValueChanged.AddListener(SubmitName);
    }

    public void SubmitName(string arg0)
    {
        var script = Menu.GetComponent<InventoryControl>();
        var listFiltered = script != null ? script.PlayerInventory : null;

        if (!string.IsNullOrEmpty(arg0) && listFiltered != null)
        {
            listFiltered = listFiltered.Where(x => x.iconSprite.name.ToLower().Contains(arg0.ToLower())).ToList();
        }

        if (script != null)
        {
            script.GenInventory(listFiltered);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
