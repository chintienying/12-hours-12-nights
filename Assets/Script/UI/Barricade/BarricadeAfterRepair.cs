using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarricadeAfterRepair : MonoBehaviour,IDataPersistence
{
    private int barricadeAfterRepairPercentage;
    private TextMeshProUGUI repairAddUppText;
    private TextMeshProUGUI finalResultText;
    private int barricadeAfterDamagePercentage;
    private int barricadePoints;
   
    private BarricadePointsText barricadePointsText;
    private BarricadeAfterDamage barricadeAfterDamage;

    private int curr_percentage;
    private int addUpp;
    public GameObject repairAddUpp;
    public GameObject finalResult;






    // Start is called before the first frame update
    private void Awake() {
        //barricadeAfterRepairPercentageText = this.GetComponent<TextMeshProUGUI>();
        repairAddUpp = GameObject.Find("Canvas/Data/BarricadeRepairPercentage");
        finalResult = GameObject.Find("Canvas/Data/BarricadeResultPercantage");
        repairAddUppText = repairAddUpp.GetComponent<TextMeshProUGUI>();
        finalResultText = finalResult.GetComponent<TextMeshProUGUI>();


    }
    public void LoadData(GameData data)
    {
        this.barricadeAfterRepairPercentage = data.barricadeAfterRepair;
        this.barricadeAfterDamagePercentage = data.barricadeAfterDamage;
        this.barricadePoints = data.barricadePoints;
        


    }

    public void SaveData(ref GameData data)
    {
       data.barricadeAfterRepair = this.barricadeAfterRepairPercentage;

    }

    private void Start()
    {
        GameEventManager.instance.onBarricadeRepaired += OnBarricadeRepaired;
        StartCoroutine(ShowRepairStatus());
        System.Diagnostics.Debug.WriteLine(this.barricadeAfterDamagePercentage);

    }
    private void OnDestroy()
    {
        GameEventManager.instance.onBarricadeRepaired -= OnBarricadeRepaired;

    }

    // Update is called once per frame
    void Update()
    {
        GameEventManager.instance.RepairBarricade();
        //barricadeAfterRepairPercentageText.text = barricadeAfterRepairPercentage.ToString()+ "%";
        repairAddUppText.text = addUpp.ToString();
        finalResultText.text = barricadeAfterRepairPercentage.ToString()+ "%";
        
    }

    private IEnumerator ShowRepairStatus() 
    {
        // freeze player movemet

        // send off event that we died for other components in our system to pick up
        GameEventManager.instance.RepairBarricade();

        yield return new WaitForSeconds(1f);
    }

    private void OnBarricadeRepaired()
    {
        addUpp = barricadePoints * 5;
        curr_percentage = barricadeAfterDamagePercentage + (addUpp);
        barricadeAfterRepairPercentage = curr_percentage;
        if (barricadeAfterRepairPercentage >= 100)
        {
            barricadeAfterRepairPercentage = 100;
        }

    }
        
    
}
