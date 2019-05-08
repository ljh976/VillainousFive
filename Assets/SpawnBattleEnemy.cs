using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpawnBattleEnemy : MonoBehaviour {

	[SerializeField]
	private GameObject enemyEncounter;

	private bool spawning = false;

	void Start() {
		DontDestroyOnLoad (this.gameObject);

		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (scene.name == "Battle") {
			if (this.spawning) {
				Instantiate (enemyEncounter);
				Debug.Log("Spawning Battle Enemies");
			}
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("On Trigger with Enemy");
		if (other.gameObject.tag == "Player") {
			Debug.Log("Identified collision with player");
			this.spawning = true;
			Scene sceneToLoad = SceneManager.GetSceneByName("Battle");
			SceneManager.LoadScene ("Battle");
			SceneManager.MoveGameObjectToScene(other.gameObject, sceneToLoad);
			SceneManager.MoveGameObjectToScene(this.gameObject, sceneToLoad);
		}
	}
}
