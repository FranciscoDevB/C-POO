using ExSeçao5;

using System;
using System.Collections.Generic;
using System.Text;

namespace ExSeçao5
{
    internal class Conta
    {

        public int Numero { get; private set; }
        public string Titular { get; set; }
        public double Saldo { get; private set; }
        public double Deposito { get; set; }
        public double Saque { get; set; }

        public Conta() { }
        public Conta(int numero, string titular, double saldo)
        {
            Numero = numero;
            Titular = titular;
            Saldo = saldo;
        }

        public void MostraDados()
        {
            Console.WriteLine("Dados da conta:");
            Console.WriteLine($"Conta {Numero}, Titular: {Titular}, Saldo: $ {Saldo:F2} ");
        }

        public void RealizaDeposito(double deposito)
        {
            Saldo += deposito;
        }

        public void Realizasaque(double saque)
        {
            Saldo -= (saque + 5);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Char inicial;
        double saldo;
        
        Console.Write("Entre o número da conta: ");
        int numero = int.Parse(Console.ReadLine());

        Console.Write("Entre o titular da conta: ");
        string titular = Console.ReadLine();

        Console.Write("Haverá depósito inicial (s/n)? ");
        inicial = char.Parse(Console.ReadLine());

        if (inicial == 's')
        {
            Console.Write("Entre o valor de depósito inicial: ");
            saldo = double.Parse(Console.ReadLine());
        }
        else
            saldo = 0;

        Conta C = new Conta(numero,titular, saldo );

        

        Console.WriteLine();
        C.MostraDados();
        Console.WriteLine();

        Console.Write("Entre um valor para depósito: ");
        C.Deposito = double.Parse(Console.ReadLine());

        C.RealizaDeposito(C.Deposito);
        Console.WriteLine("Dados Atualizados: ");
        C.MostraDados();
        Console.WriteLine();

        Console.Write("Entre um valor para saque; ");
        C.Saque = double.Parse(Console.ReadLine());

        C.Realizasaque(C.Saque);
        C.MostraDados();

    }
}
