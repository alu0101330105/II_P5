using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
  private Color _resetColor;
  [SerializeField]private Color _defaultColor;
  [SerializeField]private Color _hoverColor;

  // Start is called before the first frame update
  void Start() {
    _resetColor = new Color(0.103773f, 0.103773f, 0.103773f, 1f);
    GetComponent<Renderer>().material.color = _defaultColor;
  }

  public void OnPointerClick() {
    PressButton();
  }

  void ResetButton() {
    // make the material not emit light
      GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
      
  }

  public void OnPointerEnter() {
    if(GetComponent<Renderer>().material.color == _resetColor)
      return;
    // Debug.Log("Pointer Enter " + Time.time);
    // set the color to red _hoverColor
      GetComponent<Renderer>().material.color = _hoverColor;
  }

  public void OnPointerExit() {
    if(GetComponent<Renderer>().material.color == _resetColor)
      return;
    // Debug.Log("Pointer Exit " + Time.time);
    // set the color to red _defaultColor
      GetComponent<Renderer>().material.color = _defaultColor;
  }

  public void PressButton() {
    // Debug.Log("Button " + name + " Clicked");
    // Debug.Log(GetComponent<Renderer>());
    // make the material emit light
      GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    // set the emission color to red _hoverColor
      GetComponent<Renderer>().material.SetColor("_EmissionColor", _hoverColor);
    Invoke("ResetButton", 0.3f);
  }

  public void WinColor() {
    GetComponent<Renderer>().material.color = _resetColor;
  }

  public void ResetColor() {
    GetComponent<Renderer>().material.color = _defaultColor;
  }
}
