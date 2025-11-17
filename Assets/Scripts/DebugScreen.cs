using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class DebugScreen : MonoBehaviour
{

    World world;
    Text text;

    float frameRate;
    float timer;

    int halfWorldSizeInVoxels;
    int halfWorldSizeINChunks;

    void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();
        text = GetComponent<Text>();

        halfWorldSizeInVoxels = VoxelData.WorldSizeInVoxels / 2;
        halfWorldSizeINChunks = VoxelData.WorldSizeInChunks / 2;
    }

    void Update()
    {
        string debugText = "Hello , World! Minecraft on Unity!";
        debugText += "\n";
        debugText += frameRate + " fps";
        debugText += "\n\n";
        debugText += "XYZ : " + (Mathf.FloorToInt(world.player.transform.position.x) - halfWorldSizeInVoxels) + " / " + Mathf.FloorToInt(world.player.transform.position.y) + " / " + (Mathf.FloorToInt(world.player.transform.position.z) - halfWorldSizeInVoxels);
        debugText += "\n";
        debugText += "Chunk: " + (world.playerChunkCoord.x - halfWorldSizeINChunks) + " / " + (world.playerChunkCoord.z - halfWorldSizeINChunks);

        text.text = debugText;

        if (timer > 1f)
        {
            frameRate = (int)(1f / Time.unscaledDeltaTime);
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
