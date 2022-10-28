using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsCollection : MonoBehaviour, IDataPersistence
{
    

    //guns.Array.data[0]

    private int weaponsCollected;

    GameObject gun_0;
    GameObject gun_1;
    GameObject gun_2;
    GameObject gun_3;
    GameObject gun_4;


    private void Start()
    {
        GameEventManager.instance.onWeaponCollected += ShowGunInInventory;
        gun_0 = gameObject.transform.GetChild(0).gameObject; 
        gun_1 = gameObject.transform.GetChild(1).gameObject; 
        gun_2 = gameObject.transform.GetChild(2).gameObject; 
        gun_3 = gameObject.transform.GetChild(3).gameObject; 
        gun_4 = gameObject.transform.GetChild(4).gameObject;

            gun_0.GetComponent<Button>().interactable = false;
            gun_0.GetComponent<Image>().enabled = false;
            gun_1.GetComponent<Button>().interactable = false;
            gun_1.GetComponent<Image>().enabled = false;
            gun_2.GetComponent<Button>().interactable = false;
            gun_2.GetComponent<Image>().enabled = false;
            gun_3.GetComponent<Button>().interactable = false;
            gun_3.GetComponent<Image>().enabled = false;
            gun_4.GetComponent<Button>().interactable = false;
            gun_4.GetComponent<Image>().enabled = false;
        
        
    }

    private void OnDestroy() 
    {
        // unsubscribe from events
        GameEventManager.instance.onWeaponCollected -= ShowGunInInventory;
    }

    public void LoadData(GameData data)
    {
        this.weaponsCollected = data.weaponsCollected;
    }

    public void SaveData(ref GameData data) //已經被加入收藏就不能再加
    {
        //data.weaponsCollected = this.weaponsCollected;
    }

    

    public void ShowGunInInventory()
    {
        

        
        if (weaponsCollected == 1){
            gun_0.GetComponent<Button>().interactable = true;
            gun_0.GetComponent<Image>().enabled = true;


        }
        if (weaponsCollected == 2)
        {
            gun_0.GetComponent<Button>().interactable = true;
            gun_0.GetComponent<Image>().enabled = true;
            gun_1.GetComponent<Button>().interactable = true;
            gun_1.GetComponent<Image>().enabled = true;
        
        }
        if (weaponsCollected == 3)
        {
            gun_0.GetComponent<Button>().interactable = true;
            gun_0.GetComponent<Image>().enabled = true;
            gun_1.GetComponent<Button>().interactable = true;
            gun_1.GetComponent<Image>().enabled = true;
            gun_2.GetComponent<Button>().interactable = true;
            gun_2.GetComponent<Image>().enabled = true;

        }
        if (weaponsCollected == 4)
        {
            gun_0.GetComponent<Button>().interactable = true;
            gun_0.GetComponent<Image>().enabled = true;
            gun_1.GetComponent<Button>().interactable = true;
            gun_1.GetComponent<Image>().enabled = true;
            gun_2.GetComponent<Button>().interactable = true;
            gun_2.GetComponent<Image>().enabled = true;
            gun_3.GetComponent<Button>().interactable = true;
            gun_3.GetComponent<Image>().enabled = true;

        }
        if (weaponsCollected == 5)
        {
            gun_0.GetComponent<Button>().interactable = true;
            gun_0.GetComponent<Image>().enabled = true;
            gun_1.GetComponent<Button>().interactable = true;
            gun_1.GetComponent<Image>().enabled = true;
            gun_2.GetComponent<Button>().interactable = true;
            gun_2.GetComponent<Image>().enabled = true;
            gun_3.GetComponent<Button>().interactable = true;
            gun_3.GetComponent<Image>().enabled = true;
            gun_4.GetComponent<Button>().interactable = true;
            gun_4.GetComponent<Image>().enabled = true;

        }
        


    

    }



}
