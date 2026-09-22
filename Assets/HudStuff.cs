using UnityEngine;
using UnityEngine.UI;

public class HudStuff : MonoBehaviour
{
    [SerializeField] private Text textHP, textScore;
    [SerializeField] private GameObject deathScreen;

    void Update()
    {
        textHP.text    = (gm.inst.player.hp > 0) ? $"HP: {gm.inst.player.hp}" : "You died!";
        textScore.text = $"Score: {gm.inst.score}";

        deathScreen.SetActive(gm.inst.player.hp <= 0);
    }
}
