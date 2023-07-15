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
  private Vector3 titleOffset;

  private bool isInit = false;

  void Awake()
  {
    mainCamera = Camera.main;
    titleOffset = titleLocation.localPosition;
  }

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
    uiTitleObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
    {
      Debug.Log("Clicked!");
      CameraController.Instance.SetFollowTarget(transform);
    });
    uiTitleText = uiTitleObject.GetComponentInChildren<UnityEngine.UI.Text>();
    uiTitleText.text = title;
    originalFontSize = uiTitleText.fontSize;
  }

  void Update()
  {
    uiTitleObject.transform.position = mainCamera.WorldToScreenPoint(transform.position + titleOffset);
    uiTitleText.fontSize = Mathf.FloorToInt(originalFontSize * (7 / mainCamera.orthographicSize));
  }
}
