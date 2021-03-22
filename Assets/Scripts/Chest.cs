using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int pesetasAmount = 5;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ShowText("+" + pesetasAmount + " pesetas!", 25, Color.grey, transform.position, Vector3.up * 50, 1.5f);
            Debug.Log("Obtengo" + pesetasAmount + "pesetas");
        }
    }
}
