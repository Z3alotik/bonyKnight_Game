using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour{

    public static AudioClip hurtSound, coinSound, pickupSound, potionSound, scrollOpenSound, monster1Sound, swordSound, monster1DeathSound, jumpSound;
    static AudioSource audioSrc;


    void Start(){
        hurtSound = Resources.Load<AudioClip>("HurtSound");
        monster1Sound = Resources.Load<AudioClip>("Monster1Sound");
        scrollOpenSound = Resources.Load<AudioClip>("ScrollOpenSound");
        pickupSound = Resources.Load<AudioClip>("ItemPickupSound");
        potionSound = Resources.Load<AudioClip>("PotionSound");
        coinSound = Resources.Load<AudioClip>("CoinSound");
        swordSound = Resources.Load<AudioClip>("SwordSound");
        monster1DeathSound = Resources.Load<AudioClip>("Monster1DeathSound");
        jumpSound = Resources.Load<AudioClip>("JumpSound");

        audioSrc = GetComponent<AudioSource>();
    }


    void Update(){}
        public static void PlaySound(string clip) {
                     switch (clip) {
                     case "HurtSound":
                         audioSrc.PlayOneShot (hurtSound);
                         break;
                     }
                     switch (clip) {
                     case "Monster1Sound":
                         audioSrc.PlayOneShot (monster1Sound);
                         break;
                     }
                     switch (clip) {
                     case "ScrollOpenSound":
                          audioSrc.PlayOneShot (scrollOpenSound);
                          break;
                     }
                     switch (clip) {
                     case "PotionSound":
                           audioSrc.PlayOneShot (potionSound);
                           break;
                     }
                     switch (clip) {
                     case "ItemPickupSound":
                           audioSrc.PlayOneShot (pickupSound);
                           break;
                     }
                     switch (clip) {
                     case "CoinSound":
                           audioSrc.PlayOneShot (coinSound);
                           break;
                     }
                     switch (clip) {
                     case "SwordSound":
                           audioSrc.PlayOneShot (swordSound);
                           break;
                     }
                     switch (clip) {
                     case "Monster1DeathSoundSound":
                           audioSrc.PlayOneShot (monster1DeathSound);
                           break;
                     }
                     switch (clip) {
                     case "JumpSound":
                           audioSrc.PlayOneShot (jumpSound);
                           break;
                     }
    }
}
