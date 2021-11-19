using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private Material _default;
    [SerializeField] private Material _shielded;
    [SerializeField] private GameObject _playerMini;
    private NavMeshAgent _agent;
    private MeshRenderer _mr;
    private Finish _finish;
    private Game _game;
    private bool _isShielded;
    void Start()
    {
        _mr = GetComponent<MeshRenderer>();
        _agent = GetComponent<NavMeshAgent>();
        _finish = FindObjectOfType<Finish>();
        _game = FindObjectOfType<Game>();
        StartCoroutine("StartMove");
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private IEnumerator StartMove()
    {
        yield return new WaitForSecondsRealtime(2f);
        _agent.SetDestination(new Vector3(_finish.transform.position.x,transform.position.y,_finish.transform.position.z));
    }
    public void DeActivateShield()
    {
        _mr.material = _default;
        _isShielded = false;
        StopCoroutine("ShieldTimer");
    }
    public void ActivateShield()
    {
        _mr.material = _shielded;
        _isShielded = true;
        StartCoroutine("ShieldTimer");
    }
    private IEnumerator ShieldTimer()
    {
        yield return new WaitForSecondsRealtime(2f);
        DeActivateShield();
    }
    public void GetHit()
    {
        if (_isShielded)
            return;
        for (int i = 0; i < 10; i++)
        {
            Instantiate(_playerMini, transform.position, Quaternion.identity);
        }
        _game.Restart();
        
    }
}
