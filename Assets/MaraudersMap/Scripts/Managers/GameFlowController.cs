using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowController : MonoBehaviour
{
  public static GameFlowController Instance;

  void Awake()
  {
    Instance = this;
  }

  public void StartGame()
  {
    LocationManager.Instance.Initialize();
    PersonSpawner.Instance.Initialize();
  }
}
