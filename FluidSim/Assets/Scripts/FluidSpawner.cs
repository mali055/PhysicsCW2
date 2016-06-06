using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FluidSpawner : MonoBehaviour {

    public Particle part;
    public List<Particle> parts = new List<Particle>();
    public float partMultiplier;
    public bool containerDraw;
    public Vector3 containerSize;
    public Color containerColor;
    public bool spawnDraw;
    public Vector3 spawnSize;
    public Color spawnColor;
    
    // Use this for initialization
    void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update ()
    {
        drawContainers();
        //spawn(f, ftemp); // LHS of Boltzmann equation
    }

    void OnDrawGizmos()
    {
        if (containerDraw) DebugExtension.DrawBounds(new Bounds(Vector3.zero + this.transform.position, containerSize), containerColor);
        if (spawnDraw) DebugExtension.DrawBounds(new Bounds(Vector3.zero + this.transform.position, spawnSize), spawnColor);
    }

    void drawContainers()
    {
        DebugExtension.DebugBounds(new Bounds(Vector3.zero + this.transform.position, containerSize), containerColor);
        DebugExtension.DebugBounds(new Bounds(Vector3.zero + this.transform.position, spawnSize), spawnColor);
    }

    void Init()
    {
        //Spawn Particles in green zone grid based
        Vector3 halfSize = (spawnSize * partMultiplier);
        Debug.Log("Init - Half Size = " + halfSize);
        for (int x = 0; x < (halfSize.x); x++)
        {
            for (int y = 0; y < (halfSize.y); y++)
            {
                for (int z = 0; z < (halfSize.z); z++)
                {
                    //Debug.Log(" x = " + x + " / y = " + y + " / z = " + z);
                    Particle newPart = Instantiate(part) as Particle;
                    newPart.transform.parent = this.transform;
                    newPart.transform.localPosition = Vector3.zero - (spawnSize * 0.5f) + (0.5f * (Vector3.one / partMultiplier));
                    newPart.transform.localPosition += new Vector3(x * (1 / partMultiplier), y * (1 / partMultiplier), z * (1 / partMultiplier));
                    //newPart.Init(ux, uy, lx, ly);
                    parts.Add(newPart);
                }
            }
        }

        // initialize fluid parameters
        //float reynolds = 100f;
        //float kin_visc_lb = 0.05f;
        //ux0 = reynolds * kin_visc_lb / (ly - 1);
        //omegaf = 1f / (3f * kin_visc_lb + 0.5f);

        //// declare fluid arrays
        //int gridSize = lx * ly;
        //int fullSize = gridSize * Q;
        //obst = new bool[gridSize];
        //f = new float[fullSize];
        //ftemp = new float[fullSize];
        //density = new float[gridSize];
        //ux = new float[gridSize];
        //uy = new float[gridSize];

        //// initialize arrays
        //for (int y = 0; y < ly; ++y)
        //{
        //    for (int x = 0; x < lx; ++x)
        //    {
        //        int pos = x + lx * y;
        //        obst[pos] = obstacles.GetPixel(x, y).grayscale > 0.5f ? true : false;
        //        density[pos] = density0;
        //        ux[pos] = ux0;
        //        uy[pos] = 0f;
        //        float u2 = ux[pos] * ux[pos] + uy[pos] * uy[pos];
        //        for (int i = 0; i < Q; ++i)
        //        {
        //            int posQ = Q * pos + i;
        //            f[posQ] = ftemp[posQ] = density[pos] * rt[i] * (1f + (ex[i] * ux[pos] + ey[i] * uy[pos]) / cs2 + (ex[i] * ux[pos] + ey[i] * uy[pos]) * (ex[i] * ux[pos] + ey[i] * uy[pos]) / (2f * cs2 * cs2) - u2 / (2f * cs2));
        //        }
        //    }
        //}
    }

    void spawn(float[] f, float[] ftemp)
    {
        //for (int y = 0; y < ly; ++y)
        //{
        //    for (int x = 0; x < lx; ++x)
        //    {
        //        int pos = x + lx * y;

        //        int y_n = (y == ly - 1) ? -1 : y + 1; // avoiding periodic bc
        //        int x_e = (x == lx - 1) ? -1 : x + 1; // avoiding periodic bc
        //        int y_s = (y == 0) ? -1 : y - 1; // avoiding periodic bc
        //        int x_w = (x == 0) ? -1 : x - 1; // avoiding periodic bc

        //        ftemp[Q * pos] = f[Q * pos];
        //        if (x_e != -1) { ftemp[Q * (x_e + y * lx) + 1] = f[Q * pos + 1]; }
        //        if (y_n != -1) { ftemp[Q * (x + y_n * lx) + 2] = f[Q * pos + 2]; }
        //        if (x_w != -1) { ftemp[Q * (x_w + y * lx) + 3] = f[Q * pos + 3]; }
        //        if (y_s != -1) { ftemp[Q * (x + y_s * lx) + 4] = f[Q * pos + 4]; }
        //        if (x_e != -1 && y_n != -1) { ftemp[Q * (x_e + y_n * lx) + 5] = f[Q * pos + 5]; }
        //        if (x_w != -1 && y_n != -1) { ftemp[Q * (x_w + y_n * lx) + 6] = f[Q * pos + 6]; }
        //        if (x_w != -1 && y_s != -1) { ftemp[Q * (x_w + y_s * lx) + 7] = f[Q * pos + 7]; }
        //        if (x_e != -1 && y_s != -1) { ftemp[Q * (x_e + y_s * lx) + 8] = f[Q * pos + 8]; }
        //    }
        //}
    }
}
