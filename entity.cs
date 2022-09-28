using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


public class Entity
{
    public Entity(){}
    public int coordX { get; set; }
    public int coordY { get; set; }

    public Entity(int x, int y)
    {
        coordX = x;
        coordY = y;
    }

    public void SetPosition(int x , int y)
    {
        coordX = x;
        coordY = y;
    }

}