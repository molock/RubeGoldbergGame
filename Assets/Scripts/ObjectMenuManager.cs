using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenuManager : MonoBehaviour {

    public int numItemSlots = 2;
    public GameObject[] objectPrefabList;
    public int[] itemsCount;
    public int currentObject = 0;
	public GameObject[] objectList;
    public string[] obejctNames;

    void Awake()
    {
        //objectPrefabList = new GameObject[numItemSlots];
        //itemsCount = new int[numItemSlots];
        //objectList = new GameObject[numItemSlots];
        //obejctNames = new string[numItemSlots];

        for (int i = 0; i < transform.childCount; i++)
        {
            objectList[i] = transform.GetChild(i).gameObject;
        }
    }

    // Use this for initialization
    // void Start()
    // {
    //     for(int i = 0; i < transform.childCount; ++i)
    //     {
    //         objectList[i] = transform.GetChild(i).gameObject;
    //     }
    // }

	public void HideMenu()
	{
		objectList[currentObject].SetActive(false);
	}

	public void ShowMenu()
    {
        objectList[currentObject].SetActive(true);
    }

    // show the left menu item
    public void MenuLeft()
    {
        objectList[currentObject].SetActive(false);
        currentObject--;
        if (currentObject < 0)
        {
            currentObject = objectList.Length - 1;
        }
        objectList[currentObject].SetActive(true);
    }

    // show the right menu item
    public void MenuRight()
    {
        objectList[currentObject].SetActive(false);
        currentObject++;
        if (currentObject > objectList.Length - 1)
        {
            currentObject = 0;
        }
        objectList[currentObject].SetActive(true);
    }

    public void SpawnCurrentObject()
    {
        if (itemsCount[currentObject] > 0)
        {
            Instantiate(objectPrefabList[currentObject], objectList[currentObject].transform.position, objectList[currentObject].transform.rotation);
            itemsCount[currentObject] --;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
