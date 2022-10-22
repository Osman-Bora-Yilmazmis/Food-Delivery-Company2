using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProje2
{
    class MahalleSınıfı //MAHALLE SINIFIM
    {
        public string MahalleAdi;
        public List<TeslimatSinif> teslimatlar = new List<TeslimatSinif>();

        public MahalleSınıfı(string mahalleadi)
        {
            this.MahalleAdi = mahalleadi;     
        }
    }
    
    class TeslimatSinif //TESLIMAT SINIFIM
    {
        public string yemek;
        public int yemeksayisi;

        public TeslimatSinif(string yemek , int yemeksayisi)
        {
            this.yemek = yemek;
            this.yemeksayisi = yemeksayisi;
        }
    }
    class ÖncelikliKuyruk //PQ SINIFIM
    {
        List<MahalleSınıfı> mahalleler = new List<MahalleSınıfı>(); 
        public ÖncelikliKuyruk(){}
        
        public ÖncelikliKuyruk(ArrayList Arrayliste)
        {
            for(int i = 0; Arrayliste.Count > i; i++)
            {
                mahalleler.Add((MahalleSınıfı)Arrayliste[i]);
            }
            
        }
        public bool BosMu()
        {
            if (mahalleler.Count == 0)
            {
                return true;
            }
                return false;
        }
        public void ElemanEkle(MahalleSınıfı mahalle)
        {
            mahalleler.Add(mahalle);

        }
        public MahalleSınıfı ElemanSil()
        {
            int max = 0;
            MahalleSınıfı mahalleadi = mahalleler[0];
            for(int i = 0; mahalleler.Count>i; i++)
            {
                if(mahalleler[i].teslimatlar.Count > max)
                {
                    mahalleadi = mahalleler[i];
                    max = mahalleler[i].teslimatlar.Count;
                }

            }
            mahalleler.Remove(mahalleadi);
            return mahalleadi;
        }
    }
    class Program
    {
        static Random Rastgele = new Random(); //RANDOM METODU
        static string[] yemeklerim = {"nohutlu tavuk", "dana rosto", "spagetti ", "yoğurtlu makarna","bulgur pilavı", "pilav","salçalı tavuk","hatay dürüm","izmir kumrusu","küfte","mantı","hotdog" ,"Sucuklu Şahanem"};
        static void Main(string[] args)
        {
            
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Merhaba");

            //ARRAY BÖLÜMÜ
            string[] MahalleAdı = { "Özkanlar", "Evka 3", "Atatürk","Erzene", "Kazımdirik", "Mevlana", "Doğanlar", "Ergene" }; //MAHALLE DİZİSİ
            int[] TeslimatSayısı = { 5, 2, 7, 2, 7, 3,0, 1 }; //TESLİMAT SAYİSİ DİZİSİ
            ArrayList Moto_Kurye = new ArrayList();
            Console.WriteLine(" ");
            Console.WriteLine("ARRAYLE OLUSTURULAN BÖLÜM");
            for (int i = 0; MahalleAdı.Length> i; i++)
            {
                MahalleSınıfı Mahalle = new MahalleSınıfı(MahalleAdı[i]);
             
                for(int q = 0; TeslimatSayısı[i]> q; q++)
                {
                    string rastgeleyemek = yemeklerim[Rastgele.Next(0, yemeklerim.Length)]; //YEMEKLERİM LİSTESİNDEN RASTGELE YEMEKLER OLUŞTURULUR
                    int rastgeleyemeksayisi = Rastgele.Next(1,10); //YEMEKLERİN SAYISI İCİN RASTGELE YEMEK SAYİSİ OLSUTURULUR                       
                    TeslimatSinif Teslimat = new TeslimatSinif(rastgeleyemek,rastgeleyemeksayisi); //OLUSUTURULAN VERİLER TESLİMATSİNİFİ TİPİNDE TESLİMATA GÖNDERİLİR
                    Mahalle.teslimatlar.Add(Teslimat); //TESLİMAT OLUSTUKTAN SONRA İLGİLİ MAHALLEYE GÖNDERİLİR
                    

                }
                Moto_Kurye.Add(Mahalle); //DONGU BİTTİKTEN SONRA OLUSTURULAN MAHALLE MOTO_KURYE ARRAYINE GONDERİLİR
                Console.WriteLine(" ");
                Console.WriteLine(" Mahallenin Adi : " + Mahalle.MahalleAdi);
                
                for (int j = 0; Mahalle.teslimatlar.Count > j; j++)
                {
                    
                    TeslimatSinif teslimat = Mahalle.teslimatlar[j];
                    Console.WriteLine("gönderilen yemek ve sayisi: " + teslimat.yemek + " " + teslimat.yemeksayisi);
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine(" Mahalle Sayisi : " + Moto_Kurye.Count); //TOPLAM MAHALLE SAYISI BURADA YAZDILIR
            int sayac = 0;
            for (int i = 0; Moto_Kurye.Count > i; i++)
            {
                MahalleSınıfı mahalle = (MahalleSınıfı)Moto_Kurye[i];
                sayac += mahalle.teslimatlar.Count;

            }
            Console.WriteLine("Teslimat Sayimiz : " + sayac); //OLSUTURULAN TOPLAM TESLİMAT SAYiSİ BURADA YAZDIRILIR
            Console.ReadLine();

            //YIGIT BÖLÜMÜ
            Console.WriteLine(" ");
            Console.WriteLine("STACKLE OLUSTURULAN BÖLÜM");
            Stack<MahalleSınıfı> Yığıt = new Stack<MahalleSınıfı>(); //MAHALLESINIFI TİPİNDE STACK OLUŞTURULUR
            for (int i = 0; Moto_Kurye.Count > i; i++)
            {
                Yığıt.Push((MahalleSınıfı)Moto_Kurye[i]);//OLUSTURULAN STACK LİSTESİNE MAHALLELERİN BİLGİLERİ EKLENİR
                
            }
            
            while(Yığıt.Count != 0)
            {
                MahalleSınıfı mahalle = Yığıt.Pop(); //STACKTEN İLGİLİ MAHALLE ÇIKARILIR VE DÖNDÜRÜLÜR
                Console.WriteLine(" ");
                Console.WriteLine(" Mahallenin Adi : " + mahalle.MahalleAdi);
                for ( int i = 0; mahalle.teslimatlar.Count > i; i++)
                {
                    TeslimatSinif teslimat = mahalle.teslimatlar[i];
                    Console.WriteLine("gönderilen yemek ve sayisi: " + teslimat.yemek + " " + teslimat.yemeksayisi);//ÇIKARILAN MAHALLENİN BLGİLERİ YAZDIRILIR
                }
                
                
            }
            //KUYRUK BÖLÜMÜ
            Console.WriteLine(" ");
            Console.WriteLine("KUYRUKLA OLUSTURULAN BÖLÜM");
            Queue<MahalleSınıfı> Kuyruk = new Queue<MahalleSınıfı>(); //MAHALLE SINIFI TİPİNDE KUYRUK YAPISI OLUŞTURULUR
            for (int i = 0; Moto_Kurye.Count > i; i++)
            {
                Kuyruk.Enqueue((MahalleSınıfı)Moto_Kurye[i]);//OLUSTURULAN KUYRUK YAPISINA MAHALLELERİN BİLGİLERİ EKLENİR 

            }

            while (Kuyruk.Count != 0)
            {
                MahalleSınıfı mahalle = Kuyruk.Dequeue();//KUYRUKTAN İLGİLİ MAHALLE ÇIKARILIR VE DÖNDÜRÜLÜR
                Console.WriteLine(" ");
                Console.WriteLine(" Mahallenin Adi : " + mahalle.MahalleAdi);//DÖNDÜRÜLEN MAHALLE YAZDIRILIR
                for (int i = 0; mahalle.teslimatlar.Count > i; i++)
                {
                    TeslimatSinif teslimat = mahalle.teslimatlar[i];
                    Console.WriteLine("gönderilen yemek ve sayisi: " + teslimat.yemek + " " + teslimat.yemeksayisi);//TESLİMAT BİLGİLERİ YAZDIRILIR
                }
                
            }
            Console.ReadLine();

            // PQ BÖLÜMÜ
            Console.WriteLine(" ");
            Console.WriteLine("PQ OLUSTURULAN BÖLÜM");
            ÖncelikliKuyruk OncelikliKuyruk = new ÖncelikliKuyruk(); // PQ BURADA OLUSTURULUR 
            for (int i = 0; Moto_Kurye.Count > i; i++)
            {
                OncelikliKuyruk.ElemanEkle((MahalleSınıfı)Moto_Kurye[i]);//PQ YA BURADA MAHALLE BİLGİLERİ EKLENİR
            }
            while (!OncelikliKuyruk.BosMu())
            {
                MahalleSınıfı mahalle = OncelikliKuyruk.ElemanSil(); //PQ DAN ELEMAN ÇIKARILIR VE DÖNDÜRÜLÜR
                Console.WriteLine(" ");
                Console.WriteLine(" Mahallenin Adi : " + mahalle.MahalleAdi);//ÇIKARILAN ELEMAN YAZDIRILIR
                for (int i = 0; mahalle.teslimatlar.Count > i; i++)
                {
                    TeslimatSinif teslimat = mahalle.teslimatlar[i];
                    Console.WriteLine("gönderilen yemek ve sayisi: " + teslimat.yemek + " " + teslimat.yemeksayisi);//DAHA SONRA TESLIMAT BİLGİLERİ YAZDIRILIR
                }
                
            }
            Console.ReadLine();












        }
    }
}
