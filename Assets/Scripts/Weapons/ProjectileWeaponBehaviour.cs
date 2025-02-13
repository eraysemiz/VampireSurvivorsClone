using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    
    protected Vector3 direction;
    public float destroyAfterSeconds;

    public float currentDamage;
    public float currentSpeed;
    public float currentCooldownDuration;
    public int currentDurability;

    public float Damage;
    public float Speed;
    public float CooldownDuration;
    public int Durability;
    void Awake()
    {
        Damage = weaponData.Damage;
        Speed = weaponData.Speed;
        CooldownDuration = weaponData.CooldownDuration;
        Durability = weaponData.Durability;
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentDurability = weaponData.Durability;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (dirx < 0 && diry == 0) //left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry < 0) //down
        {
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry > 0) //up
        {
            scale.x = scale.x * -1;
        }
        else if (dirx > 0 && diry > 0) //right up
        {
            rotation.z = 0f;
        }
        else if (dirx > 0 && diry < 0) //right down
        {
            rotation.z = -90f;
        }
        else if (dirx < 0 && diry > 0) //left up
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -90f;
        }
        else if (dirx < 0 && diry < 0) //left down
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }


        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") || col.CompareTag("MiniBoss") || col.CompareTag("FinalBoss"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage, transform.position);
            HandleDurability();
        }
        else if (col.CompareTag("Prop"))
        {
            BreakableProps prop = col.GetComponent<BreakableProps>();
            prop.TakeDamage(currentDamage);
            HandleDurability();
        }
    }

    void HandleDurability()
    {
        currentDurability--;
        if (currentDurability <= 0)
        {
            Destroy(gameObject);
        }
    }

}
