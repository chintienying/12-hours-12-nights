using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fenceHealthText : MonoBehaviour
{
    public Fence fence;
    public int initialHealth = 100;
    private int currHealth;
    public TextMeshProUGUI text_;
    //public fence fence_;

    // Start is called before the first frame update
    void Start()
    {
        
        text_ = this.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        currHealth = fence.barricadeDamage;
        text_.text = "Barricade: " + currHealth.ToString();
        
        
    }
    
}
