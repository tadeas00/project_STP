using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
   private void FixedUpdate()
   {
      float x = Input.GetAxisRaw("Horizontal");
      float y = Input.GetAxisRaw("Vertical");
      float speed = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
      animator.SetFloat("Speed", speed);

      UpdateMotor(new Vector3(x, y, 0));
   }
}
