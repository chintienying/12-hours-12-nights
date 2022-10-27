using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TotalPointsText : MonoBehaviour
{
    public TextMeshProUGUI points_total;
    
    [Range(0, 12)]
    public int pointsAmount_total;

    public GameObject minus_btn_b;
    public GameObject minus_btn_w;

    public GameObject plus_btn_b;
    public GameObject plus_btn_w;

    //private bool btnEnabled;




    // Start is called before the first frame update
    void Start()
    {

        pointsAmount_total = 12;
        points_total = GetComponent<TextMeshProUGUI>();






        
    }

    // Update is called once per frame
    void Update()
    {
        points_total.text = pointsAmount_total.ToString();
        Button pb = plus_btn_b.GetComponent<Button>();
        Button pw = plus_btn_w.GetComponent<Button>();
        Button mb = minus_btn_b.GetComponent<Button>();
        Button mw = minus_btn_w.GetComponent<Button>();




        if (pointsAmount_total <= 0)
        {
            pb.interactable = false;
            pw.interactable = false;




        } else if (pointsAmount_total >= 12)
        {
            mb.interactable = false;
            mw.interactable = false;

        }
        else
        {
            pb.interactable = true;
            pw.interactable = true;
            mb.interactable = true;
            mw.interactable = true;
        }
 
    }

    public void SubstractPoints()
    {

        pointsAmount_total += 1;

    }
    public void AddPoints()
    {
        pointsAmount_total -= 1;
    }



}
