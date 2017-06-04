using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWeapon : MonoBehaviour {

    public int Ammo;
    public bool Infinite;
    public float CoolDown;

    public AProjectile Projectile;
    public AudioClip FireSound;
    public AudioClip ReloadSound;
    public AudioClip EmptySound;
    public AudioClip NotCooledDown;
    public AudioClip EquipSound;

    private bool isEquiped = false;
    private bool isReloading = false;

    private AudioSource WeaponAudioSource;

    // Use this for initialization
    void Start() {
        WeaponAudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void Fire() {
        if (isEquiped)
        {
            if (!IsEmpty())
            {
                if (!isReloading)
                {
                    StartCoroutine(FireProjectile());
                }
                else
                {
                    WeaponAudioSource.PlayOneShot(NotCooledDown);
                }
            }
            else
            {
                WeaponAudioSource.PlayOneShot(EmptySound);
            }
        }
    }

    IEnumerator FireProjectile()
    {
        WeaponAudioSource.PlayOneShot(FireSound);
        LaunchProjectile();
        Ammo--;
        WeaponAudioSource.PlayOneShot(ReloadSound);
        isReloading = true;
        yield return new WaitForSeconds(CoolDown);
        isReloading = false;
    }

    protected virtual void LaunchProjectile() {
        InstantiateProjectile(GetAimVector());
    }

    protected void InstantiateProjectile(Vector3 direction) {
        Instantiate(Projectile,direction, Quaternion.identity);
    }

    protected Vector3 GetAimVector()
    {
        //Swap with getting 
        return gameObject.transform.position;
    }

    public void Equip() {
        WeaponAudioSource.PlayOneShot(EquipSound);
        isEquiped = true;
    }

    public bool UnEquip() {
        if (!isReloading)
        {
            return true;
        }
        return false;
    }

    public bool IsEmpty()
    {
        return Ammo > 0 || Infinite;
    }


}
