using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public int LIFE = 3;
    public int POINT = 0;
    public int COIN = 0;
    public int ANIMAL;

    void Awake()
	{
        DontDestroyOnLoad(this.gameObject);
	}


}