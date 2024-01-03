using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Demage struktura
    public int[] damagePoint = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};
    public float[] pushForce = {2.0f, 2.2f, 2.5f, 2.8f, 3.0f, 3.2f, 3.6f, 3.8f, 4f, 4.2f, 4.5f, 4.8f, 5f, 5.2f, 5.6f};

    //Update struktura
    public int weaponLevel = 0;
    public SpriteRenderer spriteRenderer;
    
    //Swing
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;
    
    protected override void Start()
    {
        base.Start();
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
    
    private void Swing()
    {
        anim.SetTrigger("Swing");
    }
    
    
}
