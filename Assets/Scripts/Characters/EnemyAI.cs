using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;
    private Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (player != null)
            return;
        Vector2 dir = (player.position - transform.position).normalized;
        transform.position += (Vector3)(dir * speed * Time.deltaTime);
    }
}
