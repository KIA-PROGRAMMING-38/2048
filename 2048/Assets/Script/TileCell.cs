using UnityEngine;

public class TileCell : MonoBehaviour
{
	public Vector2Int coordinates { get; set; }
	public Tile tile { get; set; }

	// 타일이 셀에 배치되어 있는지 여부 판단

	// tile 이 null인 경우 true 그렇지 않은 경우 false
	public bool empty => tile == null; // 비어있는지

	// tile 이 null이 아닌 경우 true 그렇지 않은 경우 false
	public bool occupied => tile != null; // 채워져 있는지
}
