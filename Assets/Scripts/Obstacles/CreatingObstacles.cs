using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreatingObstacles : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] zombies;
    public GameObject[] lanes;
    private float MinDelay = 10f, MaxDelay = 40f;
    private float HalfDistance = 100f;
    private Tank player;
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Tank>();
      StartCoroutine("GenerateObstacles");
    }

    
    void Update()
    {
       
    }

    IEnumerator GenerateObstacles()
    {
        float timer = Random.Range(MinDelay, MaxDelay) / player.speed.z;
        yield return new WaitForSeconds(timer);

        CreateObstacles(player.gameObject.transform.position.z + HalfDistance);

        StartCoroutine(GenerateObstacles());
    }

    void CreateObstacles(float Zpos)
    {
        int r = Random.Range(0, 10);

        if(r >= 0 && r < 6)
        {
            int ObstacleLane = Random.Range(0, lanes.Length);

            GameObject obj = Instantiate(obstacles[Random.Range(0, obstacles.Length)],
                new Vector3(lanes[ObstacleLane].transform.position.x,.15f,Zpos),Quaternion.identity);
            StartCoroutine(DeactivatingObstacle(obj));

            int ZombieLane = 0;
            if (ObstacleLane == 0)
            {
                ZombieLane = Random.Range(0, lanes.Length) == 1 ? 1 : 2;
            }
            else if (ObstacleLane == 1) 
            {
                ZombieLane = Random.Range(0, lanes.Length) == 1 ? 0 : 2;
            }
            else
            {
                ZombieLane = Random.Range(0, lanes.Length) == 1 ? 0 : 1;
            }

            Instantiate(zombies[Random.Range(0, zombies.Length)], new Vector3(lanes[ZombieLane].transform.position.x, .15f, Zpos), Quaternion.identity);
            
            CreateZombies(new Vector3(lanes[ZombieLane].transform.position.x,0f,Zpos));
        }
    }

    void CreateZombies(Vector3 Zpos)
    {
        int r = Random.Range(0, 4);
        for (int i = 0; i < r; i++)
        {           
            Vector3 shift = new Vector3(Random.Range(-.7f, .7f), zombies[0].transform.position.y, Random.Range(10f, 30f)*i);
            Instantiate(zombies[Random.Range(0, zombies.Length)], Zpos + shift * i, Quaternion.identity);
        }
    }

    IEnumerator DeactivatingObstacle(GameObject obj)
    {
        yield return new WaitForSeconds(25f);
        obj.SetActive(false);
    }
}
