using System.Collections.Generic;
using UnityEngine;

public class MapGenetrator
{
    public MapGenetratorCell[,] GenetrateCells(int Width = 10, int Height = 10)
    {
        MapGenetratorCell[,] map = new MapGenetratorCell[Width, Height];
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int z = 0; z < map.GetLength(1); z++)
            {
                map[x, z] = new MapGenetratorCell(x, z);
                map[x, z].DeadZone = 0 == Random.Range(0, 4);
            }
        }
        for (int x = 0; x < map.GetLength(0); x++)
        {
            map[x, Height - 1].WallLeft = false;
            map[x, Height - 1].Floor = false;
            map[x, Height - 1].DeadZone = false;
        }
        for (int z = 0; z < map.GetLength(1); z++)
        {
            map[Width-1, z].WallBottom = false;
            map[Width-1, z].Floor = false;
            map[Width-1, z].DeadZone = false;
        }
        RemoveWallWithBacktracker(map, Width, Height);
        return map;
    }
    private void RemoveWallWithBacktracker(MapGenetratorCell[,] map, int Width = 10, int Height = 10)
    {
        MapGenetratorCell current = map[0, 0];
        current.isVisited = true;

        Stack<MapGenetratorCell> stack = new Stack<MapGenetratorCell>();
        do
        {
            List<MapGenetratorCell> unvisitedNeibours = new List<MapGenetratorCell>();

            int x = current.X;
            int z = current.Z;

            if (x > 0 && !map[x - 1, z].isVisited) unvisitedNeibours.Add(map[x - 1, z]);
            if (z > 0 && !map[x, z - 1].isVisited) unvisitedNeibours.Add(map[x, z - 1]);
            if (x < Width - 2 && !map[x + 1, z].isVisited) unvisitedNeibours.Add(map[x + 1, z]);
            if (z < Height - 2 && !map[x, z + 1].isVisited) unvisitedNeibours.Add(map[x, z + 1]);

            if(unvisitedNeibours.Count > 0)
            {
                MapGenetratorCell chosen = unvisitedNeibours[Random.Range(0, unvisitedNeibours.Count)];
                RemoveWall(current, chosen);
                chosen.isVisited = true;
                current = chosen;
                stack.Push(chosen);
            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);
            
    }
    private void RemoveWall(MapGenetratorCell a, MapGenetratorCell b)
    {
        if(a.X == b.X)
        {
            if (a.Z > b.Z)
                a.WallBottom = false;
            else 
                b.WallBottom = false;
        }
        else
        {
            if (a.X > b.X)
                a.WallLeft = false;
            else
                b.WallLeft = false;
        }
    }
}
