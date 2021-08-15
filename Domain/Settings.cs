namespace Domain
{
    public static class Settings
    {
        public const int timeExpires = 5;

        public const string secret = "9a0a661691a34ea6a421e35616375e45";

        public const int passwordLength = 15;

        public const int repeatLength = 3;

        public const string lower = "abcdefghijklmnopqrstuvwxyz";

        public const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public const string numeros = "0123456789";

        public const string especiais = @"!@#_-";

        public const string permitido = lower + upper + numeros + especiais;
    }
}
