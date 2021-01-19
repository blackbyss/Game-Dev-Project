using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("Ability 1")]
    public Image abilityImage1;
    public bool ability1IsActive;
    public float cooldown1;
    bool isCooldown1 = false;
    public KeyCode ability1 = KeyCode.Alpha1;

    [Header("Ability 2")]
    public Image abilityImage2;
    public bool ability2IsActive;
    public float cooldown2;
    bool isCooldown2 = false;
    public KeyCode ability2 = KeyCode.Alpha2;

    [Header("Ability 3")]
    public Image abilityImage3;
    public bool ability3IsActive;
    public float cooldown3;
    bool isCooldown3 = false;
    public KeyCode ability3 = KeyCode.Alpha3;

    [Header("Ability 4")]
    public Image abilityImage4;
    public bool ability4IsActive;
    public float cooldown4;
    bool isCooldown4 = false;
    public KeyCode ability4 = KeyCode.Alpha4;

    // Start is called before the first frame update
    void Start()
    {
        if (ability1IsActive) abilityImage1.fillAmount = 0;
        if (ability2IsActive) abilityImage2.fillAmount = 0;
        if (ability3IsActive) abilityImage3.fillAmount = 0;
        if (ability4IsActive) abilityImage4.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
        Ability2();
        Ability3();
        Ability4();
    }

    void Ability1()
    {
        if(Input.GetKey(ability1) && isCooldown1 == false && ability1IsActive == true)
        {
            isCooldown1 = true;
            abilityImage1.fillAmount = 1;
        }

        if (isCooldown1)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if(abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown1 = false;
            }
        }
    }

    void Ability2()
    {
        if (Input.GetKey(ability2) && isCooldown2 == false && ability2IsActive == true)
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
        }

        if (isCooldown2)
        {
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }

    void Ability3()
    {
        if (Input.GetKey(ability3) && isCooldown3 == false && ability3IsActive == true)
        {
            isCooldown3 = true;
            abilityImage3.fillAmount = 1;
        }

        if (isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if (abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }

    void Ability4()
    {
        if (Input.GetKey(ability4) && isCooldown4 == false && ability4IsActive == true)
        {
            isCooldown4 = true;
            abilityImage4.fillAmount = 1;
        }

        if (isCooldown4)
        {
            abilityImage4.fillAmount -= 1 / cooldown4 * Time.deltaTime;

            if (abilityImage4.fillAmount <= 0)
            {
                abilityImage4.fillAmount = 0;
                isCooldown4 = false;
            }
        }
    }
}
