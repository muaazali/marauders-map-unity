using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowController : MonoBehaviour
{
  void Start()
  {
    LocationManager.Instance.Initialize();
    PersonSpawner.Instance.Initialize();
  }
}
