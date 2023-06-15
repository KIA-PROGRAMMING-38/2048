using System.Collections.Generic;
using UnityEngine;

public class TileBoard : MonoBehaviour
{
	public Tile tilePrefab;
	public TileState[] tileStates;

	private TileGrid grid;

	private List<Tile> tiles;


	private void Awake()
	{
		grid = GetComponentInChildren<TileGrid>();
		tiles = new List<Tile>(16);
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
}
