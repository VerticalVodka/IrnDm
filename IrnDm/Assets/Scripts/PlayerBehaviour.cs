﻿using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public AWeapon EquippedWeaponRight { get; private set; }
    public AWeapon EquippedWeaponLeft { get; private set; }
    private int WeaponCount = 0;

    public AWeapon DefaultWeapon;

	// Use this for initialization
	void Start () {
        EquippedWeaponRight = DefaultWeapon;
        EquippedWeaponRight.Equip();
        EquippedWeaponLeft = DefaultWeapon;
        EquippedWeaponLeft.Equip();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            //Fire left
            Debug.Log("Pressed left click.");

        if (Input.GetMouseButtonDown(1))
            //Fire right
            Debug.Log("Pressed right click.");
    }

    private void FireLeft() {
        EquippedWeaponLeft.Fire();
        if (EquippedWeaponLeft.IsEmpty())
        {
            while (!EquippedWeaponLeft.UnEquip())
            {

            }
            EquippedWeaponLeft = DefaultWeapon;
            EquippedWeaponLeft.Equip();
        }
    }
    private void FireRight() {
        EquippedWeaponRight.Fire();
        if (EquippedWeaponRight.IsEmpty())
        {
            while (!EquippedWeaponRight.UnEquip())
            {

            }
            EquippedWeaponRight = DefaultWeapon;
            EquippedWeaponRight.Equip();
        }
    }


    public void PickUpWeapon(AWeapon weapon)
    {
        while (!EquippedWeaponRight.UnEquip() & EquippedWeaponLeft.UnEquip()) {
            
        }
        EquippedWeaponLeft = Instantiate(weapon);
        EquippedWeaponRight = Instantiate(weapon);
        Destroy(weapon);
        EquippedWeaponLeft.Equip();
        EquippedWeaponRight.Equip();
    }
}
