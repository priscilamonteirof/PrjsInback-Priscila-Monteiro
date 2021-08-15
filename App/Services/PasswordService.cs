using App.Interfaces;
using Domain;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace App.Services
{
    public class PasswordService: IPasswordService
    {
        

        private bool disposedValue;

        public bool IsPasswordValid(object value)
        {
            if (value == null)
                return false;

            string identificacao = (string)value;
            if (  (string.IsNullOrWhiteSpace(identificacao))
               || (!HasMinimumLength(identificacao))
               || (!HasUpper(identificacao))
               || (!HasLower(identificacao)) 
               || (!HasSpecial(identificacao)) 
               || (HasRepeat(identificacao)) )
                return false;

            return true;
        }

        public string CreateNewPassword()
        {
            string senha = "";
            Random rnd = new();

            senha += Settings.lower[rnd.Next(1, Settings.lower.Length)].ToString();
            senha += Settings.upper[rnd.Next(1, Settings.upper.Length)].ToString();
            senha += Settings.numeros[rnd.Next(1, Settings.numeros.Length)].ToString();
            senha += Settings.especiais[rnd.Next(1, Settings.especiais.Length)].ToString();

            while (senha.Length < Settings.passwordLength)
                senha += Settings.permitido[rnd.Next(1, Settings.permitido.Length)].ToString();

            return Shuffle(senha);
        }

        private static bool HasMinimumLength(string senha)
        {
            return (senha.Length >= Settings.passwordLength);
        }
        
        private static bool HasUpper(string senha)
        {
            return senha.Any(c => char.IsUpper(c));
        }

        private static bool HasLower(string senha)
        {
            return senha.Any(c => char.IsLower(c));
        }

        private static bool HasSpecial(string senha)
        {
            Regex regex = new(@"[-@#_!]");
            return regex.IsMatch(senha);
        }

        private static bool HasRepeat(string senha)
        {
            var contador = 0;
            var ultimo = '\0';
            foreach (var c in senha)
            {
                if (c == ultimo)
                    contador++;
                else
                    contador = 0;
                if (contador == Settings.repeatLength)
                    return true;
                ultimo = c;
            }
            return false;
        }

        private static string Shuffle(string str)
        {
            char[] array = str.ToCharArray();
            Random rng = new();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
