using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    [Header("Combat")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f; // Bullets per second
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Ensure no gravity affects the player
    }
    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        StartCoroutine(Shoot());
    }
    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);

    }
    public IEnumerator Shoot()
    {
        while (Input.GetKeyDown(KeyCode.Space))
        {
            if (bulletPrefab != null && firePoint != null)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position).normalized;
                bullet.GetComponent<Bullet>().SetDirection(dir);
            }
            yield return new WaitForSeconds(fireRate);
        }

    }
}
