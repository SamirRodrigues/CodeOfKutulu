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
                if((Math.Abs(enemy.coordX - player.coordX) + Math.Abs(enemy.coordX - player.coordY)) < distance)
                {
                    distance = (Math.Abs(enemy.coordX - player.coordX) + Math.Abs(enemy.coordX - player.coordY));
                    closerEnemy.SetPosition(enemy.coordX,enemy.coordY);
                }
            }

            Console.Error.WriteLine("CLOSER ENEMY: " + closerEnemy.coordX + " " + closerEnemy.coordY + " " + distance);   




            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            //Console.WriteLine("WAIT"); // MOVE <x> <y> | WAIT

            foreach (Entity ally in allies)
            {
                Console.Error.WriteLine("Ally: " + ally.coordX + " " + ally.coordY);                
            }
            
            foreach (Entity enemy in enemies)
            {
                Console.Error.WriteLine("Enemy: " + enemy.coordX + " " + enemy.coordY);  
            }
            
            Console.WriteLine("MOVE" + " " + allies[1].coordX + " " + allies[1].coordY); // MOVE <x> <y> | WAIT

        }
    }
}