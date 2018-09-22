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
    public bool left;

    RectTransform curTrans, prevTrans;

    public Canvas mainCanvas;
    public Button back, forward;
    public Text levelName;

    public float scrollSpeed = 1f;
    float y;

    private void Start()
    {
        Time.timeScale = 1f;
        levelImage.sprite = levels[currentLevel].LevelImage;
        curTrans = levelImage.GetComponent<RectTransform>();
        prevTrans = previousImage.GetComponent<RectTransform>();
        y = curTrans.localPosition.y;
    }

    void Update () {
        if (left && curTrans.localPosition.x != 0f)
        {
            curTrans.localPosition += new Vector3(Time.deltaTime * scrollSpeed, 0, 0);
            prevTrans.localPosition += new Vector3(Time.deltaTime * scrollSpeed, 0, 0);
            if (curTrans.localPosition.x > 0f)
            {
                curTrans.localPosition = new Vector3(0, y, 0);
                prevTrans.localPosition = new Vector3(1024f, y, 0);
            }
        }
        if (!left && curTrans.localPosition.x != 0f)
        {
            curTrans.localPosition -= new Vector3(Time.deltaTime * scrollSpeed, 0, 0);
            prevTrans.localPosition -= new Vector3(Time.deltaTime * scrollSpeed, 0, 0);
            if (curTrans.localPosition.x < 0f)
            {
                curTrans.localPosition = new Vector3(0, y, 0);
                prevTrans.localPosition = new Vector3(-1024f, y, 0);
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
            prevTrans.localPosition = new Vector3(0, y, 0);
            curTrans.localPosition = new Vector3(-1024f, y, 0);
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
            prevTrans.localPosition = new Vector3(0, y, 0);
            curTrans.localPosition = new Vector3(1024f, y, 0);
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
