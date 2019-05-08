using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public GameObject playerController, playerMenu, gameMenu, inventory, inventoryMenu, weapon;
    public Button[] inventorySlots;
    public Button weaponSlot, equipmentSlot;
    public Text amount;

    private bool inPlayerMenu, inGameMenu;

    // Use this for initialization
    void Start () {
        inPlayerMenu = false;
        inGameMenu = false;
        //inventorySlots = inventoryMenu.GetComponentsInChildren<Button>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I) && inGameMenu == false)
        {
            playerMenu.SetActive(!inPlayerMenu);
            inPlayerMenu = !inPlayerMenu;
            playerController.GetComponent<PlayerController>().inMenu = inPlayerMenu;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && inPlayerMenu == false)
        {
            gameMenu.SetActive(!inGameMenu);
            inGameMenu = !inGameMenu;
            playerController.GetComponent<PlayerController>().inMenu = inGameMenu;
        }

        if(weapon.transform.childCount > 0)
        {
            weaponSlot.transform.GetChild(0).GetComponent<Image>().sprite = weapon.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            weaponSlot.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            weaponSlot.transform.GetChild(0).GetComponent<Image>().sprite = null;
            weaponSlot.transform.GetChild(0).gameObject.SetActive(false);
        }
        int i = 0;
        foreach(Transform child in inventory.transform)
        {
            inventoryMenu.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = child.GetComponent<SpriteRenderer>().sprite;
            inventoryMenu.transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
            i++;
        }
        for(int j = 15; j >= i; j--)
        {
            inventoryMenu.transform.GetChild(j).GetChild(0).gameObject.SetActive(false);
        }
        amount.text = playerController.GetComponent<PlayerController>().coins.ToString();
	}

    public void InventoryButton(Button button)
    {
        if(inventory.transform.childCount > button.transform.GetSiblingIndex())
        {
            Transform selectedItem = inventory.transform.GetChild(button.transform.GetSiblingIndex());
            if (selectedItem.tag == "Weapon")
            {
                if (weapon.transform.childCount == 0)
                {
                    selectedItem.SetParent(weapon.transform);
                }
                else
                {
                    weapon.transform.GetChild(0).transform.SetParent(inventory.transform);
                    selectedItem.SetParent(weapon.transform);
                }
            }
        }
    }

    public void WeaponButton()
    {
        if(weapon.transform.childCount > 0)
        {
            weapon.transform.GetChild(0).transform.SetParent(inventory.transform);
        }
    }

    public void EquipmentButton()
    {

        Debug.Log("Pushed equipment button");
    }
}
