using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMover : MonoBehaviour, IMoveable
{
    private Rigidbody2D rb2d;

    private void Start()
    {
        this.rb2d = this.GetComponent<Rigidbody2D>();
    }

    public void MoveForward(float speed)
    {
        this.rb2d.position += new Vector2(this.transform.up.x, this.transform.up.y) * speed * Time.deltaTime;
    }
}
