
using UnityEngine;

public class ResultScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BORDER")
        {
            ObjectPooling.instance.ReturnToPool(gameObject.name, gameObject);
            GameStates.instance.currentCustomer.GetComponent<Animator>().SetTrigger("walkaway");
            if (gameObject == GameStates.instance.currentNeededItem)
            {
                GameStates.instance.scoreCounts += 400;
            }
            else
            {
                GameStates.instance.scoreCounts += 100;
            }
            DialogueManager.instance.ExitDialogueMode();
        }
    }
}