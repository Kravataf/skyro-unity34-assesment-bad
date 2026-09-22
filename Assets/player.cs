using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float speed = 5.5f;
    public int hp = 37;
    public GameObject bullet;
    public float fireWait = 0.18f;
    float lastShot;
    Vector2 lastDir = new Vector2(1, 0);

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time > lastShot + fireWait)
            {
                lastShot = Time.time;
                shoot();
            }
        }

        if (InputSystem.actions["Move"].ReadValue<Vector2>() != Vector2.zero)
        {
            lastDir = InputSystem.actions["Move"].ReadValue<Vector2>().normalized;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = InputSystem.actions["Move"].ReadValue<Vector2>().normalized * speed;
    }

    void shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity)
        .GetComponent<Rigidbody2D>().linearVelocity = lastDir * 12f;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Enemy>()) hp -= 4;
    }
}
