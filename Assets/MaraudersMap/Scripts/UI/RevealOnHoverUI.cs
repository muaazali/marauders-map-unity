using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Coffee.UIExtensions.UIDissolve))]
[RequireComponent(typeof(UnityEngine.EventSystems.EventTrigger))]
public class RevealOnHoverUI : MonoBehaviour
{
  public Coffee.UIExtensions.UIDissolve dissolveShader;
  private UnityEngine.EventSystems.EventTrigger eventTrigger;

  void Awake()
  {
    dissolveShader = GetComponent<Coffee.UIExtensions.UIDissolve>();
    dissolveShader.location = 1f;

    eventTrigger = GetComponent<UnityEngine.EventSystems.EventTrigger>();
  }

  void Start()
  {
    UnityEngine.EventSystems.EventTrigger.Entry entry = new UnityEngine.EventSystems.EventTrigger.Entry();
    entry.eventID = UnityEngine.EventSystems.EventTriggerType.PointerEnter;
    entry.callback.AddListener((data) => { Reveal(); });
    eventTrigger.triggers.Add(entry);
  }

  public void Reveal()
  {
    DOTween.To(() => dissolveShader.location, x => dissolveShader.location = x, 0, 1f);
  }
}
