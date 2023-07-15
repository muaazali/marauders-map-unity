using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
  public static LocationManager Instance;

  public Dictionary<string, Transform> namedLocations;

  void Awake()
  {
    Instance = this;
  }

  public void Initialize()
  {
    namedLocations = new Dictionary<string, Transform>();
    var locations = GameObject.FindGameObjectsWithTag("NamedLocation");
    foreach (GameObject location in locations)
    {
      namedLocations.Add(location.name, location.transform);
    }
  }
}
