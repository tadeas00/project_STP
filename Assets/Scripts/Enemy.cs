using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Enemy : Mover
{
    public int xpValue = 1;

    //logic
    public float triggerLenght = 1;
    public float chaseLenght = 5;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;
    
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];
    
    private Animator enemyAnimator;

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
        
        enemyAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(Vector3.Distance(playerTransform.position, startingPosition) < chaseLenght)
        {
            if(Vector3.Distance(playerTransform.position, startingPosition) < triggerLenght)
            {
                enemyAnimator.SetBool("IsRunning", true);
            }
            else
            {
                enemyAnimator.SetBool("IsRunning", false);
            }

            if(!collidingWithPlayer)
            {
                UpdateMotor((playerTransform.position - transform.position).normalized);
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            enemyAnimator.SetBool("IsRunning", false);
        }
        
        //overlaps check
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if(hits[i].tag == "Fighter" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }

            hits[i] = null;
        }
    }
    public string jmenoNestvury;
    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.GrantXp(xpValue);
        if (jmenoNestvury == "Active")
        {
            Door openingDoor = FindObjectOfType<Door>();
            
            if (openingDoor != null)
            {
                openingDoor.OpenDoor();
            }
        }
        GameManager.instance.ShowText("+" + xpValue + " xp", 25, Color.magenta, playerTransform.position, Vector3.up * 60, 3.0f);
    }
}
