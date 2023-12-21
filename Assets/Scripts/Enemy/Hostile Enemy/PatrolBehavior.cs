using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    public GameObject LeftPoint;
    public GameObject RightPoint;
    private Rigidbody2D rigidBody;
    private Transform currentPoint;
    public float speed;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        currentPoint = RightPoint.transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == RightPoint.transform) {
            rigidBody.velocity = new Vector2(speed, 0);
        } else {
            rigidBody.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == RightPoint.transform) {
            currentPoint = LeftPoint.transform;
            spriteRenderer.flipX = true;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == LeftPoint.transform) {
            currentPoint = RightPoint.transform;
            spriteRenderer.flipX = false;
        }
    }
}
