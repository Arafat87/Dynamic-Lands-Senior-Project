using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CharacterStats : MonoBehaviour
{
    public static CharacterStats instance;

    [SerializeField] public TextMeshProUGUI health;
    [SerializeField] public TextMeshProUGUI dashText;
    [SerializeField] public TextMeshProUGUI iceText;
    [SerializeField] public TextMeshProUGUI fireText;
    [SerializeField] public TextMeshProUGUI damageText;
    [SerializeField] public TextMeshProUGUI lifedrainText;


    public int damage = 10;

    public int playerDamage = 25;
    public int damageIncrease = 2;

    public int maxHP = 100;
    public int maxHPIncrease = 5;


    public int Dash = 2;
    public int DashIncrease = 1;

    public int Fire = 0;
    public int FireIncrease = 1;

    public int Heal = 25;

    public int Ice = 0;
    public int IceIncrease = 1;


    public int LifeDrainDamage = 5;
    public int LifeDrain = 0;
    public int LifeDrainIncrease = 1;

    int tempHP = 0;
    int tempDMG = 0;
    int tempDash = 0;
    int tempFire = 0;
    int tempHeal = 0;
    int tempIce = 0;
    int tempLife = 0;
    public int currentHP;

    public HealthBar healthBar;



    private void Update()
    {
        
        health.text = currentHP.ToString() + "/" + maxHP.ToString();
        dashText.text = Dash.ToString();
        iceText.text = Ice.ToString();
        fireText.text = Fire.ToString(); ;
        damageText.text = playerDamage.ToString();
        lifedrainText.text = LifeDrain.ToString() + "%";
       


    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        playerDamage = data.playerDamage;
        maxHP = data.maxHP;
        Dash = data.Dash;
        Fire = data.Fire;
        Ice = data.Ice;
        LifeDrain = data.LifeDrain;
        currentHP = data.currentHP;
        Round.instance.round = data.round;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Buff"))
        {
            StatIncrease();

        }
    }

    private void Awake()
    {
        currentHP = maxHP;
        

        if (instance != null)
        {
            return;
        }
        instance = this;
       
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
    }


    public void StatIncrease()
    {

        if (Inventory.instance.HPCount != tempHP)
        {
            maxHP = maxHP + maxHPIncrease;
            tempHP = tempHP + 1;
        }
        else if (Inventory.instance.DamageCount != tempDMG)
        {
            playerDamage = playerDamage + damageIncrease;
            tempDMG++;
        }
        else if (Inventory.instance.DashCount != tempDash)
        {
            Dash = Dash + DashIncrease;
            tempDash++;
        }
        else if (Inventory.instance.FireCount != tempFire)
        {
            if (Inventory.instance.FireCount == 1)
            {
                Fire = Fire + 5;
                tempFire++;
            }
            else
            {
                Fire = Fire + FireIncrease;
                tempFire++;
            }
        }
        else if (Inventory.instance.IceCount != tempIce)
        {
            Ice = Ice + IceIncrease;
            tempIce++;
        }
        else if (Inventory.instance.LifeDrainCount != tempLife)
        {
            LifeDrain = LifeDrain + LifeDrainIncrease;
            tempLife++;

        }
        else if (Inventory.instance.HealCount != tempHeal)
        {
            currentHP = currentHP + Heal;
            if(currentHP > maxHP)
            {
                currentHP = maxHP;
            }
            tempHeal++;
        }

        
    }
    


    public virtual void Die()
    {
        Debug.Log("dead");
    }


}

