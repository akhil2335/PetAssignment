using System;

class VirtualPet
{
    public string PetType { get; }
    public string Name { get; }

    public int Hunger { get; private set; } = 5;
    public int Happiness { get; private set; } = 5;
    public int Health { get; private set; } = 5;

    public VirtualPet(string petType, string name)
    {
        PetType = petType;
        Name = name;
    }

    public void DisplayStatus()
    {
        Console.WriteLine($"{Name} ({PetType}) - Hunger: {Hunger}/10, Happiness: {Happiness}/10, Health: {Health}/10");
    }

    public void Feed()
    {
        Hunger = Math.Max(0, Hunger - 2);
        Health = Math.Min(10, Health + 1);
        Console.WriteLine($"{Name} has been fed. Hunger decreased, and health increased.");
    }

    public void Play()
    {
        Happiness = Math.Min(10, Happiness + 2);
        Hunger = Math.Min(10, Hunger + 1);
        Console.WriteLine($"{Name} had fun playing. Happiness increased, but hunger slightly increased.");
    }

    public void Rest()
    {
        Health = Math.Min(10, Health + 2);
        Happiness = Math.Max(0, Happiness - 1);
        Console.WriteLine($"{Name} is resting. Health increased, but happiness slightly decreased.");
    }

    public void TimePasses()
    {
        Hunger = Math.Min(10, Hunger + 1);
        Happiness = Math.Max(0, Happiness - 1);

        if (Hunger <= 3)
        {
            Health = Math.Max(0, Health - 1);
            Console.WriteLine($"{Name} is getting hungry. Health may deteriorate if not fed.");
        }

        if (Happiness <= 3)
        {
            Console.WriteLine($"{Name} is feeling sad. Play with your pet to increase happiness.");
        }

        if (Health <= 3)
        {
            Console.WriteLine($"{Name}'s health is getting low. Make sure to take care of your pet!");
        }
    }

    public void CheckStatus()
    {
        if (Hunger >= 8)
        {
            Console.WriteLine($"Warning: {Name} is very hungry!");
        }
        else if (Hunger <= 2)
        {
            Console.WriteLine($"Warning: {Name} is full.");
        }

        if (Happiness <= 2)
        {
            Console.WriteLine($"Warning: {Name} is very unhappy!");
        }

        if (Health <= 2)
        {
            Console.WriteLine($"Warning: {Name}'s health is critical. Take action!");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Virtual Pet Care Simulator!");

        Console.Write("Choose a pet type (e.g., cat, dog, rabbit): ");
        string petType = Console.ReadLine();

        Console.Write("Give your pet a name: ");
        string petName = Console.ReadLine();

        VirtualPet pet = new VirtualPet(petType, petName);

        Console.WriteLine($"Welcome, {pet.Name} the {pet.PetType}!");

        while (true)
        {
            pet.DisplayStatus();

            Console.Write("Choose an action (feed/play/rest/quit): ");
            string action = Console.ReadLine().ToLower();

            switch (action)
            {
                case "feed":
                    pet.Feed();
                    break;
                case "play":
                    pet.Play();
                    break;
                case "rest":
                    pet.Rest();
                    break;
                case "quit":
                    Console.WriteLine("Thank you for playing!");
                    return;
                default:
                    Console.WriteLine("Invalid action. Please choose feed, play, rest, or quit.");
                    break;
            }

            pet.TimePasses();
            pet.CheckStatus();

            System.Threading.Thread.Sleep(1000);  // Simulate the passage of time (1 hour)
        }
    }
}
