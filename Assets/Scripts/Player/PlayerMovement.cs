using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 direction;
    [HideInInspector]
    public Vector2 lastMovedVector;

    Rigidbody2D rigidbody;
    public CharacterScriptableObjects characterData;
    public PlayerStats playerData;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerData = Object.FindAnyObjectByType<PlayerStats>();
        lastMovedVector = new Vector2 (1, 0f); // bu olmazsa oyun baþladýðýnda eðer oyuncu hareket etmezse býçak hareketsiz kalýr
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Move();    
    }
    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        direction = new Vector2(moveX, moveY).normalized;

        if (direction.x !=  0 ) 
        { 
            lastHorizontalVector = direction.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f);
        }
        if (direction.y != 0 ) 
        { 
            lastVerticalVector = direction.y; 
            lastMovedVector = new Vector2 (0f, lastVerticalVector);
        }

        if (direction.x != 0 && direction.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);
        }
    }

    void Move()
    {
        rigidbody.linearVelocity = new Vector2(direction.x * playerData.currentMoveSpeed, direction.y * playerData.currentMoveSpeed);
    }
}
