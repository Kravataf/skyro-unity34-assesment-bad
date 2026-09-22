using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.4f;
    public int hp = 3;
    float hitCd;

    void Update()
    {
        var p = GameObject.Find("player");
        transform.position = Vector3.MoveTowards(transform.position, p.transform.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<player>())
        {
            if (Time.time < hitCd) return;
            hitCd = Time.time + 0.4f;
            gm.inst.HitPlayer(7);
        }

        if (other.gameObject.name.Contains("bullet")) // checkovat meno je stale zle ale wtv
        {
            hp -= 1;
            Destroy(other.gameObject);
            if (hp <= 0)
            {
                gm.inst.score += 1;
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<player>())
        {
            if (Time.time < hitCd) return;
            hitCd = Time.time + 0.55f;
            gm.inst.HitPlayer(3);
        }
    }
}
