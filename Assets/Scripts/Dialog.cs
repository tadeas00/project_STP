using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dialog : Collidable
{
    public string DialogText;
    private float cooldown = 4.0f;
    private float lastTalk;

    protected override void Start()
    {
        base.Start();
        lastTalk = -cooldown;
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (Time.time - lastTalk > cooldown)
        {
            lastTalk = Time.time;
            GameManager.instance.ShowText(DialogText, 25, Color.yellow, transform.position + new Vector3(0,0.16f,0), Vector3.zero, cooldown); 
        }
    }
}
