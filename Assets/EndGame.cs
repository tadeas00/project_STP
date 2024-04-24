using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : Collidable
{
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            GameObject audioSourceObject = GameObject.Find("BackgroundMusic");
            if (audioSourceObject != null)
            {
                Destroy(audioSourceObject);
            }
            
            UnityEngine.SceneManagement.SceneManager.LoadScene("End");
        }
    }
}
