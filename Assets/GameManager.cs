using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private int position = 0;
    private int score = 0;

    public GameObject selectedZombie;
    public List<GameObject> zombies;
    public Vector3 selectedSize;
    public Vector3 defaultSize;
    public Text scoreText;

    

	// Use this for initialization
	void Start () {
        scoreText.text = "Score: " + score;
        SelectZombie(selectedZombie);
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown("left")) {
            GetZombieLeft();
        }

        if (Input.GetKeyDown("right")) {
            GetZombieRight();
        }

        if (Input.GetKeyDown("up")) {
            PushUp();
        }
    }

    void GetZombieLeft() {
        if (position == 0) {
            position = 3;
            SelectZombie(zombies[position]);
        } else {
            GameObject newZombie = zombies[--position];
            SelectZombie(newZombie); 
        }

    }

    void GetZombieRight() {

        if(position == 3) {
            position = 0;
            SelectZombie(zombies[position]);
        } else {
            SelectZombie(zombies[++position]);
        }
    }

    void PushUp() {
        Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
        rb.AddForce(0, 0, 10, ForceMode.Impulse);
    }

    void SelectZombie(GameObject zombie) {
        selectedZombie.transform.localScale = defaultSize;
        selectedZombie = zombie;
        zombie.transform.localScale = selectedSize;
    }

    public void AddPoint() {
        score++;
        scoreText.text = "Score: " + score;
    }
}
