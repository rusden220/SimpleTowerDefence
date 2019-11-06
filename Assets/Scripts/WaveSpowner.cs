using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpowner : MonoBehaviour
{
	public Transform Enemy;
	public float TimeBetweenWavesSecond = 5f;
	public Transform SpawnPosition;
	public Text WaveNumberText;


	private float countDownBetweenWavesSecond = 5f;
	private int WaveIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (countDownBetweenWavesSecond >= TimeBetweenWavesSecond)
		{
			StartCoroutine(SpawnWay());
			countDownBetweenWavesSecond = 0f;
		}

		countDownBetweenWavesSecond += Time.deltaTime;
	}

	private IEnumerator SpawnWay()
	{
		Debug.Log("new way!");
		WaveIndex++;
		WaveNumberText.text = WaveIndex.ToString();
		int enemyCount = WaveIndex;
		for (int i = 0; i < enemyCount; i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(0.5f);
			//sleep here;
		}
	}
	private void SpawnEnemy()
	{
		//TO DO: rewrite to pre create
		Instantiate(Enemy, SpawnPosition.position, SpawnPosition.rotation);
	}
}
