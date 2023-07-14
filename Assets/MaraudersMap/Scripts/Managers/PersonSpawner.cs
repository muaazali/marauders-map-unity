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

  void Start()
  {
    foreach (SpawnProperty spawnProperty in spawnProperties)
    {
      foreach (string name in spawnProperty.names)
      {
        GameObject person = Instantiate(personPrefab, transform);
        person.GetComponent<AIController>().Initialize(spawnProperty.personAIBehaviour, name);
      }
    }
  }
}
