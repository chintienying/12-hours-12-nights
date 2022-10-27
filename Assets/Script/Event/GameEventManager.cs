using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }
        instance = this;

    
    }
    // 破壞護欄
    public event Action onBarricadeDamaged;
    public void DamageBarricade()
    {
        if (onBarricadeDamaged != null) 
        {
            onBarricadeDamaged();
        }
    }
    public void fenceHurt()
    {
        if (onBarricadeDamaged != null) 
        {
            onBarricadeDamaged();
        }
    }

    // 投資護欄

    public event Action onInvestBarricadePoints;
    public void SubstractBarricadePoints()
    {
        if (onInvestBarricadePoints != null) 
        {
            onInvestBarricadePoints();
        }
    }
    public void AddBarricadePoints()
    {
        if (onInvestBarricadePoints != null) 
        {
            onInvestBarricadePoints();
        }
    }

    // 投資武器
    public event Action onInvestWeaponPoints;
    public void SubstractWeaponPoints()
    {
        if (onInvestWeaponPoints != null) 
        {
            onInvestWeaponPoints();
        }
    }
    public void AddWeaponPoints()
    {
        if (onInvestWeaponPoints != null) 
        {
            onInvestWeaponPoints();
        }
    }
    public void SumupWeaponPoints()
    {
        if (onInvestWeaponPoints != null) 
        {
            onInvestWeaponPoints();
        }
    }

    
    // 修補護欄
    public event Action onBarricadeRepaired;
    public void RepairBarricade()
    {
        if (onBarricadeRepaired != null) 
        {
            onBarricadeRepaired();
        }
    }


    // 收集到武器
    public event Action onWeaponCollected;
    public void CalculateWeaponFound()
    {
        if (onWeaponCollected != null) 
        {
            onWeaponCollected();
        }
        
    }
      




}
