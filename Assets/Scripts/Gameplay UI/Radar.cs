using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour {

    public List<Image> imageList = new List<Image>();
    public Image baseImg;
    public Image line;
    GameObject plr;

    private void Start()
    {
        for (int i = 0; i < GameLogic.Instance.collectables.Capacity; i++)
        {
            imageList.Add(Instantiate(baseImg));
            imageList[i].color = new Color(1f, 1f, 0f, 0f);
        }
        Image img = Instantiate(baseImg);
        img.color = new Color(0f, 1f, 1f, 0f);
        imageList.Add(img);
        Image img2 = Instantiate(baseImg);
        img2.color = new Color(1f, 0f, 0f, 0f);
        imageList.Add(img2);
        imageList.TrimExcess();
        for (int i = 0; i < imageList.Capacity; i++)
        {
            imageList[i].transform.SetParent(transform);
            imageList[i].GetComponent<RectTransform>().anchoredPosition.Set(0.5f, 0f);
        }
        plr = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update () {
		for (int i = 0; i < GameLogic.Instance.collectables.Capacity; i++)
        {
            if (GameLogic.Instance.collectables[i] != null)
            {
                Vector3 dir = (GameLogic.Instance.collectables[i].transform.position - plr.transform.position);
                float angle = Vector3.Angle(plr.transform.forward, dir);
                if (angle <= 45f)
                {
                    float leftAngle = Vector3.Angle(-plr.transform.forward - plr.transform.right, dir);
                    float rightAngle = Vector3.Angle(-plr.transform.forward + plr.transform.right, dir);
                    imageList[i].GetComponent<RectTransform>().localPosition = new Vector3(((leftAngle - rightAngle) * 3), line.GetComponent<RectTransform>().localPosition.y);
                    imageList[i].color = new Color(imageList[i].color.r, imageList[i].color.g, imageList[i].color.b, 1f);
                    continue;
                }
            }
            imageList[i].color = new Color(imageList[i].color.r, imageList[i].color.g, imageList[i].color.b, 0f);
        }
        Vector3 dir2 = (GameObject.FindGameObjectWithTag("Platform").transform.position - plr.transform.position);
        float angle2 = Vector3.Angle(plr.transform.forward, dir2);
        if (angle2 <= 45f)
        {
            float leftAngle = Vector3.Angle(-plr.transform.forward - plr.transform.right, dir2);
            float rightAngle = Vector3.Angle(-plr.transform.forward + plr.transform.right, dir2);
            imageList[imageList.Count - 2].GetComponent<RectTransform>().localPosition = new Vector3(((leftAngle - rightAngle) * 3), line.GetComponent<RectTransform>().localPosition.y);
            imageList[imageList.Count - 2].color = new Color(imageList[imageList.Count - 2].color.r, imageList[imageList.Count - 2].color.g, imageList[imageList.Count - 2].color.b, 1f);
        } else
        {
            imageList[imageList.Count - 2].color = new Color(imageList[imageList.Count - 2].color.r, imageList[imageList.Count - 2].color.g, imageList[imageList.Count - 2].color.b, 0f);
        }
        dir2 = (GameObject.FindGameObjectWithTag("Enemy").transform.position - plr.transform.position);
        angle2 = Vector3.Angle(plr.transform.forward, dir2);
        if (angle2 <= 45f)
        {
            float leftAngle = Vector3.Angle(-plr.transform.forward - plr.transform.right, dir2);
            float rightAngle = Vector3.Angle(-plr.transform.forward + plr.transform.right, dir2);
            imageList[imageList.Count - 1].GetComponent<RectTransform>().localPosition = new Vector3(((leftAngle - rightAngle) * 3), line.GetComponent<RectTransform>().localPosition.y);
            imageList[imageList.Count - 1].color = new Color(imageList[imageList.Count - 1].color.r, imageList[imageList.Count - 1].color.g, imageList[imageList.Count - 1].color.b, 1f);
        } else
        {
            imageList[imageList.Count - 1].color = new Color(imageList[imageList.Count - 1].color.r, imageList[imageList.Count - 1].color.g, imageList[imageList.Count - 1].color.b, 0f);
        }
    }

}
