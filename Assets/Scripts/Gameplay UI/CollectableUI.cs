using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableUI : MonoBehaviour {

    public Sprite unCollected, collected;
    public List<Image> imageList = new List<Image>();
    public Image baseImg;

	void Start () {
		for (int i = 0; i < GameLogic.Instance.collectables.Capacity; i++)
        {
            imageList.Add(Instantiate(baseImg));
        }
        imageList.TrimExcess();
        for (int i = 0; i < imageList.Capacity; i++)
        {
            imageList[i].GetComponent<RectTransform>().localPosition = new Vector3(20+ (i * 30), 20);
            imageList[i].color = new Color(1f, 1f, 1f, 0.5f);
            imageList[i].transform.SetParent(transform);
        }
	}

	void Update () {
		for (int i = 0; i < imageList.Capacity; i++)
        {
            if (GameLogic.Instance.collectables[i] == null)
            {
                imageList[i].color = new Color(1f, 1f, 1f, 1f);
            } else if (GameLogic.Instance.holding == GameLogic.Instance.collectables[i])
            {
                imageList[i].color = new Color(1f, 1f, 0f, 1f);
            } else
            {
                imageList[i].color = new Color(1f, 1f, 1f, 0.5f);
            }
        }
    }
}
