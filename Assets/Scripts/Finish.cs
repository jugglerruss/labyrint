using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    public UnityEvent OnWin;
    private Game _game;
    void Start()
    {
        _game = FindObjectOfType<Game>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            OnWin.Invoke();
            _game.Restart();
        }
    }
}
