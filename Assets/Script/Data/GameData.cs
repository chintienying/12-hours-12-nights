using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public long lastUpdated;

    public int weaponPoints; //該局分配給武器的點數
    public int barricadePoints; // 該局分配給護欄的點數
    public int barricadeAfterRepair; // 修補過後的圍欄點數

    


    public int barricadeAfterDamage; // 破壞後的護欄點數 （barricadeInitial - barricadeDamage = barricadeAfterDamage）
    public int barricadeDamage; // 破壞護欄點數 
    public int weaponsCollected; // 槍槍收藏
    public int weaponPointsSum; //  每局累加的武器點數



    public GameData()
    {
        // Invest stage (scene C)
        // barricadeAfterDamage + barricadePoints * 5 = barricadeAfterRepair
        this.barricadePoints = 0; 
        this.weaponPoints = 0; // if weaponPoints在此次的投資>=8點，得到一把槍

        // Result Stage (scene D) , become next stage initial state
        this.barricadeAfterRepair = 0;

        // Shooting Stage (scene A)
        // each round zombies done damage to barricade
        // we saved the after damage data
        this.barricadeAfterDamage = 100; // scene C will appear
        this.barricadeDamage = 100;
        // 
        this.weaponsCollected = 1;
        this.weaponPointsSum = 0; // 每6分拿到一把槍，0,6,12,18,24


        // if weaponPoints = 6 -> get a gun (id 0~4) , gun sprite show, gun collection +1


    }




}
