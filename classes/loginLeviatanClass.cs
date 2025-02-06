namespace CPJ_Universal.classes
{
    internal static class loginLeviatanClass
    {
        public static int SuperUsuario { get; private set; } = -1; // Inicialmente, nenhum usuário logado
        public static string Login { get; private set; } = string.Empty; // Nome do login do usuário logado

        public static void DefinirSuperUsuario(int super)
        {
            SuperUsuario = super;
        }

        public static void DefinirLogin(string login)
        {
            Login = login;
        }
    }
}



