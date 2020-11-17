using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float Speed;
    public float SpeedBonus;
    private float startTime;
    private float length;


    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startTime = Time.time;

    }
    // Update is called once per frame
    void Update()
    {
       // Speed += SpeedBonus;
        //SpeedBonusCount();
        transform.Translate(Vector3.left * Time.deltaTime * Speed, Space.World);

        if (transform.position.x < -length)
        {
            transform.position += new Vector3(length, 0, 0);
        }
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