using System;
using System.Collections;

namespace proje1deneme1
{
    class Program
    {
        public static double GetRandomNumber(double minimum, double maximum) //alt ve üst sınırlarını alıp rast gele double tipinde sayı döndüren metod.
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;// bunu bu şekilde yapmamızın sebebi nextDouble metodu 0 ila 1 arasında rastgele double üretiyor.
        }
        public static void Print2DArray<T>(T[,] matrix) // 2 boyutlu listeyi yazdıran metod.
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static double uzaklikBul(double x1, double y1, double x2, double y2) // parametre olarak gelen iki noktanın x ve y değelerini alıp öklide göre uzaklık bulan metod.
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2)); //math.pow farkların karesini alır math.sqrt ise karekökünü alır.
        }


        static double[,] UzaklıkMatrisiDondur(Double[,] liste) // parametre olarak listeyi aldıktan sonra uzaklık matrixini döndüren metod.
        {
            double[,] dm_matris = new double[liste.Length / 2, liste.Length / 2]; // gelen liste büyüklüğünde yeni liste ürettim.
            for (int i = 0; i < liste.Length / 2; i++) // iç içe for döngüsü ile listenin elemanlarını tek tek alıp diğer elemanlar ile uzaklıklarını karşılaştırdım.
            {
                for (int j = 0; j < liste.Length / 2; j++)
                {

                    dm_matris[i, j] = Math.Round(uzaklikBul(liste[i, 0], liste[i, 1], liste[j, 0], liste[j, 1]), 2);// uzaklık bul metodu ile uzaklık hesaplanıp arraye atılıyor.
                }
            }
            Console.WriteLine("Uzaklık matrixi yazdırılıyor:");
            Print2DArray(dm_matris);
            return dm_matris;

        }

        static bool elemankontrol(ArrayList liste, int a) // arraylist.contains methodu ne yazıkki düzgün çalışmadı sanırım objeyle int karşılaştırtıp sürekli false döndürdü bu yüzden kendi eleman kontrol metodumu yazdım.
        {
            int s;
            foreach (var item in liste)
            {
               s=  Convert.ToInt32(item); // casting yaparak arraylisteki nesneyi integera çevirdim.
                if (a == s)
                {
                    return true; 
                }
                else
                {
                    continue;
                }
            }
            return false;
        }

        static void enYakinKomsu(Double[,] liste, int baslangicNumara)
        {
            ArrayList gidilen_noktalar = new ArrayList(); //gidilen noktaları tutmak için oluşturulmuş arraylist.
            double uzaklik, total_mesafe = 0;
            int element_index = 0;
            gidilen_noktalar.Add(baslangicNumara); // gidilen noktalara başlangıç numarası eklendi.
            for (int t = 0; t < (liste.Length / 2)-1; t++)
            {
                double en_yakin_deger = 1000000.2;
                for (int a = 0; a < liste.Length / 2; a++)
                {
                    if (elemankontrol(gidilen_noktalar, a)) // eğer gidilen_noktalar arraylistinde o nokta var ise çıkılacak.
                    {
                        continue;
                    }
                    else
                    {
                        uzaklik = uzaklikBul(liste[baslangicNumara, 0], liste[baslangicNumara, 1], liste[a, 0], liste[a, 1]);
                        if (uzaklik < en_yakin_deger)
                        {
                            element_index = a;
                            en_yakin_deger = uzaklik;
                        }
                    }
                }
                total_mesafe += en_yakin_deger;
                gidilen_noktalar.Add(element_index);
                baslangicNumara = element_index; // son gidilen noktadan devam edicek.
            }

            Console.WriteLine("Gidilen noktalar(İlk nokta başlangıç olmak üzere):");
            foreach (var item in gidilen_noktalar)
            {
                Console.Write("-" +item);
            }
            Console.WriteLine();
            Console.WriteLine("Gidilen toplam mesafe:");
            Console.WriteLine(total_mesafe = Math.Round(total_mesafe,2));    
        }



        static void Main(string[] args)
        {
            Random random = new Random();

            int n = 20, width = 100, height = 100;
            int elliBuyukluk = 50;
            ArrayList baslanacak_noktalar_liste = new ArrayList();

            double[,] noktaListe = new double[n, 2]; //Burada iki boyutlu arrayimi oluşturdum içine noktaların x ve y düzlemindeki yerlerini atacağım.
            double[,] noktaListe50 = new double[elliBuyukluk, 2];

            for (int i = 0; i < n; i++) // Bu for döngüsü widht ve height değerleri için random bir değer oluşturup atıyor.
            {
                double value_width = GetRandomNumber(0, width);   //verilen width değerine göre random ürettim
                double value_height = GetRandomNumber(0, height);//verilen height değerine göre random ürettim
                value_width = Math.Round(value_width, 2); // random double ların virgülden sonra son iki basamağını yuvarladım.
                value_height = Math.Round(value_height, 2);
                noktaListe[i, 0] = value_width; // listeye noktaları teker teker ekledim.
                noktaListe[i, 1] = value_height;
            }

            for (int i = 0; i < elliBuyukluk; i++) // Bu for döngüsü widht ve height değerleri için random bir değer oluşturup atıyor.
            {
                double value_width = GetRandomNumber(0, width);   //verilen width değerine göre random ürettim
                double value_height = GetRandomNumber(0, height);//verilen height değerine göre random ürettim
                value_width = Math.Round(value_width, 2); // random double ların virgülden sonra son iki basamağını yuvarladım.
                value_height = Math.Round(value_height, 2);
                noktaListe50[i, 0] = value_width; // listeye noktaları teker teker ekledim.
                noktaListe50[i, 1] = value_height;
            }

            Console.WriteLine("50 noktalı matrixin noktaları:");
            Print2DArray(noktaListe50);
            Console.WriteLine("**********************************************************************");
            


            Console.WriteLine("20 Noktalı matrixin  noktaları ve değerleri:");
            Print2DArray(noktaListe);
            UzaklıkMatrisiDondur(noktaListe);

            // rastgele nokta seçme
            while (baslanacak_noktalar_liste.Count != n/2) // burada rastgele olarak 10 eleman seçmek için(20 uzunluklu listeden) bir while döngüsü var.
            {
                int a = random.Next(0, n); // burada rastgele (max sayı arrayin uzunluğu olmak üzere) integer üretiliyor.
                if (elemankontrol(baslanacak_noktalar_liste, a)) // eğer rastgele seçilen nokta zaten arraylistte var ise bu if e giriyor ve ekleme olmuyor.
                {
                    continue;
                }
                else //eğer rastgele üretilen eleman arraylistte yok ise ekleme işlemi gerçekleşiyor. istenilen kapasite dolana kadar bu işlem devam ediyor.
                {
                    baslanacak_noktalar_liste.Add(a);
                }

            }

           
            for (int i = 0; i < n/2; i++)
            {
                int sayi = Convert.ToInt32(baslanacak_noktalar_liste[i]); // arraylist in içindeki integer a erişebilmek için downcasting.
                Console.WriteLine("****************************************************************");
                enYakinKomsu(noktaListe,sayi);
                Console.WriteLine("****************************************************************");
            }


        }
    }
}
