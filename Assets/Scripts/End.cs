using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{

    [SerializeField] Text text;
    [SerializeField] Text label1;
    [SerializeField] GameObject label;
    [SerializeField] Button button;
    [SerializeField] Sprite on;
    [SerializeField] Sprite off;
    private int level, score;
    [SerializeField] Image bg;
    [SerializeField] Sprite win;
    [SerializeField] Sprite lose;

    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("level", 0);
        score = PlayerPrefs.GetInt("score", 0);
        if(score>=(level+1)*50)
        {
            PlayerPrefs.SetInt("level", level + 1);
            PlayerPrefs.Save();
        } else
        {

        }
        label.SetActive(score < (level + 1) * 50);
        text.text = "SCORE: " + score + "/" + (level + 1) * 50;
        button.image.sprite = score >= (level + 1) * 50 ? on : off;
        label1.text = score >= (level + 1) * 50 ? "WIN" : "LOSE";
        bg.sprite = score >= (level + 1) * 50 ? win : lose;
    }

    public void goBack()
    {
        SceneManager.LoadScene(2);
    }
    public void again()
    {
        SceneManager.LoadScene(score >= (level + 1) * 50 ? 2 : 6);
    }

}
