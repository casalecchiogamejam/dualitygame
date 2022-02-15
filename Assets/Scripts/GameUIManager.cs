using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public TMP_Text levelText;
    public TMP_Text scoreText;
    public Image experienceBar;
    private void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.eulerAngles.z);
        PlayerManager player = GameManager.instance.player;

        if (player != null)
        {
            levelText.text = player.level.ToString();
            // scoreText.text = player.score.ToString();
            experienceBar.fillAmount = player.experiencePercent;
        }
    }
}
