using System.Collections;
using System.Collections.Generic;
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
            StartCoroutine(DisplayDialog());
        }
    }

    IEnumerator DisplayDialog()
    {
        Vector3 startingPosition = transform.position + new Vector3(0, 0.16f, 0);
        for (int i = 0; i < DialogText.Length; i++)
        {
            Vector3 newPosition = startingPosition + new Vector3(i * 0.08f, 0, 0); // Adjust the spacing between letters as needed
            GameManager.instance.ShowText(DialogText[i].ToString(), 25, Color.yellow, newPosition, Vector3.zero, cooldown); 
            yield return new WaitForSeconds(0.05f); // Adjust the speed of typing by changing the WaitForSeconds value
        }
    }
}