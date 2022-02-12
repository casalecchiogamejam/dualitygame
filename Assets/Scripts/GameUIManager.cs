using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public GameObject levelText;
    public GameObject scoreText;
    public GameObject experienceSlider;

    private void Update()
    {
        Player player = GameManager.instance.player;

        if(player != null)
        {
            levelText.GetComponent<TextMesh>().text = player.experience.ToString();
            scoreText.GetComponent<TextMesh>().text = player.level.ToString();
            experienceSlider.GetComponent<Slider>().value = player.score;
        }
    }

}
