using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public TileBoard board;

	public CanvasGroup canvas;

	private void Start()
	{
		NewGame();
	}

	public void NewGame()
	{
		canvas.alpha = 0f;
		canvas.interactable = false;

		board.ClearBoard();
		board.CreateTile();
		board.CreateTile();
		board.enabled = true;
	}

	public void GameOver()
	{
		board.enabled = false;
		canvas.interactable = true;

		StartCoroutine(Fade(canvas, 1f, 1f));
	}

	private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay)
	{
		yield return new WaitForSeconds(delay);

		float elapsedTime = 0f;
		float duration = 0.5f;
		float from = canvasGroup.alpha;

		while (elapsedTime < duration)
		{
			canvasGroup.alpha = Mathf.Lerp(from, to, elapsedTime / duration);
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		canvasGroup.alpha = to;
	}
}
