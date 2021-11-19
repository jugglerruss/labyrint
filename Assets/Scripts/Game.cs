using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private InputSystem _canvas;
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Continue()
    {
        Time.timeScale = 1;
    }
    public void Restart()
    {
        Destroy(FindObjectOfType<Player>().gameObject);
        StartCoroutine(WaitRestart());
    }
    private IEnumerator WaitRestart()
    {
        yield return new WaitForSecondsRealtime(2f);
        Pause();
        _canvas.Restart();
    }
    public void DestroyAll()
    {
        foreach (var item in FindObjectsOfType<Cell>())
        {
            Destroy(item.gameObject);
        }
        Destroy(FindObjectOfType<Finish>().gameObject);
    }
    public void Qiut()
    {
        Application.Quit();
    }
}
