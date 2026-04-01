namespace CalculadoraMVCGenMar.Models
{
    public class CalculadoraModel
    {
        public double Numero1 { get; set; }
        public double Numero2 { get; set; }
        public string Operacion { get; set; }
        public double? Resultado { get; set; }

        public void Calcular()
        {
            switch (Operacion)
            {
                case "suma":
                    Resultado = Numero1 + Numero2;
                    break;
                case "resta":
                    Resultado = Numero1 - Numero2;
                    break;
                case "multiplicar":
                    Resultado = Numero1 * Numero2;
                    break;
                case "dividir":
                    Resultado = Numero2 != 0 ? Numero1 / Numero2 : null;
                    break;
                case "potencia":
                    Resultado = Math.Pow(Numero1, Numero2);
                    break;
                case "raiz":
                    Resultado = Numero1 >= 0 ? Math.Sqrt(Numero1) : null;
                    break;
                case "log":
                    Resultado = Numero1 > 0 ? Math.Log10(Numero1) : null;
                    break;
                case "seno":
                    Resultado = Math.Sin(Numero1);
                    break;
                case "coseno":
                    Resultado = Math.Cos(Numero1);
                    break;
                case "tangente":
                    Resultado = Math.Tan(Numero1);
                    break;
                case "factorial":
                    Resultado = Factorial((int)Numero1);
                    break;
            }
        }

        private int Factorial(int n)
        {
            if (n < 0) return 0;
            int res = 1;
            for (int i = 1; i <= n; i++)
                res *= i;
            return res;
        }
    }
}