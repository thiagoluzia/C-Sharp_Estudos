using System;
using CSharpOO.SOLID.OCP.Solucao;
using CSharpOO.SOLID.SRP.Solucao;

namespace CSharpOO.SOLID
{
    public class Program
    {
        private static void Main()
        {
            #region Thiago - SRP - Solução
            Usuario user = new Usuario()
            {
                Codigo = 15,
                CPF = "15778847854",
                DataNascimento = new DateTime(1989, 08, 23),
                Email = "thiago.mouraluzia@gmail.com",
                Nome = "Thiago Moura"
            };

            UsuarioService usuarioService = new UsuarioService();
            usuarioService.AdicionarUsuario(user);
            #endregion
            
            #region Thiago OCP Solução
            Conta contaCorrente = new ContaCorrente()
            {
                Agencia = 0380,
                NumeroConta = 0288345,
                Saldo = 0
            };
            contaCorrente.Depositar(150m, "Thiago Moura");
            contaCorrente.Sacar(100m, "Thiago Moura");


            Conta contaPoupanca = new ContaPoupanca()
            {
                Agencia = 0010,
                NumeroConta = 0000045,
                Saldo = 0
            };
            contaPoupanca.Depositar(500m, "Alesandra Campos");
            contaPoupanca.Sacar(250m, "Alesandra Campos");
            #endregion


            //CalculoArea.Calcular();

            //CalculoAreaCorreto.Calcular();
            Console.ReadKey();
        }
    }
}