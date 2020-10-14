using UnityEngine;
using UnityEngine.Serialization;

public enum PlayersIndex
{
    First = 1,
    Second
}

public class PlayerMoving : MonoBehaviour
{
    [FormerlySerializedAs("Speed")] public float speed = 10;

    [FormerlySerializedAs("PlayersIndex")] public PlayersIndex playersIndex = PlayersIndex.First;

    // Update is called once per frame
    private void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxisRaw("Horizontal");
        var moveVertical = Input.GetAxisRaw("Vertical");

        switch (playersIndex)
        {
            case PlayersIndex.First:
                ArrowMoving();
                return;
            case PlayersIndex.Second:
                transform.position = WasdMoving();
                return;
        }
    }

    private void ArrowMoving()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) transform.position += Vector3.left * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow)) transform.position += Vector3.right * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow)) transform.position += Vector3.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow)) transform.position += -Vector3.forward * speed * Time.deltaTime;
    }

    private Vector3 WasdMoving()
    {
        var pos = transform.position;

        if (Input.GetKey("w")) pos.z += speed * Time.deltaTime;
        if (Input.GetKey("s")) pos.z -= speed * Time.deltaTime;
        if (Input.GetKey("d")) pos.x += speed * Time.deltaTime;
        if (Input.GetKey("a")) pos.x -= speed * Time.deltaTime;

        return pos;
    }
}