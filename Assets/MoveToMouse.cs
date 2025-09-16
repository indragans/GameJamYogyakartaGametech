using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;
    private Camera mainCam;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        mainCam = Camera.main;                 // Ambil kamera utama
        target = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();           // Awalnya target = posisi sekarang
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))       // Klik kiri
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = mainCam.WorldToScreenPoint(transform.position).z;
            target = mainCam.ScreenToWorldPoint(mousePos);

            // Rotasi menghadap target
            Vector3 dir = target - transform.position;
            float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (rotZ < 0) rotZ += 360f;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
            target.z = transform.position.z;   // Tetap di plane yang sama
            
            if (target.x < transform.position.x)
                spriteRenderer.flipY = true;
            else
                spriteRenderer.flipY = false;
        }

        // Bergerak ke target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
