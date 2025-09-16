using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    public float lifetime = 2f;

    private Vector2 moveDir;

    public void SetDirection(Vector2 dir)
    {
        moveDir = dir.normalized;
        Destroy(gameObject, lifetime);
    }
    private void Update()
    {
        transform.Translate(moveDir * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
