using System;
using System.Linq;
using System.Security.Cryptography;

namespace CPJ_Universal.classes
{
    internal static class criptografia
    {
        public static string GerarHash(string senha)
        {
            using (var derivator = new Rfc2898DeriveBytes(senha, GerarSalt(), 10000))
            {
                byte[] hash = derivator.GetBytes(32); // Gera um hash de 256 bits (32 bytes)
                byte[] salt = derivator.Salt;

                // Combina o salt e o hash em uma string para armazenar
                return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
            }
        }

        public static bool VerificarSenha(string senhaFornecida, string hashArmazenado)
        {
            var partes = hashArmazenado.Split(':');
            if (partes.Length != 2) return false;

            byte[] salt = Convert.FromBase64String(partes[0]);
            byte[] hashArmazenadoBytes = Convert.FromBase64String(partes[1]);

            using (var derivator = new Rfc2898DeriveBytes(senhaFornecida, salt, 10000))
            {
                byte[] hashCalculado = derivator.GetBytes(32);
                return hashCalculado.SequenceEqual(hashArmazenadoBytes);
            }
        }

        private static byte[] GerarSalt()
        {
            var salt = new byte[16]; // 128 bits de salt
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}
