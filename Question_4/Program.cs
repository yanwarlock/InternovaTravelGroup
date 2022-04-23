using System;

namespace Question_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var agent = new Agent("juan", 1, new Agent.Agency("Agency1", "Caracas"));
           var agenteCopy = agent.DeepCopy();
            Console.WriteLine("Before Changing: ");
            Console.WriteLine(agent.Name);
            Console.WriteLine(agent.Id);
            Console.WriteLine(agent.AssignedAgency.City);
            Console.WriteLine(agent.AssignedAgency.Name);

            Console.WriteLine("\nAfter Changing: ");
            agent.Name = "new Juan";
            agent.AssignedAgency.City = "new Caracas";

            Console.WriteLine(agent.Name);
            Console.WriteLine(agent.AssignedAgency.City);

            Console.WriteLine(agenteCopy.Name);
            Console.WriteLine(agenteCopy.AssignedAgency.City);


        }
    }

    public class Agent
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public Agency AssignedAgency { get; set; }

        public Agent(string name,long id,Agency assignedAgency)
        {
            Name = name;
            Id = id;
            AssignedAgency = assignedAgency;
        }

        public class Agency 
        {
            public string Name { get; set; }
            public string City { get; set; }

            public Agency(string name , string city)
            {
               Name = name;
                City = city;
            }
        }     
    }

    public static class AgentExtensions
    {
        public static Agent DeepCopy(this Agent agent)
        {
            var result = new Agent(agent.Name, agent.Id, new Agent.Agency(agent.AssignedAgency.Name,agent.AssignedAgency.City));
            return result;
        }
    }
}
