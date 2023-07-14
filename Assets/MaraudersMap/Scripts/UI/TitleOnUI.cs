using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleOnUI : MonoBehaviour
{
  public int sortingOrder = 0;
  public string title;
  public GameObject titlePrefab;
  [SerializeField] private Transform titleLocation;

  private GameObject uiTitleObject;
  private UnityEngine.UI.Text uiTitleText;

  private Camera mainCamera;
  private float originalFontSize;

  private bool isInit = false;

  void Start()
  {
    if (title == "")
    {
      return;
    }
    Initialize();
  }

  public void Initialize()
  {
    if (isInit) return;
    isInit = true;
    Debug.Log(name + "bro I just got initialized");
    mainCamera = Camera.main;
    uiTitleObject = Instantiate(titlePrefab, UIController.Instance.mainUI.transform);
    switch (sortingOrder)
    {
      case 1:
        uiTitleObject.transform.SetParent(UIController.Instance.locationTitles.transform);
        break;
      case 2:
        uiTitleObject.transform.SetParent(UIController.Instance.peopleTitles.transform);
        break;
      default:
        break;
    }
    uiTitleText = uiTitleObject.GetComponentInChildren<UnityEngine.UI.Text>();
    uiTitleText.text = title;
    originalFontSize = uiTitleText.fontSize;
  }

  void Update()
  {
    uiTitleObject.transform.position = mainCamera.WorldToScreenPoint(titleLocation.position);
    uiTitleText.fontSize = Mathf.FloorToInt(originalFontSize * (7 / mainCamera.orthographicSize));
  }
}
