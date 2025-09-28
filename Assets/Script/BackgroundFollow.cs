using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 0.5f; // kecilin kalau mau efek lambat

    void Update()
    {
        if (player != null)
        {
            Vector3 newPos = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }
    }
}
