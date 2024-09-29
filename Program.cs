namespace Elmahdy_Csharp_Advacned
{
    public class Program
    {
        // declare delegate method
        delegate int CalculateDelegate(int num1, int num2);

        // declare delegate method
        delegate bool ShouldCalculate(Employee employee);

        public class Employee
        {
            public string Name { get; set; }
            public int BasicSalary { get; set; }
            public int Deductions { get; set; }
            public int Bonus { get; set; }

        }



        static void Main(string[] args)
        {
            List<Employee> employees = new();

            for (var i = 0; i < 100; i++)
            {
                employees.Add(new Employee
                {
                    Name = $"Employee {i}",
                    BasicSalary = Random.Shared.Next(10000, 100000),
                    Deductions = Random.Shared.Next(100, 1000),
                    Bonus = Random.Shared.Next(500, 20000)
                });
            }

            CalculateSalaries(employees, (s) => (s.BasicSalary <= 50000));

            Console.ReadKey();
        }

        private static void CalculateSalaries(List<Employee> employees,
            ShouldCalculate predicate)
        {
            foreach (Employee emp in employees)
            {
                if (predicate(emp))
                {
                    var salary = emp.BasicSalary + emp.Bonus - emp.Deductions;
                    Console.WriteLine($"Employee {emp.Name} with basic salary: {emp.BasicSalary}" +
                        $" his final salary: {salary}");
                }
            }

            static void PractiseDelegates()
            {
                int num1 = 10;
                int num2 = 4;
                Console.WriteLine("------------------");
                CalculateDelegate dlg = Add;

                // this called multitasking
                dlg += Subtract;
                dlg += Multiply;
                CalculateWithDelegate(num1, num2, dlg);
                Console.WriteLine("------------------");

                dlg -= Multiply;
                CalculateWithDelegate(num1, num2, dlg);
                Console.WriteLine("------------------\n\n");


                // call delegate method
                CalculateWithDelegate(num1, num2, Add);


                CalculateDelegate dlg2 = Add;
                CalculateWithDelegate(num1, num2, dlg2);

                CalculateWithDelegate(num1, num2,
                        delegate (int num1, int num2) { return num1 - num2; });


                CalculateWithDelegate(num1, num2,
                                (int num1, int num2) => num1 * num2);

                CalculateWithDelegate(num1, num2,
                                (num1, num2) => num1 / num2);

                // '%' Not Implmented like others
                CalculateWithDelegate(num1, num2, (x, y) => x % y);

                Console.WriteLine("\n\n");


                Calculate(num1, num2, '+');
                Calculate(num1, num2, '-');
                Calculate(num1, num2, '*');
                Calculate(num1, num2, '/');


            }
            // use delegate method with a function
            static void CalculateWithDelegate(int num1, int num2, CalculateDelegate dlg)
            {
                // call delegate parameters
                int result = dlg(num1, num2);

                Console.WriteLine($"Result: {result}");
            }
            static void Calculate(int num1, int num2, char op)
            {
                // Calculate
                // Print Result

                if (op == '+')
                    Console.WriteLine(Add(num1, num2));
                else if (op == '-')
                    Console.WriteLine(Subtract(num1, num2));
                else if (op == '*')
                    Console.WriteLine(Multiply(num1, num2));
                else if (op == '/')
                    Console.WriteLine(Divide(num1, num2));
            }
            static int Add(int num1, int num2)
            {
                Console.WriteLine("Add");
                return num1 + num2;
            }

            static int Subtract(int num1, int num2)
            {
                Console.WriteLine("Subtract");
                return num1 - num2;
            }
            static int Multiply(int num1, int num2)
            {
                Console.WriteLine("Multiply");
                return num1 * num2;
            }
            static int Divide(int num1, int num2)
            {
                Console.WriteLine("Divide");
                return num1 / num2;
            }

        }
    }
}
