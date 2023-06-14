using UnityEngine;

public class TileCell : MonoBehaviour
{
	public Vector2Int coordinates { get; set; }
	public Tile tile { get; set; }

	// Ÿ���� ���� ��ġ�Ǿ� �ִ��� ���� �Ǵ�

	// tile �� null�� ��� true �׷��� ���� ��� false
	public bool empty => tile == null; // ����ִ���

	// tile �� null�� �ƴ� ��� true �׷��� ���� ��� false
	public bool occupied => tile != null; // ä���� �ִ���
}
