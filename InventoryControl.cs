using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour
{
    public List<PlayerItem> playerInventory;
    public List<PlayerItem> playerObjects;
    
    public GameObject buttonTemplate;
    public GameObject objectTemplate;
    public GameObject shadowPlane;

    public GridLayoutGroup gridGroup;
    private GameObject currentObject;

    public List<Sprite> Icons { get; private set; }
    public List<PlayerItem> PlayerInventory
    {
        get
        {
            return playerInventory;
        }

        set
        {
            playerInventory = value;
        }
    }
    public List<PlayerItem> PlayerObjects
    {
        get
        {
            return playerObjects;
        }

        set
        {
            playerObjects = value;
        }
    }

    void Start()
    {
        LoadAll();
        PlayerInventory = new List<PlayerItem>();

        for (int i = 0; i < Icons.Count; i++)
        {
            PlayerItem newItem = new PlayerItem();
            newItem.iconSprite = Icons[i % Icons.Count()];

            PlayerInventory.Add(newItem);
        }

        playerInventory = playerInventory.OrderBy(x => x.iconSprite.name).ToList();
        GenInventory(PlayerInventory);

    }

    public void GenInventory(List<PlayerItem> items)
    {
        if (gridGroup != null && gridGroup.transform)
        {
            bool first = true;
            foreach (Transform child in gridGroup.transform)
            {
                if (!first)
                {
                    Destroy(child.gameObject);
                }
                else
                {
                    first = false;
                }
            }
        }
        if (items.Count < 5)
        {
            gridGroup.constraintCount = items.Count;
        }
        else
        {
            gridGroup.constraintCount = 5;
        }

        foreach (PlayerItem newItem in items)
        {
            GameObject lastButton = Instantiate(buttonTemplate) as GameObject;  //New button instantiated as a child of the parent
            lastButton.SetActive(true);

            lastButton.GetComponent<InventoryButton>().SetIcon(newItem.iconSprite); //Icon set up according to the directory of the Sprites
            lastButton.name = newItem.iconSprite.name;
            lastButton.transform.SetParent(buttonTemplate.transform.parent, false);
        }

    }

    

    public void LoadAll()
    {
        var path = "Sprites/";
        Icons = Resources.LoadAll<Sprite>(path).ToList();
        Debug.Log("Miralo");
    }

    public void FindModel(Button button)
    {
        if(currentObject != null)
        {
            Destroy(currentObject);
        }
        Debug.Log("Encuentra lista");

        string path = "Models/" + button.name; //name of the buttons generated in the list
        GameObject newObject = Resources.Load(path, typeof(GameObject)) as GameObject; //newObject Gameobject created with the same name as the button
        currentObject = Instantiate(newObject, transform.position, transform.rotation); //Instantiate newObject in a new Gameobject called "currentObject"
        currentObject.transform.SetParent(shadowPlane.transform, false); //Set parent of shadowPlane
        Debug.Log("PostNewObject");
    }

    public class PlayerItem
    {
        public Sprite iconSprite;
    }




}
