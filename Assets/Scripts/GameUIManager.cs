using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public TMP_Text levelText;
    public TMP_Text scoreText;
    public Slider experienceSlider;

    private void Update()
    {
        PlayerManager player = GameManager.instance.player;

        if (player != null)
        {
            levelText.text = player.experience.ToString();
            scoreText.text = player.level.ToString();
            experienceSlider.value = player.score;
        }
    }
}
