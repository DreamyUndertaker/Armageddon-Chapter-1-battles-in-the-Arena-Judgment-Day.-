using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
   
    [SerializeField] private LayerMask player;
    private Collider2D coll;
   
   
    // Start is called before the first frame update
    void Start()
    {
        coll = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coll.IsTouchingLayers(player))
        {
            LevelController.instance.NextLevel();

            LevelController.instance.isEndGame();

        }
    }
    
}
