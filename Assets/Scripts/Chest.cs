using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int pesosAmount = 10;
    protected override void OnCollide(Collider2D coll)
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ShowText("+" + pesosAmount + " Pesos!", 25, Color.yellow, transform.position, Vector3.up * 50, 3.0f);
        }
    }
}
