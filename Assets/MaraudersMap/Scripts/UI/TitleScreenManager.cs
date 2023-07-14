using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Coffee.UIExtensions;

public class TitleScreenManager : MonoBehaviour
{
  public RevealOnHoverUI startText;
  public UIDissolve mapLogo;
  public UIDissolve mapAuthorsText, messersText, proudToPresentText;

  void Awake()
  {
    mapLogo.location = 1f;
    mapAuthorsText.location = 1f;
    messersText.location = 1f;
    proudToPresentText.location = 1f;
  }

  public void RevealMapLogo()
  {
    Tween tween = DOTween.To(() => startText.dissolveShader.location, x => startText.dissolveShader.location = x, 1, 1f);
    tween.OnComplete(() =>
    {
      startText.gameObject.SetActive(false);
      mapLogo.gameObject.SetActive(true);
      DOTween.To(() => mapLogo.location, x => mapLogo.location = x, 0, 3f);

      mapAuthorsText.gameObject.SetActive(true);
      messersText.gameObject.SetActive(true);
      proudToPresentText.gameObject.SetActive(true);
      DOTween.To(() => mapAuthorsText.location, x => mapAuthorsText.location = x, 0, 3f);
      DOTween.To(() => messersText.location, x => messersText.location = x, 0, 5f);
      DOTween.To(() => proudToPresentText.location, x => proudToPresentText.location = x, 0, 5f);

      Invoke("HideMapLogo", 6f);
    });
  }

  public void HideMapLogo()
  {
    DOTween.To(() => mapLogo.location, x => mapLogo.location = x, 1, 3f);
    DOTween.To(() => mapAuthorsText.location, x => mapAuthorsText.location = x, 1, 3f);
    DOTween.To(() => messersText.location, x => messersText.location = x, 1, 3f);
    DOTween.To(() => proudToPresentText.location, x => proudToPresentText.location = x, 1, 3f);
    Invoke("RevealGameplay", 4f);
  }

  void RevealGameplay()
  {
    UIController.Instance.DisplayMainUI();
  }
}
