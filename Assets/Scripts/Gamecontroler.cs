using UnityEngine;

public class Gamecontroler : MonoBehaviour
{
    public GameObject Hoa;
    public float SpeedDown;

    float CountTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameController started.");
    }

    // Update is called once per frame
    void Update()
    {
        CountTime -= Time.deltaTime;

        if (CountTime <= 0)
        {
            float positionX = Random.Range(-8, 8);
            Instantiate(Hoa, new Vector3(positionX, 7, 0), Quaternion.identity);
            Debug.Log("Spawned Hoa at position: " + positionX);
            CountTime = 2;
        }
    }
}

