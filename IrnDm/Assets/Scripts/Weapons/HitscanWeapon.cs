using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanWeapon : AWeapon {

    public float Scattering;
    public int PelletAmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void LaunchProjectile()
    {
        for (int i = 0; i < PelletAmount; i++)
        {
            //Maybe override Instantiate with Raycasts
            InstantiateProjectile(Spread(GetAimVector()));
        }
    }

    private void CastRay(Vector3 direction) {
        Physics.Raycast(gameObject.transform.position, Spread(GetAimVector()));
    }

    private Vector3 Spread(Vector3 aim) {
        //Probably needs to be swapped out with a GaussianSpread

        aim.Normalize();
        Vector3 v3;
        do
        {
            v3 = UnityEngine.Random.insideUnitCircle;
        } while (v3 == aim ||v3 == -aim);
        v3 = Vector3.Cross(aim, v3);
        v3 *= UnityEngine.Random.Range(0f, Scattering);
        return aim + v3;
    }
}
