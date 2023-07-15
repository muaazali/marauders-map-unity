using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{
  [System.Serializable]
  public class SpawnProperty
  {
    public PersonAIBehaviourScriptableObject personAIBehaviour;
    public List<string> names;
  }

  public List<SpawnProperty> spawnProperties;

  [SerializeField] private GameObject personPrefab;
  [SerializeField] private Transform peopleParent;

  public static PersonSpawner Instance;

  void Awake()
  {
    Instance = this;
  }

  public void Initialize()
  {
    foreach (SpawnProperty spawnProperty in spawnProperties)
    {
      foreach (string name in spawnProperty.names)
      {
        Transform spawnPoint = LocationManager.Instance.namedLocations[spawnProperty.personAIBehaviour.spawnPoints[Random.Range(0, spawnProperty.personAIBehaviour.spawnPoints.Count)]];
        GameObject person = Instantiate(personPrefab, spawnPoint.position, Quaternion.identity, peopleParent);
        person.name = name;
        person.GetComponent<AIController>().Initialize(spawnProperty.personAIBehaviour, name);
      }
    }
  }
}
