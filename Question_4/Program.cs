using System;
using System.Text.Json;

namespace Question_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var agent = new Agent("juan", 1, new Agent.Agency("Agency1", "Caracas"));
            var agentCopy = agent.DeepCopy();
            Console.WriteLine("Before Changing: ");
            Console.WriteLine($"[ORIGINAL] Id: {agent.Id}");
            Console.WriteLine($"[ORIGINAL] Name: {agent.Name}");
            Console.WriteLine($"[ORIGINAL] Agency Name: {agent.AssignedAgency.Name}");
            Console.WriteLine($"[ORIGINAL] Agency City: {agent.AssignedAgency.City}");

            Console.WriteLine($"[COPY] Id: {agentCopy.Id}");
            Console.WriteLine($"[COPY] Name: {agentCopy.Name}");
            Console.WriteLine($"[COPY] Agency Name: {agentCopy.AssignedAgency.Name}");
            Console.WriteLine($"[COPY] Agency City: {agentCopy.AssignedAgency.City}");

            Console.WriteLine("\nAfter Changing: ");
            agent.Name = "new Juan*";
            agent.AssignedAgency.City = "new Caracas*";

            Console.WriteLine($"[ORIGINAL] Id: {agent.Id}");
            Console.WriteLine($"[ORIGINAL] Name: {agent.Name}");
            Console.WriteLine($"[ORIGINAL] Agency Name: {agent.AssignedAgency.Name}");
            Console.WriteLine($"[ORIGINAL] Agency City: {agent.AssignedAgency.City}");

            Console.WriteLine($"[COPY] Id: {agentCopy.Id}");
            Console.WriteLine($"[COPY] Name: {agentCopy.Name}");
            Console.WriteLine($"[COPY] Agency Name: {agentCopy.AssignedAgency.Name}");
            Console.WriteLine($"[COPY] Agency City: {agentCopy.AssignedAgency.City}");
        }
    }

    public class Agent
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public Agency AssignedAgency { get; set; }

        public Agent(string name, long id, Agency assignedAgency)
        {
            Name = name;
            Id = id;
            AssignedAgency = assignedAgency;
        }

        public class Agency
        {
            public string Name { get; set; }
            public string City { get; set; }

            public Agency(string name, string city)
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
            var result = new Agent(agent.Name, agent.Id, new Agent.Agency(agent.AssignedAgency.Name, agent.AssignedAgency.City));
            return result;
        }
    }
}
