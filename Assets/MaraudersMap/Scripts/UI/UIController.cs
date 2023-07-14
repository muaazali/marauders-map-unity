using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIController : MonoBehaviour
{
  public static UIController Instance;

  public CanvasGroup mainUI, titleScreen;
  public Canvas locationTitles, peopleTitles;

  void Awake()
  {
    Instance = this;

    mainUI.alpha = 0;
    mainUI.interactable = false;

    titleScreen.alpha = 1;
    titleScreen.interactable = true;
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
