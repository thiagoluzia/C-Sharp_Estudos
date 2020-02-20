using System;
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

            //CalculoArea.Calcular();

            //CalculoAreaCorreto.Calcular();
        }
    }
}