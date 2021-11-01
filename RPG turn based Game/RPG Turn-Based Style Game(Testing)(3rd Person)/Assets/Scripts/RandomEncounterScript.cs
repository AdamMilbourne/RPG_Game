using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomEncounterScript : MonoBehaviour
{
    [SerializeField] private GameObject encounterConfirm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Random.Range(1, 101) == 10)
            {
                Debug.Log("player has entered");
                StartCoroutine(encounterConfirmed());
            }
        }
    }

    public IEnumerator encounterConfirmed()
    {
        encounterConfirm.SetActive(true);
        yield return new WaitForSeconds(2);
        encounterConfirm.SetActive(false);
    }

}
