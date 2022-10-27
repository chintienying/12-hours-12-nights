using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsCollection : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;
    private int weaponPointsSum = 0;
    private SerializableDictionary<string,bool> weaponsCollected;
    private WeaponPointsText weaponPointsText;

    private bool collected = false;
    private Button button;
    private Image image;

    
    //private SpriteRenderer visual;




    // Start is called before the first frame update
    private void Awake()
    {
       
        button = this.GetComponent<Button>();
        image = this.GetComponent<Image>();
  
    }

    public void LoadData(GameData data)
    {
        data.weaponsCollected.TryGetValue(id, out collected);
        if(collected) // 已經被收集了
        {
           
            
            button.enabled = true;
        }
        //this.weaponsCollected = data.weaponsCollected;

        this.weaponPointsSum = data.weaponPointsSum; //load weaponPointsSum
        this.weaponsCollected = data.weaponsCollected;
        

    }

    public void SaveData(ref GameData data)
    {
       if(data.weaponsCollected.ContainsKey(id))
       {
            data.weaponsCollected.Remove(id); //已經被加入收藏就不能再加

       }
       data.weaponsCollected.Add(id, collected);
    }

    // Update is called once per frame
    void Start()
    {
        
        button.enabled = false;
        this.gameObject.SetActive(false);
        //Debug.Log(weaponPointsSum);
        WeaponFound();

    }

    private void WeaponFound()
    {

        if(!collected){

            if(weaponPointsSum >= 0 && weaponPointsSum < 8) //第一把
            {
                if(this.id == "0")
                {
                    AddToWeaponCollection();
                    UnityEngine.Debug.Log("0");
                }

            } 

            if(weaponPointsSum >= 8 && weaponPointsSum < 16) //第二把
            {
                if(this.id == "1")
                {
                    AddToWeaponCollection();
                    UnityEngine.Debug.Log("1");
                }
            }
            if(weaponPointsSum >= 16 && weaponPointsSum < 24) //第三把
            {  
                if(this.id == "2")
                {
                    AddToWeaponCollection();
                    UnityEngine.Debug.Log("2");
                }

            }
            if(weaponPointsSum >= 24 && weaponPointsSum < 32) //第四把
            {  
                if(this.id == "3")
                {
                    AddToWeaponCollection();
                     UnityEngine.Debug.Log("3");
                }

            }
            if(weaponPointsSum >= 32) //第五把
            {
                if(this.id == "4")
                {
                    AddToWeaponCollection();
                     UnityEngine.Debug.Log("4");
                }

            }
            
        }
        

    }
    private void AddToWeaponCollection()
    {
        collected = true;
        this.gameObject.SetActive(true);
        button.enabled = true;
        GameEventManager.instance.WeaponCollected();


    }
}
