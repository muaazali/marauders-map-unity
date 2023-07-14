using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleOnUI : MonoBehaviour
{
  public string title;
  [SerializeField] private Transform titleLocation;
  [SerializeField] private GameObject titlePrefab;

  private GameObject uiTitleObject;
  private TMPro.TextMeshProUGUI uiTitleText;

  private Camera mainCamera;
  private float originalFontSize;

  public void Start()
  {
    mainCamera = Camera.main;
    uiTitleObject = Instantiate(titlePrefab, UIController.Instance.mainUI.transform);
    uiTitleText = uiTitleObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();
    uiTitleText.text = title;
    originalFontSize = uiTitleText.fontSize;
  }

  void Update()
  {
    uiTitleObject.transform.position = mainCamera.WorldToScreenPoint(titleLocation.position);
    uiTitleText.fontSize = originalFontSize * (5 / mainCamera.orthographicSize);
  }
}
