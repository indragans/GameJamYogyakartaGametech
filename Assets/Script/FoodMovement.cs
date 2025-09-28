using UnityEngine;

public class FoodMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 2f;
    public float changeDirTime = 2f;
    public float turnSpeed = 2f;

    private Vector2 direction;
    private Vector2 targetDirection;
    private float timer;

    private Rigidbody2D rb;

    [Header("Score Settings")]
    public int scoreValue = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PickRandomDirection();
        direction = targetDirection;
    }

    void Update()
    {
        // Smooth rotasi ke arah baru
        direction = Vector2.Lerp(direction, targetDirection, turnSpeed * Time.deltaTime).normalized;

        // Hitung waktu untuk ganti arah
        timer += Time.deltaTime;
        if (timer >= changeDirTime)
        {
            PickRandomDirection();
            timer = 0f;
        }
    }

    void FixedUpdate()
    {
        // Gerak lewat physics → bisa tabrak collider
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void PickRandomDirection()
    {
        targetDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
