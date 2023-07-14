using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIController : MonoBehaviour
{
  public static UIController Instance;

  [SerializeField] private CanvasGroup mainUI, titleScreen;

  void Awake()
  {
    Instance = this;
  }

  public void DisplayMainUI()
  {
    titleScreen.DOFade(0, 1f);
    titleScreen.interactable = false;

    mainUI.DOFade(1, 1f);
    mainUI.interactable = true;
    mainUI.blocksRaycasts = true;
  }
}
