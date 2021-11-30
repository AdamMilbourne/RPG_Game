using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RandomEncounterScript : MonoBehaviour
{
    [SerializeField] private GameObject encounterConfirm;
    [SerializeField] private bool enemyEncountered;
    [SerializeField]  public float period = 2.0f;
    [SerializeField] public float time = 0.0f;

    public void encounterEnemy()
    {
        
        if (enemyEncountered == true)
        {
            Debug.Log("enemy encountered");
            StartCoroutine(encounterConfirmed());
        }
    }

    
    
    private void OnTriggerStay(Collider other)
    {
        time += Time.deltaTime;

        if (time >= period)
        {
            time = time - period;
            if (other.tag == "Player")
            {

                int Encounter = Random.Range(1, 10);
                if (Encounter == 1)
                {
                    enemyEncountered = true;
                    encounterEnemy();
                }
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
