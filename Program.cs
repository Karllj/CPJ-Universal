using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using CPJ_Universal.janelas; // Importa o namespace correto

namespace CPJ_Universal
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Adiciona o manipulador para resolução de assemblies
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new menu()); // Agora 'menu' pode ser encontrado
        }

        // Manipulador para localizar DLLs em subpastas
        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            // Define o caminho para a pasta "DLLs"
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DLLs");
            string assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");

            // Tenta carregar o assembly se o arquivo existir
            if (File.Exists(assemblyPath))
            {
                return Assembly.LoadFrom(assemblyPath);
            }
            return null; // Retorna null se não encontrar o assembly
        }
    }
}
