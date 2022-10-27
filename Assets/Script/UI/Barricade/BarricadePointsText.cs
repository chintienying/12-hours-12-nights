using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarricadePointsText : MonoBehaviour, IDataPersistence
{
    public int barricadePoints = 0;

    private TextMeshProUGUI barricadePointsText; 


    public GameObject button_b_m;
    public GameObject button_b_p;

    private void Awake() 
    {
        barricadePointsText = this.GetComponent<TextMeshProUGUI>();
        //Button btn_m = btn_m.GetComponent<Button>();
        //Button btn_p = btn_p.GetComponent<Button>();

    }

    public void LoadData(GameData data)
    {
        barricadePoints = data.barricadePoints;

    }

    public void SaveData(ref GameData data)
    {
       data.barricadePoints = barricadePoints;
    }

    // Start is called before the first frame update
    private void Start()
    {

        GameEventManager.instance.onInvestBarricadePoints += SubstractBarricadePoints;
        GameEventManager.instance.onInvestBarricadePoints += AddBarricadePoints;

    }
    private void OnDestroy()
    {
       GameEventManager.instance.onInvestBarricadePoints -= SubstractBarricadePoints;
        GameEventManager.instance.onInvestBarricadePoints -= AddBarricadePoints;

    }

    // Update is called once per frame
    void Update()
    {
        Button btn_m = button_b_m.GetComponent<Button>();
        Button btn_p = button_b_p.GetComponent<Button>();

        if(barricadePoints <= 0)
        {
            btn_m.interactable = false;
        } 
        else if (barricadePoints >= 12)
        {
            btn_p.interactable = false;
    
        }else
        {
            btn_m.interactable = true;
            btn_p.interactable = true;

        }

        barricadePointsText.text = barricadePoints.ToString();
        
    }

    public void SubstractBarricadePoints()
    {
        barricadePoints -= 1;

    }
    public void AddBarricadePoints()
    {
        barricadePoints += 1;

       
    }
}
