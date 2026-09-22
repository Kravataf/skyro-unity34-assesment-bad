using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class gm : MonoBehaviour
{
    public static gm inst;

    public GameObject enemy, p;
    public float spawnDelay = 1.5f;
    public int score = 0, wave = 1;
    public player player;
    public bool paused;
    public Text txtHP, txtScore;
    public HudStuff hud;

    void Awake()
    {
        inst = this;
    }

    void Start()
    {
        p    = GameObject.Find("player");
        player  = FindFirstObjectByType<player>();
        hud  = FindFirstObjectByType<HudStuff>();

        StartCoroutine(Spawner());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
            Time.timeScale = paused ? 0f : 1f;
        }

        if (player.hp <= 0) Time.timeScale = 0.2f;
    }

    public void SpawnEnemy()
    {
        Vector3 pos = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), 0);
        if (Vector3.Distance(pos, p.transform.position) < 1.5f)
        {
            pos.x += 3f;
        }
        Instantiate(enemy, pos, Quaternion.identity);
    }

    public void HitPlayer(int dmg)
    {
        player.hp -= dmg;
    }

    IEnumerator Spawner()
    {
        SpawnEnemy();
        yield return new WaitForSecondsRealtime(spawnDelay);
        StartCoroutine(Spawner());
    }
}
