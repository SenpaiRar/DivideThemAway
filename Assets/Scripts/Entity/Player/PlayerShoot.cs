using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    
    public List<WeaponObject> ListOfWeapons;
    public AudioSource Audiosrc;
    public AudioClip SwitchSound;
    public AudioClip NoSwitchSound;
    public WeaponObject CurrentWeaponObject{
        get{
            return ListOfWeapons[CurrentWeapon];
        }
    }
    public float WeaponSwitchCoolDown;
    int CurrentWeapon;
    float timeSinceLastShot; 
    float timeSinceLastSwitch;

    private void Start(){
        CurrentWeapon = 0;
        timeSinceLastShot = 100;
        timeSinceLastSwitch = 100;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && timeSinceLastShot >= ListOfWeapons[CurrentWeapon].CooldownTime)
        {
            Shoot();
        }
        SwitchWeapon();
        timeSinceLastShot += Time.deltaTime;
        timeSinceLastSwitch +=Time.deltaTime;
    }

    void SwitchWeapon(){
        if(Input.GetKeyUp(KeyCode.Q)){
            if(timeSinceLastSwitch > WeaponSwitchCoolDown){
                timeSinceLastSwitch = 0;
                Audiosrc.PlayOneShot(SwitchSound, AudioConstant.AudioScale);
                if(CurrentWeapon ==0){
                    CurrentWeapon = ListOfWeapons.Count-1;
                }
                else{
                    CurrentWeapon--;
                }
            }
            else{
                Audiosrc.PlayOneShot(NoSwitchSound, AudioConstant.AudioScale);
            }
        }
        if(Input.GetKeyUp(KeyCode.E)){
            if(timeSinceLastSwitch > WeaponSwitchCoolDown){
                timeSinceLastSwitch = 0;
                Audiosrc.PlayOneShot(SwitchSound, AudioConstant.AudioScale);
                if(CurrentWeapon + 1 == ListOfWeapons.Count){
                    CurrentWeapon = 0;
                }
                    else{
                    CurrentWeapon++;
                }
            }
            else{
                Audiosrc.PlayOneShot(NoSwitchSound, AudioConstant.AudioScale);
            }
        }
    }

    void Shoot()
    {
        Instantiate(ListOfWeapons[CurrentWeapon].BulletObject, transform.position, transform.rotation);
        Audiosrc.PlayOneShot(ListOfWeapons[CurrentWeapon].ShootSound, AudioConstant.AudioScale);
        timeSinceLastShot = 0;
    }
}
