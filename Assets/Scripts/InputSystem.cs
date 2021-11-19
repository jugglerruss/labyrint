using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private Transform _panelPause;
    [SerializeField] private Transform _panelRestart;
    public UnityEvent IsBlackPanel;
    private bool isShielded;
    private Image _image;
    private void Start()
    {
        _image = _panelRestart.GetComponent<Image>();
    }
    void Update()
    {
        if(Input.GetMouseButtonUp(0) && isShielded)
        {
            DeActivateShield();
        }
    }
    public void DeActivateShield()
    {
        isShielded = false;
        FindObjectOfType<Player>()?.DeActivateShield(); 
    }
    public void ActivateShield()
    {
        isShielded = true;
        FindObjectOfType<Player>()?.ActivateShield();
    }
    public void Pause()
    {
        _panelPause.gameObject.SetActive(true);
    }
    public void Continue()
    {
        _panelPause.gameObject.SetActive(false);
    }
    public void Restart()
    {
        StartCoroutine(Fade());
    }
    private IEnumerator Fade()
    {
        do
        {
            yield return new WaitForEndOfFrame();
            _image.color = new Color(0, 0, 0, _image.color.a + 0.01f);
        } while (_image.color.a < 1);
        IsBlackPanel.Invoke();
        do
        {
            yield return new WaitForEndOfFrame();
            _image.color = new Color(0, 0, 0, _image.color.a - 0.01f);
        } while (_image.color.a > 0f);
        Continue();
    }
}
