using System.ComponentModel.Design;

namespace Robot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creati un program orientat pe obiecte pe baza pseudocodului dat
            Random random = new Random();
            Earth earth = new Earth();
            Console.WriteLine("Welcome to Earth Destroying Simulation 3000!");
            Console.WriteLine("Please name your ultimate death machine below, and hit enter!");
            string RobotName=Console.ReadLine();
            GiantKillerRobot robot = new GiantKillerRobot(RobotName);
            bool Active=robot.initialize();
            Console.WriteLine("Start looking for targets?");
            Console.WriteLine("Y / N");
            string answer = Console.ReadLine();
            string currentTarget=robot.target(random, answer);
            while (Active && earth.ContainsLife)
            {
                if (currentTarget != "alldead" && currentTarget != "n/a" && currentTarget != "sd" && robot.TargetIsAlive)
                    robot.TargetIsAlive = robot.FireLasersAt(random, currentTarget);
                else if (currentTarget != "alldead" && currentTarget != "n/a" && currentTarget != "sd" && !robot.TargetIsAlive)
                {
                    currentTarget = robot.target(random, answer);
                    robot.TargetIsAlive = true;
                }
                else if (currentTarget == "sd")
                {
                    Console.WriteLine("Hope you enjoyed Earth Destroying Simulation 3000!");
                    Active = false;
                }
                if (currentTarget == "alldead")
                {
                    earth.ContainsLife = false;
                    Console.WriteLine("Mission acomplished, all life has been eliminated");
                    Console.WriteLine("Hope you enjoyed Earth Destroying Simulation 3000!");
                }
            }
            

        }
    }
}
