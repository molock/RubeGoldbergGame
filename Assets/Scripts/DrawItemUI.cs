using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawItemUI : MonoBehaviour {

	public ObjectMenuManager objectMenuManager;

	private List<Text> textList = new List<Text>();
	public Font myFont;
	public int myFontSize;
	public float textWidth;
	public float textHeight;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < objectMenuManager.numItemSlots; i++)
		{
			string name = objectMenuManager.obejctNames[i];
			int count = objectMenuManager.itemsCount[i];

			GameObject itemText = new GameObject(name);
            itemText.transform.SetParent(this.transform);

            Text iText = itemText.AddComponent<Text>();

			// set the text properties
			iText.text = name + "    " + count.ToString();
			iText.transform.localScale = new Vector3(1, 1, 1);
			iText.transform.localPosition = new Vector3(0, 10f - i * 10f, 0);
			iText.transform.localRotation = Quaternion.identity;
			iText.font = myFont;
			iText.fontSize = myFontSize;
			iText.color = Color.black;
			iText.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(textWidth, textHeight);

			textList.Add(iText);
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < objectMenuManager.numItemSlots; i++)
        {
            string name = objectMenuManager.obejctNames[i];
            int count = objectMenuManager.itemsCount[i];

			textList[i].text = name + "    " + count.ToString();
        }


	}

}
