using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;

public class GameManager : MonoBehaviour
{
	public TileBoard board;

	public CanvasGroup canvas;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI bestScoreText;

	private int score;

	private void Start()
	{
		NewGame();
	}

	public void NewGame()
	{
		SetScore(0);
		bestScoreText.text = LoadScroe().ToString();

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

	public void PlusScore(int points)
	{
		SetScore(score + points);
	}

	private void SetScore(int score)
	{
		this.score = score;

		scoreText.text = score.ToString();

		SaveScroe();
	}

	private void SaveScroe()
	{
		int bestScore = LoadScroe();

		if (score > bestScore)
		{
			PlayerPrefs.SetInt("bestScore", score);
		}
	}

	private int LoadScroe()
	{
		return PlayerPrefs.GetInt("bestScore", 0);
	}

	public void LoadScene()
	{
		SceneManager.LoadScene(0);
	}
}
