﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    //Damage struct
    public int[] damagePoint = { 1, 2, 3, 4, 5 ,6, 7};
    public float[] pushForce = {2.0f, 2.2f, 2.5f, 3f, 3.2f, 3.6f, 4f };

    //Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer _spriteRenderer;

    //Swing
    Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;

 

    protected override void Start()
    {
        base.Start();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }
    protected override void OnCollide(Collider2D collider)
    {
        if (collider.tag == "Fighter")
        {
            if (collider.name == "Player")
                return;

            //Create a new damage object, then we'll send it to the fighter we've hit
            Damage dmg = new Damage()
            {
                damageAmount = damagePoint[weaponLevel],
                origin = transform.position,
                pushForce = pushForce[weaponLevel]
            };

            collider.SendMessage("ReceiveDamage", dmg);

            Debug.Log(collider.name);

        }
    }
    private void Swing()
    {
        anim.SetTrigger("Swing");
    }
    public void UpgradeWeapon()
    {
        weaponLevel++;
        _spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];

        //Change stats
    }
    public void SetWeaponLevel(int level)
    {
        weaponLevel = level;
        _spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
}
