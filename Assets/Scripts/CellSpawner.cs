using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CellSpawner : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Vector3 _cellSize;
    [SerializeField] private int _cellsCountInLine;
    [SerializeField] private Finish _finish;
    [SerializeField] private Player _player;
    [SerializeField] private Game _game;
    public UnityEvent OnMapGenerated;
    private float _finishPos = 0.5f;
    private void Start()
    {
        Generate();
    }
    public void ReStart()
    {
        Generate();
    }
    private void Generate()
    {
        MapGenetrator genetrator = new MapGenetrator();
        MapGenetratorCell[,] map = genetrator.GenetrateCells(_cellsCountInLine, _cellsCountInLine);
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int z = 0; z < map.GetLength(1); z++)
            {
                Cell cell = Instantiate(_cellPrefab, transform).GetComponent<Cell>();
                cell.transform.localPosition = new Vector3(x * _cellSize.x, 0, z * _cellSize.z);
                cell.AcivateLeft(map[x, z].WallLeft);
                cell.AcivateBottom(map[x, z].WallBottom);
                cell.AcivateFloor(map[x, z].Floor);
                cell.AcivateDeadZone(map[x, z].DeadZone);
                if (x == _cellsCountInLine - 2 && z == _cellsCountInLine - 2)
                    PutInCell(cell, _finish.transform);
                if (x == 0 && z == 0)
                    PutInCell(cell, _player.transform);
            }
        }
        StartCoroutine("WaitGenerate");
    }

    private void PutInCell(Cell cell,Transform transform)
    {
        Instantiate(transform, cell.transform.position + new Vector3(_finishPos, -_finishPos, -_finishPos), Quaternion.identity);
    }

    private IEnumerator WaitGenerate()
    {
        yield return new WaitForSecondsRealtime(1f);
        _game.Continue();
        OnMapGenerated.Invoke();
    }
}
