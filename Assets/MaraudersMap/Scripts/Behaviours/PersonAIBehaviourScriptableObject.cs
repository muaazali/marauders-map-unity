using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PersonType
{
  Student,
  Teacher,
  Headmaster,
  Ghost
}

[CreateAssetMenu(fileName = "PersonAIBehaviour", menuName = "ScriptableObjects/PersonAIBehaviour", order = 1)]
public class PersonAIBehaviourScriptableObject : ScriptableObject
{
  public PersonType personType;
  public float speed;
  public List<string> locationsToExplore;
  public List<string> spawnPoints;

  [Header("Prefabs")]
  public GameObject titlePrefab;
}
