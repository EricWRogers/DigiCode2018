using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct Level
{
    public string SceneName;
    public string LevelName;
    public Sprite LevelImage;
}

public class LevelSelectCanvas : MonoBehaviour {

    [SerializeField]
    public Level[] levels;
    int currentLevel;

    public Image levelImage;
    public Image previousImage;
    bool left;

    RectTransform curTrans, prevTrans;

    public Canvas mainCanvas;
    public Button back, forward;
    public Text levelName;

    public float scrollSpeed;
    float y;

    private void Start()
    {
        levelImage.sprite = levels[currentLevel].LevelImage;
        curTrans = levelImage.GetComponent<RectTransform>();
        prevTrans = previousImage.GetComponent<RectTransform>();
        y = curTrans.anchoredPosition.y;
    }

    void Update () {
        if (left && curTrans.anchoredPosition.x != 0f)
        {
            curTrans.anchoredPosition.Set(curTrans.anchoredPosition.x - (Time.deltaTime * scrollSpeed), y);
            prevTrans.anchoredPosition.Set(prevTrans.anchoredPosition.x - (Time.deltaTime * scrollSpeed), y);
            if (curTrans.anchoredPosition.x < 0f)
            {
                curTrans.anchoredPosition.Set(0f, y);
                prevTrans.anchoredPosition.Set(-1024f, y);
            }
        }
        if (!left && curTrans.anchoredPosition.x != 0f)
        {
            curTrans.anchoredPosition.Set(curTrans.anchoredPosition.x + (Time.deltaTime * scrollSpeed), y);
            prevTrans.anchoredPosition.Set(prevTrans.anchoredPosition.x + (Time.deltaTime * scrollSpeed), y);
            if (curTrans.anchoredPosition.x > 0f)
            {
                curTrans.anchoredPosition.Set(0f, y);
                prevTrans.anchoredPosition.Set(1024f, y);
            }
        }
    }

    public void ButtonBack()
    {
        if (currentLevel > 0)
        {
            forward.gameObject.SetActive(true);
            previousImage.sprite = levelImage.sprite;
            left = true;
            currentLevel--;
            levelImage.sprite = levels[currentLevel].LevelImage;
            prevTrans.anchoredPosition.Set(0f, y);
            curTrans.anchoredPosition.Set(1024f, y);
            levelName.text = levels[currentLevel].LevelName;
            if (currentLevel == 0)
            {
                back.gameObject.SetActive(false);
            }
        }
    }

    public void ButtonForward()
    {
        if (currentLevel < levels.Length-1)
        {
            back.gameObject.SetActive(true);
            previousImage.sprite = levelImage.sprite;
            left = false;
            currentLevel++;
            levelImage.sprite = levels[currentLevel].LevelImage;
            prevTrans.anchoredPosition.Set(0f, y);
            curTrans.anchoredPosition.Set(-1024f, y);
            levelName.text = levels[currentLevel].LevelName;
            if (currentLevel == levels.Length - 1)
            {
                forward.gameObject.SetActive(false);
            }
        }
    }

    public void ButtonPlay()
    {
        SceneManager.LoadScene(levels[currentLevel].SceneName);
    }

    public void ButtonMainMenu()
    {
        mainCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
