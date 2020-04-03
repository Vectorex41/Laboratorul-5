using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Targ_masini
{
    

    public class Masina
    {
        public double model;
        public Firme firma{ get; set; }
        public string culoare;
        public int an;
        public double pret;
        public int [] datat=new int[3];
        public string [] optiuni=new string [11];
        public static string[] text = new string[100];
        public static int count=0;
        public Masina()
        {
            pret = 0;
            an = 0;
            model = 0;
            firma = Firme.Necunoscuta;
            culoare = "necunoscuta";
            datat[0] = 0;
            datat[1] = 0;
            datat[2] = 0;
            for (int j = 0; j < 10; j++)
            {
                optiuni[j] = string.Empty;
            }
        }
        public Masina(double _model, int _firma, string _culoare, int _an, double _pret, string _data, string _optiuni)
        {
            this.model = _model;
            this.firma = (Firme)_firma;
            this.culoare = _culoare;
            this.an = _an;
            this.pret = _pret;
            string[] data = _data.Split(',');
            this.datat[0] = Convert.ToInt32(data[0]);
            this.datat[1] = Convert.ToInt32(data[1]);
            this.datat[2] = Convert.ToInt32(data[2]);
            data = _optiuni.Split(',');
            for(int j=0;j<data.Length;j++)
            {
               
                    if (data[j] != string.Empty)
                    {
                        this.optiuni[j] = data[j];
                    }
               
            }
        }
        public void afisare()
        {

            Console.WriteLine("Masina model {0},culoare {1}, an {2} , pret {3}, datat {4} {5} {6}, firma {7}", model, culoare, an, pret, datat[0],datat[1],datat[2], (Firme)firma);
            Console.Write("Optiuni valabile: ");
        }
        public double getpret() { return pret; }
        public int getan() { return an; }
        public int getdataz() { return datat[0]; }
        public int getdatal() { return datat[1]; }
        public int getdataa() { return datat[2]; }
        public double getmodel() { return model; }
        public  void setmodel()
        {
            Console.WriteLine("\nintroduceti numarul de model");
            model = Convert.ToDouble(Console.ReadLine());
        }
        public  void setfirma(int fir)
        {
            firma = (Firme)fir;
        }
        public  void setculoare()
        {
            Console.WriteLine("\nIntroduceti culoarea :");
            culoare = Console.ReadLine();
        }
        public  void setan()
        {
            Console.WriteLine("\nIntroduceti anul de fabricare:");
            an =Convert.ToInt32(Console.ReadLine());
        }
        public  void setpret()
        {
            Console.WriteLine("\nIntroduceti pretul $:");
            pret = Convert.ToDouble(Console.ReadLine());
        }
        public  void setdatat()
        {
            Console.WriteLine("\nintroduceti data tranzactiei (zz,ll,aaaa) :");
            string lista = Console.ReadLine();
            string[] data = lista.Split(',');
            datat[0] = Convert.ToInt32(data[0]);
            datat[1] = Convert.ToInt32(data[1]);
            datat[2] = Convert.ToInt32(data[2]);
        }
        public  void setop()
        {
            Console.WriteLine("\nintroduceti nr de optiuni valabile(max 10) si optiunile cu , :");
            int o = Convert.ToInt32(Console.ReadLine());
            for(int j=0;j<o;j++)
            {
                Console.Write("\nOptiunea nr." + (j+1)+" ");
                optiuni[j] = Console.ReadLine();
            }
        }
        public string Tostringf()
        {
            string buff = " ";
            buff +=(Firme)firma;
            return buff;
        }
        public string ConversieLaSir()
        {
            string buff=" ";
            buff += (Firme)firma;
            buff += " ";
            buff += this.model;
            buff += " ";
            buff += this.culoare;
            buff += " din anul ";
            buff += this.an;
            buff += " la un pret de ";
            buff += this.pret;
            buff += "$ Tranzactie efectuata pe ";
            buff += this.datat[0];
            buff += " ";
            buff += this.datat[1];
            buff += " ";
            buff += this.datat[2];
            buff += "\nOptiuni valabile :\n";
            if (optiuni[0] == string.Empty)
            {
                buff += "NU exista optiuni pentru aceasta masina";
            }
            else
            {
                for (int j = 0; j < optiuni.Length; j++)
                {
                   
                       if (optiuni[j] != string.Empty)
                       {
                           buff += "-";
                           buff += optiuni[j];
                           buff += "\n";
                       }
                 
                }
            }
            text[count++] = buff;
            return buff;
        }
        public static void Text()
        {
            System.IO.File.WriteAllLines(@"C:\Users\ionut\Desktop\Masini\Targ masini\Targ masini\text.txt", text);
        }
        public static string RText()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\ionut\Desktop\Masini\Targ masini\Targ masini\rtext.txt");
            return text;
        }
    }
}