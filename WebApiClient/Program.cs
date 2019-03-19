using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Program nesne = new Program();
            nesne.getMethod().Wait();
            nesne.postMethod().Wait();
            nesne.putMethod().Wait();
            nesne.deleteMethod().Wait();

            Console.ReadLine();
        }

        private async Task getMethod()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56466/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GET Method  
                HttpResponseMessage response = await client.GetAsync("v1/NotGoster/1");
                if (response.IsSuccessStatusCode)
                {
                    var bilgi = await response.Content.ReadAsAsync<OgretmenVeOgrenciBilgi>();
                    Console.WriteLine("Id:{0}\tOgrenciNo:{1}", bilgi.Id, bilgi.OgrenciNo);
                }
                else
                {
                    Console.WriteLine("Hata");
                }
            }
        }

        private async Task postMethod()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56466/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //POST Method  
                OgretmenVeOgrenciBilgi bilgi = new OgretmenVeOgrenciBilgi() {
                    Id = 1,
                    OgretmenKullaniciAdi = "Caner",
                    Sifre = "Test",
                    OgrenciNo = "12345",
                    OgrenciSinif = "12",
                    OgrenciSube = "B",
                    DersNotlari = new NotBilgisi[] { new NotBilgisi {Ders = "Metamatik",Not="99" } }
                };
                HttpResponseMessage response = await client.PostAsJsonAsync("v1/NotEkle", bilgi);

                if (response.IsSuccessStatusCode)
                {  
                    var sonucMesaji = await response.Content.ReadAsAsync<string>();
                    Console.WriteLine(sonucMesaji);
                }
            }
        }

        private async Task putMethod()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56466/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //PUT Method  
                OgretmenVeOgrenciBilgi bilgi = new OgretmenVeOgrenciBilgi()
                {
                    Id = 1,
                    OgretmenKullaniciAdi = "Caner",
                    Sifre = "Test",
                    OgrenciNo = "123456",
                    OgrenciSinif = "12",
                    OgrenciSube = "B",
                    DersNotlari = new NotBilgisi[] { new NotBilgisi { Ders = "Metamatik", Not = "99" } }
                };
                HttpResponseMessage response = await client.PutAsJsonAsync("v1/BilgiGuncelle", bilgi);
                if (response.IsSuccessStatusCode)
                {
                    var sonucMesaji = await response.Content.ReadAsAsync<string>();
                    Console.WriteLine(sonucMesaji);
                }
            }
        }

        private async Task deleteMethod()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56466/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //DELETE Method  
                int bilgiId = 1;
                HttpResponseMessage response = await client.DeleteAsync("v1/NotSil/" + bilgiId);
                if (response.IsSuccessStatusCode)
                {
                    var sonucMesaji = await response.Content.ReadAsAsync<string>();
                    Console.WriteLine(sonucMesaji);
                }
            }
        }



    }
    public class OgretmenVeOgrenciBilgi
    {
        public int Id { get; set; }

        public OgretmenVeOgrenciBilgi()
        {

        }
        public OgretmenVeOgrenciBilgi(string ogretmenKullaniciAdi, string sifre, string ogrenciNo, string ogrenciSinif, string ogrenciSube, NotBilgisi[] dersNotlari)
        {
            OgretmenKullaniciAdi = ogretmenKullaniciAdi;
            Sifre = sifre;
            OgrenciNo = ogrenciNo;
            OgrenciSinif = ogrenciSinif;
            OgrenciSube = ogrenciSinif;
            DersNotlari = dersNotlari;
        }
        public string OgretmenKullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string OgrenciNo { get; set; }
        public string OgrenciSinif { get; set; }
        public string OgrenciSube { get; set; }
        public NotBilgisi[] DersNotlari { get; set; }
    }
    public class NotBilgisi
    {
        public NotBilgisi() { }
        public NotBilgisi(string ders, string not)
        {
            Ders = ders;
            Not = not;
        }
        public string Ders { get; set; }
        public string Not { get; set; }
    }
}
