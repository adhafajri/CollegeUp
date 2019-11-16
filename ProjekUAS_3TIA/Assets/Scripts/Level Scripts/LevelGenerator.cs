using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelGenerator : MonoBehaviour {

	[SerializeField]
	private GameObject startPlatform, endPlatform, platform, fallingPlatform;

	private float blockWidth = 0.5f, blockHeight = 0.2f;

    private int amoutToSpawn;
	private int beginAmount = 0;

	public static Vector3 lastPos;

	private List<GameObject> spawnedPlatforms = new List<GameObject>();

	[SerializeField]
	private GameObject playerPrefab;


	void Awake () {
		InstantiateLevel();
	}

    void InstantiateLevel() {

        switch (GameplayController.level)
        {
            case 1:
                amoutToSpawn = 25;
                break;
            case 2:
                amoutToSpawn = 50;
                break;
            case 3:
                amoutToSpawn = 75;
                break;
            case 4:
                amoutToSpawn = 100;
                break;
        }
        

		for (int i = beginAmount; i < amoutToSpawn; i++) {

			GameObject newPlatform;

			if (i == 0) {
				newPlatform = Instantiate(startPlatform);
			} else if (i == amoutToSpawn - 1) {
				newPlatform = Instantiate(endPlatform);
                newPlatform.tag = "EndPlatform";

			} else {
                int chance = Random.Range(0, 100);
                if (chance > 75)
                {
                    newPlatform = Instantiate(fallingPlatform);
                }
                else
                {
                    newPlatform = Instantiate(platform);
                }
			}

			newPlatform.transform.parent = transform;

			spawnedPlatforms.Add(newPlatform);

			if (i == 0) {
				lastPos = newPlatform.transform.position;

                //instatiate the Player
                Vector3 temp = new Vector3(lastPos.x, lastPos.y + 1, lastPos.z);
                temp.y += 0.1f;
                Instantiate(playerPrefab, temp, Quaternion.identity);

				continue;
			}

			int left = Random.Range(0, 2);

			if (left == 0) {

				newPlatform.transform.position = 
					new Vector3(lastPos.x - blockWidth, lastPos.y + blockHeight, lastPos.z);

			} else {

				newPlatform.transform.position = 
					new Vector3(lastPos.x, lastPos.y + blockHeight, lastPos.z + blockWidth);
			
			}

			lastPos = newPlatform.transform.position;

			// animation
			if (i < 25) {

				float endPos = newPlatform.transform.position.y;

				newPlatform.transform.position =
					new Vector3(newPlatform.transform.position.x,
						newPlatform.transform.position.y - blockHeight * 3f,
						newPlatform.transform.position.z);

					newPlatform.transform.DOLocalMoveY(endPos, 0.3f).SetDelay(i * 0.1f);

			}

		}
		
	} // instantiate level

}
