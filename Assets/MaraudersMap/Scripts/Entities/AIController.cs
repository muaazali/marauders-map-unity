using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
  public PersonAIBehaviourScriptableObject personAIBehaviour;
  public string personName;

  private NavMeshAgent agent;

  void Awake()
  {
    agent = GetComponent<NavMeshAgent>();
    agent.updateRotation = false;
    agent.updateUpAxis = false;
  }

  public void Initialize(PersonAIBehaviourScriptableObject personAIBehaviour, string name)
  {
    this.personAIBehaviour = personAIBehaviour;
    this.personName = name;
    GetComponent<TitleOnUI>().titlePrefab = personAIBehaviour.titlePrefab;
    GetComponent<TitleOnUI>().title = name;
    GetComponent<TitleOnUI>().Initialize();

    agent.speed = personAIBehaviour.speed;
    agent.SetDestination(LocationManager.Instance.namedLocations[personAIBehaviour.locationsToExplore[Random.Range(0, personAIBehaviour.locationsToExplore.Count)]].position);
  }

  private bool waitingForNextDestination = false;
  void Update()
  {
    if (!agent.isStopped)
    {
      transform.rotation = Quaternion.LookRotation(Vector3.forward, agent.velocity.normalized);
    }
    if (waitingForNextDestination)
    {
      if (agent.remainingDistance < 1f)
      {
        agent.SetDestination(transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0f));
      }
    }
    else
    {
      if (agent.remainingDistance < 1f)
      {
        waitingForNextDestination = true;
        Invoke("SetNextDestination", 10f);
      }
    }
  }

  void SetNextDestination()
  {
    waitingForNextDestination = false;
    agent.SetDestination(LocationManager.Instance.namedLocations[personAIBehaviour.locationsToExplore[Random.Range(0, personAIBehaviour.locationsToExplore.Count)]].position);
  }
}
