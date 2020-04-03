using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Targ_masini
{
    class Program
    {
        public static int[] firme = new int[10];
        public static int countl=0;
        /*for(int j=0;j<10;j++)
        {
            modele[j]=0;
        }*/
        public static int i = 0;
        static void Main(string[] args)
        {
            for (int j = 0; j < 10; j++)
            {
                firme[j] = 0;
            }
            Masina m1 = new Masina(),m2=new Masina();
            m1.afisare();
            string data = Masina.RText();
            string[] lista = data.Split('/');
            int _firma,_an;
            double _model, _pret;
            //Console.WriteLine("S-a citit din fisier : " + data);
            _pret = Convert.ToDouble(lista[4]);
            _model = Convert.ToDouble(lista[0]);
            _firma = Convert.ToInt32(lista[1]);
            _an = Convert.ToInt32(lista[3]);
            m2 = new Masina(_model,_firma,lista[2],_an,_pret,lista[5],lista[6]);
            Console.WriteLine("La citirea fisierului rezulta :" + m2.ConversieLaSir());
            Menu();

        }
        static void Menu()
        {
            Masina[] masini = new Masina[50];
            for(int j=0;j<50;j++)
            {
                masini[j] = new Masina();
            }
            int c,fi;
            string menu = "\nC :Adauga automobile\nA :Afiseaza automobile disponibile\nD Gaseste masini in functie de firma\nT :Afiseaza modelul cel mai cautat\nG :Grafic preturi pe o anumita zi\nZ :Tranzactii intr-o anumita zi\nS :Conversie la sir/se va scrie in fisier\nI :Info\nX :Exit";
            Console.WriteLine(menu);
            do
            {

                string op = Console.ReadLine();
                op = op.ToLower();
                switch (op)
                {
                    case "c":
                        {
                            
                            Console.WriteLine("Introduceti numarul de masini pe care doriti sa le adaugati");
                            c = Convert.ToInt32(Console.ReadLine());
                           
                            for (int j=0;j<c;j++)
                            {
                                Console.WriteLine("Introduceti firma \n1- Necunoscuta\n2- Citroen\n3- Suzuki\n4- Honda\n5- Fiat\n6- Volkswagen\n7- BMW\n8- Toyota\n9- Dacia\n10- Ford\n");
                                fi = Convert.ToInt32(Console.ReadLine());
                                masini[j].setmodel();
                                if (fi > 9 || fi < 0)
                                {
                                    Console.WriteLine("Introduceti o valoare din cele prezentate");
                                    fi = Convert.ToInt32(Console.ReadLine());
                                }
                                masini[j].setfirma(fi);
                                firme[fi-1] = firme[fi] + 1;
                                Console.WriteLine();
                                Console.Write("Indicii curenti ai firmelor :");
                                for (int k = 0; k < 10; k++)
                                {
                                    Console.Write(firme[k]);
                                }
                                masini[j].setculoare();
                                masini[j].setan();
                                masini[j].setpret();
                                masini[j].setdatat();
                                masini[j].setop();
                                i++;
                            }
                            Console.ReadKey();
                            Console.WriteLine(i + " masini adaugate");
                            break;
                        }
                    case "a":
                        {
                            try
                            {
                                for (int j = 0; j < i; j++)
                                {
                                    masini[j].afisare();
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Nici o masina inregistrata cu parametrii");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "t":
                        {
                            Console.WriteLine("\nFirma ce mai cautata este :" + (Firme)Max());
                            Console.ReadKey();
                            break;
                        }
                    case "s":
                        {
                            for (int j = 0; j < i; j++)
                            {
                                Console.WriteLine(masini[j].ConversieLaSir());
                                Masina.Text();
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "g":
                        { 
                            //Nu este completat momentan
                            Console.ReadKey();
                            break;
                        }
                    case "z":
                        {
                            int z, l, a,ok=0;
                            Console.WriteLine("Introduceti ziua");
                            z = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Introduceti luna");
                            l = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Introduceti anul");
                            a = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("S-au gasit :");
                            for (int j=0;j<i;j++)
                            {
                                if (z == masini[j].getdataz() && l == masini[j].getdatal() && a == masini[j].getdataa());
                                {
                                    ok = 1;
                                    masini[j].afisare();
                                }
                            }
                            if(ok==0)
                            {
                                Console.Write("0 masini cu aceasta data de tranzactie");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "d":
                        {
                            Console.WriteLine("Introduceti firma pe care o cautati\n1- Necunoscuta\n2- Citroen\n3- Suzuki\n4- Honda\n5- Fiat\n6- Volkswagen\n7- BMW\n8- Toyota\n9- Dacia\n10- Ford\n");
                            fi = (Convert.ToInt32(Console.ReadLine())-1);
                            string comp = " ";
                            comp += (Firme)fi;
                            Console.WriteLine("\nMasini gasite :");
                            for (int j=0; j < i; j++)
                            {
                                if (masini[j].Tostringf()==comp)
                                {
                                    int l;
                                    Console.WriteLine(masini[j].ConversieLaSir());
                                    Console.WriteLine("In ce doriti sa schimbati firma");
                                    l = Convert.ToInt32(Console.ReadLine());
                                    masini[j].setfirma(l);
                                    Console.WriteLine("Dupa schimbare "+masini[j].ConversieLaSir());

                                }
                            }
                            Console.ReadKey();
                            break;

                        }
                    case "i":
                        {
                            Console.WriteLine("Proiect realizat de Ionut Taran");
                            Console.ReadKey();
                            break;
                        }
                    case "x":
                        return;
                }
                Console.WriteLine("\nAlege o optiune");
            } while (true);
        }
        static int Max()
        {
            int max = 0;
            for (int j = 0; j < 10; j++)
            {
                if (max < firme[j])
                {
                    max = j;
                }
            }
            return max;
        }
    }
}
