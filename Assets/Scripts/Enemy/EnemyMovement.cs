using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    public EnemyScriptableObjects enemyData;

    Vector2 knockbackVelocity;
    float knockbackDuration;

    void Start()
    {
        player = Object.FindAnyObjectByType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (knockbackDuration > 0)
        {
            transform.position += (Vector3)knockbackVelocity * Time.deltaTime;
            knockbackDuration -= Time.deltaTime;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.MoveSpeed * Time.deltaTime);
        }
    }
            

    public void Knockback(Vector2 velocity, float duration)
    {
        if (knockbackDuration > 0) return;

        knockbackVelocity = velocity;
        knockbackDuration = duration;
    }
}
