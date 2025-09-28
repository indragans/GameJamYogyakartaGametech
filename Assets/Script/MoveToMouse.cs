using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;
    private Camera mainCam;
    private SpriteRenderer spriteRenderer;
    private bool moveByMouse = false;


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
            moveByMouse = true; // aktifin gerak mouse
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = mainCam.WorldToScreenPoint(transform.position).z;
            target = mainCam.ScreenToWorldPoint(mousePos);
            target.z = transform.position.z;
        }


        // --- Gerak pakai WASD ---
        float moveX = Input.GetAxisRaw("Horizontal"); // A (-1) / D (+1)
        float moveY = Input.GetAxisRaw("Vertical");   // S (-1) / W (+1)
        Vector3 moveDir = new Vector3(moveX, moveY, 0).normalized;
        if (moveDir != Vector3.zero)
        {
            moveByMouse = false; // override mouse movement kalau lagi pakai WASD
            transform.position += moveDir * speed * Time.deltaTime;

            float rotZ = 0f;

            // cek dominasi arah
            if (Mathf.Abs(moveDir.x) > Mathf.Abs(moveDir.y))
            {
                // Horizontal
                if (moveDir.x > 0)
                {
                    rotZ = 0f; // kanan
                    spriteRenderer.flipX = true;
                }
                else
                {
                    rotZ = 0f;    // kiri
                    spriteRenderer.flipX = false;
                }

            }
            else
            {
                // Vertikal
                if (moveDir.y > 0)
                    rotZ = -90f;  // atas
                else
                    rotZ = 90f;   // bawah

                spriteRenderer.flipX = false;
            }

            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
        else if (moveByMouse)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target) < 0.01f)
                moveByMouse = false;
        }
    }

}
