using System;
using System.Collections.Generic;
using System.Text;


namespace Lab2_ex2
{
    class Program
    {


        static void Main(string[] args)
        {
            Bank bank1 = new Bank("Приват24");
            bank1.create();
            bank1.create();
            bank1.getCredits();
            bank1.chooseCredit(0);
            Credit credit = bank1.getCredit();
            Console.WriteLine(credit.ToString());
            bank1.deleteCredit();
            bank1.getCredits();

        }
    }
    class Credit
    {
        private static int next_id = 0;
        public int id;           //iдентифікатор кредиту 
        private string purpose;  //ціль кредиту
        private double startsum; //потрібна сума 
        private double endsum;   //нарощена сума
        private double time;     //роки
        private string bankName; //Назва банку
        public int Id
        {
            get => this.id;
        }
        public double Startsum
        {
            get => this.startsum;

        }
        public double Endsum
        {
            get => this.endsum;
        }
        public double Time
        {
            get => this.time;
        }
        public Credit(string purpose, double time, double startsum, string bankName) //Створення кредиту
        {
            this.purpose = purpose;
            this.startsum = startsum;
            this.time = time;
            this.endsum = startsum * (1 + 0.13 * time); //Розрахунок кінцевої суми 
            this.id = next_id;
            next_id++;
            this.bankName = bankName;
        }

        public void Addsum(double money) 
        {
            Console.WriteLine("Вкажіть суму для збільшення кредитного ліміту: "); 
            this.startsum += money;
            this.endsum = startsum * (1 + 0.13 * time);
        }
        public void Addtime(double more)
        {
            Console.WriteLine("Вкажіть час продовження кредиту: ");
            if (more > 0)
            {
                this.time += more;
            }
            else Console.WriteLine("Невірний час!");
        }
        public override string ToString()
        {
            string str = String.Format("ціль: {0}; час: {1}; початкова сума: {2}; кінцева сума: {3}; ", this.purpose, this.time, this.startsum, this.endsum);
            return str;

        }
    }
    class Bank
    {
        public string name;
        private int currentCreditId;
        private List<Credit> credits = new List<Credit>();
        public Bank(string name)
        {
            this.name = name;
            this.currentCreditId = currentCreditId;
        }
        public void create()
        {
            Console.Write("Введіть ціль кредиту: ");
            string purpose = Console.ReadLine();
            Console.Write("Введіть термін кредиту: ");
            double time = Double.Parse(Console.ReadLine());
            Console.Write("Введіть початкову суму: ");
            double startsum = Double.Parse(Console.ReadLine());
            Credit credit = new Credit(purpose, time, startsum, this.name);
            Console.WriteLine("------------------------");
            credits.Add(credit);

        }

        public void chooseCredit(int id)
        {
            this.currentCreditId = id;
        }

        public Credit getCredit()
        {
            return credits.Find(credit => credit.id == this.currentCreditId);
        }
        public void getCredits()
        {
            for (int index = 0; index < credits.Count; index++)
            {
                Console.WriteLine(credits[index].ToString());
            }
        }


        public void deleteCredit()
        {
            credits.RemoveAll(credit => credit.id == currentCreditId);
        }
    }
}

