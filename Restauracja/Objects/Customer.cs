using System;

namespace Restaurant.Objects
{
    public class Customer
    {
        private const double P1 = 0.11;
        private const double P2 = 0.33;
        private const double P3 = 0.33;

        public enum Choice { ToTables, ToBuffet }   //wybór czy do bufetu czy do stolika
        public Guid Id { get; set; }    //id grupy klientów
        public Choice Choice2 { get; set; }
        public int NumberOfPeople { get; set; }
        public bool FoodServe { get; set; }
        public Customer()
        {
            
            FoodServe = false;
            bool draw2 = Generators.UniformDistribution() >= 0.5;
            double draw = Generators.UniformDistribution();
            Id = Guid.NewGuid();
            if (draw < P1)
                NumberOfPeople = 1;
            if (draw >= P1 && draw < P1+P2)
                NumberOfPeople = 2;
            if (draw >=P1+P2 && draw < P1+P2+P3)
                NumberOfPeople = 3;
            if (draw >=P1+P2+P3 && draw <1)
                NumberOfPeople = 4;
            Choice2 = draw2 ? Choice.ToBuffet : Choice.ToTables;
        }
    }
}