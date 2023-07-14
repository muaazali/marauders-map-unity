using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
  public PersonAIBehaviourScriptableObject personAIBehaviour;
  public string personName;

  public void Initialize(PersonAIBehaviourScriptableObject personAIBehaviour, string name)
  {
    this.personAIBehaviour = personAIBehaviour;
    this.personName = name;
    GetComponent<TitleOnUI>().titlePrefab = personAIBehaviour.titlePrefab;
    GetComponent<TitleOnUI>().title = name;
    GetComponent<TitleOnUI>().Initialize();
  }
}
