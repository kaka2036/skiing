using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float Speed;
    public float SpeedBonus;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        //Speed += SpeedBonus;
        //SpeedBonusCount();
        transform.Translate(Vector3.left * Time.deltaTime * Speed, Space.World);

        if (transform.position.x < -10)
        {
            transform.position += new Vector3(21, 0, 0);
            ShowRandomSprite();
        }
    }

    private void ShowRandomSprite()
    {
        int index = Random.Range(0, 3);
        int childCount = transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            bool shouldShow = index == i;

            child.gameObject.SetActive(shouldShow);
        }
    }

    private void OnEnable()
    {
        ShowRandomSprite();
    }

    public void SpeedBonusCount()
    {
        float t = Time.time - startTime;

        if (t > 5)
        {
            SpeedBonus = 0.5f;
        }
        if (t > 10)
        {
            SpeedBonus = 1f;
        }
        if (t > 15)
        {
            SpeedBonus = 1.5f;
        }
    }
}
