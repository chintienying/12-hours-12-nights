using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponPointsText : MonoBehaviour, IDataPersistence
{
    private int weaponPoints = 0;
    private int weaponPointsSum = 0;

    private TextMeshProUGUI weaponPointsText; 


    public GameObject button_w_m;
    public GameObject button_w_p;

    private void Awake() 
    {
        weaponPointsText = this.GetComponent<TextMeshProUGUI>();
        //Button btn_m = btn_m.GetComponent<Button>();
        //Button btn_p = btn_p.GetComponent<Button>();

    }

    public void LoadData(GameData data)
    {
        this.weaponPoints = data.weaponPoints;
        this.weaponPointsSum = data.weaponPointsSum;

    }

    public void SaveData(ref GameData data)
    {
       data.weaponPoints = this.weaponPoints;
       data.weaponPointsSum = this.weaponPointsSum;
    }
    // Start is called before the first frame update
    private void Start()
    {

        GameEventManager.instance.onInvestWeaponPoints += SubstractWeaponPoints;
        GameEventManager.instance.onInvestWeaponPoints += AddWeaponPoints;
        GameEventManager.instance.onInvestWeaponPoints += SumupWeaponPoints;

    }
    private void OnDestroy()
    {
        SumupWeaponPoints();
        GameEventManager.instance.onInvestWeaponPoints -= SubstractWeaponPoints;
        GameEventManager.instance.onInvestWeaponPoints -= AddWeaponPoints;
        GameEventManager.instance.onInvestWeaponPoints -= SumupWeaponPoints;

    }

    // Update is called once per frame
    void Update()
    {
        Button btn_m = button_w_m.GetComponent<Button>();
        Button btn_p = button_w_p.GetComponent<Button>();

        if(weaponPoints <= 0)
        {
            btn_m.interactable = false;
        } 
        else if (weaponPoints >= 12)
        {
            btn_p.interactable = false;
    
        }else
        {
            btn_m.interactable = true;
            btn_p.interactable = true;

        }

        weaponPointsText.text = weaponPoints.ToString();
        
    }

    public void SubstractWeaponPoints()
    {
        weaponPoints -= 1;

    }
    public void AddWeaponPoints()
    {
        weaponPoints += 1;
  
    }
    public void SumupWeaponPoints()
    {
        weaponPointsSum += weaponPoints;
  
    }
}
