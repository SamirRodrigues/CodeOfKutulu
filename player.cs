using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


using Entity;

/**
 * Survive the wrath of Kutulu
 * Coded fearlessly by JohnnyYuge & nmahoude (ok we might have been a bit scared by the old god...but don't say anything)
 **/
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());

        Console.Error.WriteLine("width: " + width);
        Console.Error.WriteLine("height: " + height);

        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine();
        }
        inputs = Console.ReadLine().Split(' ');
        int sanityLossLonely = int.Parse(inputs[0]); // how much sanity you lose every turn when alone, always 3 until wood 1
        int sanityLossGroup = int.Parse(inputs[1]); // how much sanity you lose every turn when near another player, always 1 until wood 1
        int wandererSpawnTime = int.Parse(inputs[2]); // how many turns the wanderer take to spawn, always 3 until wood 1
        int wandererLifeTime = int.Parse(inputs[3]); // how many turns the wanderer is on map after spawning, always 40 until wood 1

        List<Entity> allies = new List<Entity>();
        List<Entity> enemies = new List<Entity>();

        Entity player = new Entity();
        Entity closerEnemy = new Entity();

        // game loop
        while (true)
        {
            //PREPEAR MAP
            allies.Clear();
            enemies.Clear();
            int entityCount = int.Parse(Console.ReadLine()); // the first given entity corresponds to your explorer
            
            //READ MAP
            for (int i = 0; i < entityCount; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                string entityType = inputs[0];
                int id = int.Parse(inputs[1]);
                int x = int.Parse(inputs[2]);
                int y = int.Parse(inputs[3]);
                int param0 = int.Parse(inputs[4]);
                int param1 = int.Parse(inputs[5]);
                int param2 = int.Parse(inputs[6]);
                                
                if(entityType == "EXPLORER")
                {
                    allies.Add(new Entity(x,y));
                }

                if(entityType == "WANDERER")
                {
                    enemies.Add(new Entity(x,y));
                }
            }

            player.SetPosition(allies[0].coordX,allies[0].coordY);
            int distance = 1000;
            
            foreach (Entity enemy in enemies)
            {
                if(((int)Math.Sqrt( Math.Pow((enemy.coordX - player.coordX),2) + Math.Pow((enemy.coordX - player.coordY),2))  ) < distance)
                {
                    distance = (int)Math.Sqrt( Math.Pow((enemy.coordX - player.coordX),2) + Math.Pow((enemy.coordX - player.coordY),2));
                    closerEnemy.SetPosition(enemy.coordX,enemy.coordY);
                }
            }

            Console.Error.WriteLine("CLOSER ENEMY: " + closerEnemy.coordX + " " + closerEnemy.coordY);   
            Console.Error.WriteLine("Distance: " + distance);   




            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            //Console.WriteLine("WAIT"); // MOVE <x> <y> | WAIT

            if(distance < 3)
            {                
                player.SetPosition(allies[1].coordX - closerEnemy.coordX, allies[1].coordY - closerEnemy.coordY);
            }
            else
            {
                player.SetPosition(allies[1].coordX,allies[1].coordY);
            }
            
            Console.WriteLine("MOVE" + " " + player.coordX + " " + player.coordY); // MOVE <x> <y> | WAIT

        }
    }
}