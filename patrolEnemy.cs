using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolEnemy : MonoBehaviour
{
    public Transform PointA; // Titik di bawah
    public Transform PointB; // Titik di atas
    private Transform currentPoint; // Titik tujuan yang sedang dituju
    private Rigidbody2D rb; // Rigidbody untuk gerakan musuh
    public float speed = 2f; // Kecepatan gerakan musuh

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Ambil Rigidbody2D
        currentPoint = PointB; // Awalnya menuju ke titik atas (PointB)
    }

    // Update is called once per frame
    void Update()
    {
        // Hitung arah ke titik tujuan
        Vector2 direction = (currentPoint.position - transform.position).normalized;
        rb.velocity = new Vector2(0, direction.y * speed); // Hanya bergerak di sumbu Y

        // Periksa jika posisi sudah dekat dengan titik tujuan
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.1f)
        {
            // Tukar tujuan antara PointA dan PointB
            currentPoint = (currentPoint == PointB) ? PointA : PointB;
        }
    }
}
