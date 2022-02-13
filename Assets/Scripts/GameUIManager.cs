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
            levelText.text = player.level.ToString();
            scoreText.text = player.score.ToString();
            experienceSlider.value = player.experience;
        }
    }
}
