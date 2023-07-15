using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowController : MonoBehaviour
{
  public static GameFlowController Instance;
  public bool skipTitleScreen = false;

  bool isInit = false;

  void Awake()
  {
    Instance = this;

#if !UNITY_EDITOR
      skipTitleScreen = false;
#endif
  }

  void Start()
  {
    if (skipTitleScreen)
    {
      UIController.Instance.DisplayMainUI();
      StartGame();
    }
  }

  public void StartGame()
  {
    if (isInit) return;
    isInit = true;
    LocationManager.Instance.Initialize();
    PersonSpawner.Instance.Initialize();
  }
}
