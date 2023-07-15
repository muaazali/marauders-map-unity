/* Courtesy of Waldo from Press Start */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

  [Header("Position Bounds")]
  [SerializeField] private Vector2 lowerBound;
  [SerializeField] private Vector2 upperBound;

  Vector3 touchStart;
  Camera mainCamera;

  private Transform followTarget;

  public static CameraController Instance;

  void Awake()
  {
    Instance = this;
  }

  void Start()
  {
    mainCamera = Camera.main;
  }

  // Update is called once per frame
  void Update()
  {
    if (followTarget != null)
    {
      transform.position = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
    }
    if (Input.GetMouseButtonDown(0))
    {
      followTarget = null;
      touchStart = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
    if (Input.GetMouseButton(0))
    {
      Vector3 direction = touchStart - mainCamera.ScreenToWorldPoint(Input.mousePosition);
      transform.position += direction;
      transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, lowerBound.x, upperBound.x),
        Mathf.Clamp(transform.position.y, lowerBound.y, upperBound.y),
        transform.position.z
      );
    }
  }

  public void SetFollowTarget(Transform target)
  {
    Debug.Log("Follow target set.");
    followTarget = target;
  }
}