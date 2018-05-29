using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class InventoryButton : MonoBehaviour
{
    [SerializeField]
    private Image myIcon;

    //public GameObject hitCube;
    //private bool found;

    public void SetIcon(Sprite mySprite)
    {
        myIcon.sprite = mySprite;
    }

    /*void FindModel()
    {
        var lists = gameObject.GetComponent<InventoryControl>();
        Debug.Log("Encuentra lista");

        GameObject newObject = Resources.Load("Resources/Models") as GameObject;
        found = false;

        foreach (var part in lists.PlayerInventory
                                  .Where(x => x.iconSprite.name.Equals(newObject.name, StringComparison.InvariantCultureIgnoreCase)))
        Debug.Log("Encuentra nombre en objecto como en lista");
        {
            if (Input.GetMouseButtonDown(0)) // lists.gridGroup != null && lists.gridGroup.transform
            {
                Debug.Log("click");
                lists.gridGroup.name = newObject.name;
                var newPrefab = Instantiate(newObject, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                newPrefab.transform.parent = hitCube.transform;

            }
        }
    }*/

}
