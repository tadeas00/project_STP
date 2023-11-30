using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   private BoxCollider2D boxCollider;
   private Vector3 moveDelta;
   private RaycastHit2D hit;
   public Animator animator;
   float x = 1f;
   float y = 0f;

   private void Start()
   {
      boxCollider = GetComponent<BoxCollider2D>();
   }

   private void FixedUpdate()
   {
      x = Input.GetAxisRaw("Horizontal");
      y = Input.GetAxisRaw("Vertical");
      float speed = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
      
      moveDelta = new Vector3(x, y, 0);
      animator.SetFloat("Speed", speed);
      
      // Prohození směru postavy, dle toho kam jde
      if (moveDelta.x > 0)
         transform.localScale = Vector3.one;
      else if (moveDelta.x < 0)
         transform.localScale = new Vector3(-1, 1, 1);
      
      hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Character", "Blocking"));
      if(hit.collider == null)
      {
         transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
      }

      hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x,0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Character", "Blocking"));
      if(hit.collider == null)
      {
         transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
      }

   }
}
