//Nerea Espinosa Calatayud
//Claudia Pérez Campoo

using System.Security.Cryptography;

namespace Hoja_1._2_ejercicio_2
{
    internal class Program
    {
        const int N = 100; // tamaño del vector de monomios

        struct Monomio
        {
            public double coef;
            public int exp;
        }
        struct Polinomio
        {
            public Monomio[] mon; // array de monomios
            public int nMon; // número de monomios
                             // último monomio en nMon=1
        }

        static void Main(string[] args)
        {

        }
        
        static bool EqDouble(double n1, double n2)
        {
            const double eps = 1*e - 15;
            return Math.Abs(n1 - n2)<eps;
             
        }


        static void Inserta(Monomio m, ref Polinomio p)
        {
            if (!EqDouble(m.coef, 0))
            {  // solo insertamos si coef!=0
                int i = 0;

                // busqueda de mon del mismo grado
                while (i < p.nMon && p.mon[i].exp < m.exp)

                    i++;
                int pos = i;

                if (pos < p.nMon)
                { // monomm njio encontrado
                  // sumo coefs
                  //hay mon del mismo grado
                    if (p.mon[pos].exp == m.exp)
                    {

                        double c = p.mon[i].coef + m.coef;

                        if (p.mon[pos].coef == 0)//si anulan coef elimino huevco
                        {
                            DesplazaIzq(ref p, pos);
                        }
                        else //abrid huevo
                        {
                            DesplazaDer(ref p, pos);
                                p.mon[pos] = m;
                        }
                    }

                }
                else
                { // añadimos m al final, si cabe
                    if (p.nMon == N) Console.WriteLine("error: polinomio lleno");
                    else
                    {
                        p.mon[p.nMon] = m;
                        p.nMon++;

                    }


                }
                static void DesplazaDer(ref Polinomio p, int pos)
                {

                    for (int i = p.nMon - 1; i >= pos; i--)
                    {
                        p.mon[i + 1] = p.mon[i];
                    }

                    p.nMon++;
                }

                static void DesplazaIzq(ref Polinomio p, int pos)
                {

                    for (int i = pos + 1; i <= p.nMon - 1; i++)
                    {
                        p.mon[i - 1] = p.mon[i];

                    }
                    p.nMon--;

                }
                //parte ordenados y otra desaordenad, ordenarla

            }
        }
    }
}