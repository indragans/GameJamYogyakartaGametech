using UnityEngine;

public class FoodMovement : MonoBehaviour
{
    public float speed = 2f;          // kecepatan gerak
    public float changeDirTime = 2f;  // berapa detik sekali ganti arah
    public float turnSpeed = 2f;      // kecepatan belok (semakin besar makin cepat ganti arah)

    private Vector2 direction;        // arah gerak sekarang
    private Vector2 targetDirection;  // arah tujuan
    private float timer;

    void Start()
    {
        PickRandomDirection();
        direction = targetDirection; // biar awalnya langsung ada arah
    }

    void Update()
    {
        // Smooth rotasi ke arah baru
        direction = Vector2.Lerp(direction, targetDirection, turnSpeed * Time.deltaTime).normalized;

        // Gerak ke arah sekarang
        transform.Translate(direction * speed * Time.deltaTime);

        // Hitung waktu untuk ganti arah
        timer += Time.deltaTime;
        if (timer >= changeDirTime)
        {
            PickRandomDirection();
            timer = 0f;
        }
    }

    void PickRandomDirection()
    {
        // Pilih arah random
        targetDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
