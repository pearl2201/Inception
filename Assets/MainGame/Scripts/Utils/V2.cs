using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class V2I
{

    private int x;
    private int y;

    public V2I(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public int X
    {
        get
        {
            return x;
        }

        set
        {
            x = value;
        }
    }

    public int Y
    {
        get
        {
            return y;
        }

        set
        {
            y = value;
        }
    }
}

public class V2F
{

    private float x;
    private float y;

    public V2F(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public float X
    {
        get
        {
            return x;
        }

        set
        {
            x = value;
        }
    }

    public float Y
    {
        get
        {
            return y;
        }

        set
        {
            y = value;
        }
    }
}

public class ARCData
{
    public int X;
    public int Y;
    public int maxR;

    public ARCData(int x, int y, int maxR)
    {
        this.X = x;
        this.Y = y;
        this.maxR = maxR;
    }
}
