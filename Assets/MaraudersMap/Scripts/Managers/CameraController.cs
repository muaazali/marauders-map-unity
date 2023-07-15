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

  void Start()
  {
    mainCamera = Camera.main;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
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
}