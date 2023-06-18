using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBoard : MonoBehaviour
{
	public Tile tilePrefab;
	public TileState[] tileStates;

	private TileGrid grid;

	private List<Tile> tiles;

	private bool delay;


	private void Awake()
	{
		grid = GetComponentInChildren<TileGrid>();
		tiles = new List<Tile>();
	}

	private void Start()
	{
		CreateTile();
		CreateTile();
	}

	private void CreateTile()
	{
		Tile tile = Instantiate(tilePrefab, grid.transform);
		int randomValue = Random.Range(0, 10);

		if (randomValue > 1)
		{
			tile.SetState(tileStates[0], 2);
		}
		else
		{
			tile.SetState(tileStates[1], 4);
		}
		tile.Spawn(grid.GetRandomEmptyCell());
		tiles.Add(tile);
	}

	private void Update()
	{
		if (!delay)
		{
			if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
			{
				MoveTiles(Vector2Int.up, 0, 1, 1, 1);
			}
			else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
			{
				MoveTiles(Vector2Int.down, 0, 1, grid.height - 2, -1);
			}
			else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
			{
				MoveTiles(Vector2Int.left, 1, 1, 0, 1);
			}
			else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
			{
				MoveTiles(Vector2Int.right, grid.width - 2, -1, 0, 1);
			}
		}
	}

	private void MoveTiles(Vector2Int direction, int startX, int incrementX, int startY, int incrementY)
	{
		bool changed = false;
		for (int x = startX; x >= 0 && x < grid.width; x += incrementX)
		{
			for (int y = startY; y >= 0 && y < grid.height; y += incrementY)
			{
				TileCell cell = grid.GetCell(x, y);

				if (cell.occupied)
				{
					changed |= MoveTile(cell.tile, direction);
				}
			}
		}

		if (changed)
		{
			StartCoroutine(WaitForChanges());
		}
	}

	private bool MoveTile(Tile tile, Vector2Int direction)
	{
		TileCell newCell = null;
		TileCell adjacent = grid.GetAdjacentCell(tile.cell, direction);

		while (adjacent != null)
		{
			if (adjacent.occupied)
			{
				// 합치기 추가 
				break;
			}

			newCell = adjacent;
			adjacent = grid.GetAdjacentCell(adjacent, direction);
		}

		if (newCell != null)
		{
			tile.MoveTo(newCell);
			return true;
		}

		return false;
	}

	private IEnumerator WaitForChanges()
	{
		delay = true;

		yield return new WaitForSeconds(0.1f);

		delay = false;

		// 새로운 타일 생성 코드

		// 게임오버 판별 코드
	}	
}
