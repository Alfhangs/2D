using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    //Damage
    public int damage;
    public float pushForce;

    protected override void OnCollide(Collider2D collider)
    {
        if(collider.tag == "Fighter" && collider.name == "Player")
        {
            //Create a new damage object, before sending it o the player
            Damage dmg = new Damage()
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };
            collider.SendMessage("ReceiveDamage", dmg);
        }
    }
}
