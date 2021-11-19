using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private GameObject _wallLeft;
    [SerializeField] private GameObject _wallBottom;
    [SerializeField] private GameObject _floor;
    [SerializeField] private GameObject _deadZone;
    public void AcivateLeft(bool isActive)
    {
        _wallLeft.SetActive(isActive);
    }
    public void AcivateBottom(bool isActive)
    {
        _wallBottom.SetActive(isActive);
    }
    public void AcivateFloor(bool isActive)
    {
        _floor.SetActive(isActive);
    }
    public void AcivateDeadZone(bool isActive)
    {
        _deadZone.SetActive(isActive);
    }
}
