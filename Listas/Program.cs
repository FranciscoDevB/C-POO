using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Runtime.CompilerServices;

class Funcionario
{
    public int Id;
    public string Name;
    public double Salario { get; private set; }
    
    public Funcionario(int id, string name, double salario)
    {
        this.Id= id;
        this.Name = name;
        this.Salario = salario;
    }

    public void AumentoSalario( double porcentagem)
    {
        this.Salario += Salario * (porcentagem/100);
    }

    public override string ToString()
    {
        return $"{Id}, {Name}, {Salario:F2}";
    }
}

class Program
{
    static void Main()
    {
        System.Console.WriteLine();
        System.Console.WriteLine();
        Console.Write("Quantos funcionários serão registrados? ");
        int n = int.Parse(Console.ReadLine());

        List <Funcionario> list = new List<Funcionario>();
        //int [] v1 = new int [n];


        for(int i=0; i < n; i++)
        {
            System.Console.WriteLine($"Funcionário #{i + 1}:");
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Salary: ");
            double salary = double.Parse(Console.ReadLine());

            
        
            list.Add(new Funcionario(id, name, salary));
            System.Console.WriteLine();
        }

        Console.Write("Entre com o ID do funcionário que terá o salário aumentado: ");
        int idAumento = int.Parse(Console.ReadLine());

        Funcionario x = list.Find(x => x.Id == idAumento);
        if(x != null)
        {
             Console.Write("Entre com a porcentagem: ");
            double porcentagem = double.Parse(Console.ReadLine());
            x.AumentoSalario(porcentagem);
        }
        else
        {
            System.Console.WriteLine("Esse ID não esite!");
        }
        System.Console.WriteLine();
        System.Console.WriteLine("Atualização da lista de funcionários:");
        foreach(Funcionario pres in list)
        {
            System.Console.WriteLine(pres);
        }
        
    }

    
}