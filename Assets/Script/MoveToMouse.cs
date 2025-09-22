using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;
    private Camera mainCam;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        mainCam = Camera.main;                 
        target = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();           
    }

    void Update()
    {
        // --- Gerak pakai mouse ---
        if (Input.GetMouseButtonDown(0))       
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = mainCam.WorldToScreenPoint(transform.position).z;
            target = mainCam.ScreenToWorldPoint(mousePos);

            // Rotasi menghadap target
            Vector3 dir = target - transform.position;
            float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (rotZ < 0) rotZ += 360f;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
            target.z = transform.position.z;   
            
            if (target.x < transform.position.x)
                spriteRenderer.flipY = true;
            else
                spriteRenderer.flipY = false;
        }

        // --- Gerak pakai WASD ---
        float moveX = Input.GetAxisRaw("Horizontal"); // A (-1) / D (+1)
        float moveY = Input.GetAxisRaw("Vertical");   // S (-1) / W (+1)
        Vector3 moveDir = new Vector3(moveX, moveY, 0).normalized;

        if (moveDir != Vector3.zero)
        {
            transform.position += moveDir * speed * Time.deltaTime;

            // Rotasi sesuai arah gerak
            float rotZ = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
            if (rotZ < 0) rotZ += 360f;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);

            // Flip sprite
            if (moveDir.x < 0)
                spriteRenderer.flipY = true;
            else
                spriteRenderer.flipY = false;
        }
        else
        {
            // Kalau lagi ga pakai WASD, tetap ikutin target mouse
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
}
