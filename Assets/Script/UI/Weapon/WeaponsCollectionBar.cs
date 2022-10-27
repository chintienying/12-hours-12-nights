using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponsCollectionBar : MonoBehaviour
{
    private Slider slidr;
    public Image fill;
    private TextMeshProUGUI weaponCollectText;
    public GameObject slider;
    public GameObject WeaponsFound;

    private int weaponsCollected = 1;
    [SerializeField] private int totalWeapons = 5;

    //public WeaponsCollection weaponsCollection;


    private void Awake()
    {
        WeaponsFound = GameObject.Find("Canvas/Data/WeaponsFound");
        slider = GameObject.Find("Canvas/slider");
        slidr = slider.GetComponent<Slider>();
        weaponCollectText = WeaponsFound.GetComponent<TextMeshProUGUI>();
        
    }


    private void Start()
    {
        GameEventManager.instance.onWeaponCollected += onWeaponCollected;
    }
    public void LoadData(GameData data) 
    {
        foreach(KeyValuePair<string, bool> pair in data.weaponsCollected) 
        {
            if (pair.Value) 
            {
                weaponsCollected++;
            }
        }
    }

    public void SaveData(GameData data)
    {
        // no data needs to be saved for this script
        
    }
    private void OnDestroy() 
    {
        // unsubscribe from events
        GameEventManager.instance.onWeaponCollected -= onWeaponCollected;
    }

    public void onWeaponCollected()
    {
        
        weaponsCollected++;
        
    }
    private void Update() 
    {
        slidr.maxValue = totalWeapons;
        slidr.value = weaponsCollected;
        weaponCollectText.text = weaponsCollected.ToString();

        
    }
}
