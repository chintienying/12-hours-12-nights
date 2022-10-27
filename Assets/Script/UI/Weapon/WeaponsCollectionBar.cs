using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponsCollectionBar : MonoBehaviour, IDataPersistence
{
    private Slider slidr;
    public Image fill;
    private TextMeshProUGUI weaponCollectText;
    public GameObject slider;
    public GameObject WeaponsFound;
    private int weaponsCollected = 1;
    private int weaponPointsSum = 0;

    [SerializeField] private int weaponPointsToGo = 12;

    //public WeaponsCollection weaponsCollection;


    private void Awake()
    {
        WeaponsFound = GameObject.Find("Canvas/Data/WeaponsFound");
        slider = GameObject.Find("Canvas/slider");
        slidr = slider.GetComponent<Slider>();
        weaponCollectText = WeaponsFound.GetComponent<TextMeshProUGUI>();
        
    }

    public void LoadData(GameData data) 
    {
        this.weaponsCollected = data.weaponsCollected;
        this.weaponPointsSum = data.weaponPointsSum;
    }


    public void SaveData(ref GameData data)
    {
        data.weaponsCollected = this.weaponsCollected;
        data.weaponPointsSum = this.weaponPointsSum;
        
    }


    private void Start()
    {
        GameEventManager.instance.onWeaponCollected += CalculateWeaponFound;
    }

    private void OnDestroy() 
    {
        // unsubscribe from events
        GameEventManager.instance.onWeaponCollected -= CalculateWeaponFound;
    }

    public void CalculateWeaponFound()
    {  
        if(weaponPointsSum >= 0 && weaponPointsSum < 12) //第一把
        {
            weaponsCollected = 1;
        } 

        if(weaponPointsSum >= 12) // reach 12點的時候歸零，武器加一
        {   
            weaponsCollected ++;
            weaponPointsSum = 0;
        }
        
    }
    private void Update() 
    {
        slidr.maxValue = weaponPointsToGo;
        slidr.value = weaponPointsSum;
        weaponCollectText.text = weaponsCollected.ToString();

        
    }
}
