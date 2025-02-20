using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerak : MonoBehaviour
{
    public Transform PointA, PointB;
    public int speed;
    Vector2 targetpos;

    // Start is called before the first frame update
    void Start()
    {
        targetpos = PointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, PointA.position) < .1f) targetpos = PointB.position;
        if (Vector2.Distance(transform.position, PointB.position) < .1f) targetpos = PointA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.CompareTag("Player"))
        {
            Collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(PointA.position, PointB.position);
    }

}
