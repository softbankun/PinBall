using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsController : MonoBehaviour
{
    private GameObject pointText;
    private int game_point = 0;

    void OnCollisionEnter(Collision other)
    {
        this.pointText = GameObject.Find("PointText");

        if (other.gameObject.tag == "SmallStarTag")
        {
            this.game_point += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.game_point += 30;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.game_point += 20;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.game_point += 40;
        }
    }
    void Update()
    {
        this.pointText.GetComponent<Text>().text = "SCORE:" + game_point + "点";
    }
}
