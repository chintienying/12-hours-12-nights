using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponChoosing : MonoBehaviour
{

    public List<GameObject> WeaponsCollection = new List<GameObject>();



    public GameObject remove_main;
    public GameObject remove_backup;
    private bool main = false; //沒有狀態
    private bool backup = false; //沒有狀態




    



    // Start is called before the first frame update
    void Start()
    {

        remove_main = GameObject.Find("remove_main");
        remove_backup = GameObject.Find("remove_backup");

  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(remove_main.GetComponent<Image>().enabled == false)
        {
            main = false;
        }else
        {
            main = true;
        }
        if(remove_backup.GetComponent<Image>().enabled == false)
        {
            backup = false;
        }else
        {
            backup = true;
        }
  
    }

    public void ChooseWeapon()
    {
        if(main == false && backup == false)
        {
            foreach(GameObject gun in WeaponsCollection)
            {
                if(gun.GetComponent<Button>().enabled == true)
                {
                    AddToMain();   
                }
            }
        }
        if(main == false && backup == true)
        {
           foreach(GameObject gun in WeaponsCollection)
            {
                if(gun.GetComponent<Button>().enabled == true)
                {

                    AddToMain();
                }
            }
        }
        if(main == true && backup == false)
        {
            foreach(GameObject gun in WeaponsCollection)
            {
                if(gun.GetComponent<Button>().enabled == true)
                {
                    AddToBackup();
                }
            }
        }

    }


   public void AddToMain()
   {
        foreach(GameObject gun in WeaponsCollection)
        {
            if(gun)
            {
                gun.GetComponent<Image>().enabled = false;
                MainAdded();
            }
        }
   }
    public void AddToBackup()
   {
        foreach(GameObject gun in WeaponsCollection)
        {
            if(gun)
            {
                gun.GetComponent<Image>().enabled = false;
                BackupAdded();
            }
        }
   }


    public void MainAdded()
    {

        remove_main.GetComponent<Button>().enabled = true;
         remove_main.GetComponent<Image>().enabled = true;
        main = true;

    }

    public void BackupAdded()
    {
        remove_backup.GetComponent<Button>().enabled = true;
        remove_backup.GetComponent<Image>().enabled = true;
        backup = true;


    }
    public void RemoveMainWeapon()
    {
        remove_main.GetComponent<Button>().enabled = false;
         remove_main.GetComponent<Image>().enabled = false;
        main = false;


    }
    public void RemoveBackupWeapon()
    {
        remove_backup.GetComponent<Button>().enabled = false;
         remove_backup.GetComponent<Image>().enabled = true;
        backup = false;

    }


    
}
