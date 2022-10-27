using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarricadeAfterDamage : MonoBehaviour,  IDataPersistence
{
    public int barricadeAfterDamagePercentage = 100;

    //private BarricadeDamage barricadeDamage;
    private TextMeshProUGUI barricadeAfterDamagePercentageText;


    private Fence fence;
    private int barricadeDamage;

    
    //private IEnumerator coroutine;



    // Start is called before the first frame update
    private void Awake() {
        barricadeAfterDamagePercentageText = this.GetComponent<TextMeshProUGUI>();
        fence = gameObject.GetComponent<Fence>();



        
    }
    public void LoadData(GameData data)
    {
        this.barricadeAfterDamagePercentage = data.barricadeAfterDamage;
        barricadeDamage = data.barricadeDamage; //把上一局的barricadeDamage load進來


    }

    public void SaveData(ref GameData data)
    {
       data.barricadeAfterDamage = this.barricadeAfterDamagePercentage;
    }

    private void Start()
    {
        GameEventManager.instance.onBarricadeDamaged += OnBarricadeDamaged;
        StartCoroutine(ShowDamageStatus());

        

        
    }
    private void OnDestroy()
    {
        GameEventManager.instance.onBarricadeDamaged -= OnBarricadeDamaged;
    }
    
        
    

    // Update is called once per frame
    void Update()
    {

        barricadeAfterDamagePercentageText.text = barricadeAfterDamagePercentage.ToString()+"%";  
    }
    private IEnumerator ShowDamageStatus() 
    {
        // freeze player movemet

        // send off event that we died for other components in our system to pick up
        GameEventManager.instance.DamageBarricade();

        yield return new WaitForSeconds(1f);
        
    }
    
    private void OnBarricadeDamaged()
    {
        barricadeAfterDamagePercentage = barricadeDamage;

    }

}
