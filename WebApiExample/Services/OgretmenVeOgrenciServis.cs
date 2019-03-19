using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Model;

namespace WebApiExample.Services
{
    public class OgretmenVeOgrenciServis : IOgretmenVeOgrenciServis
    {
        private readonly Dictionary<int, OgretmenVeOgrenciBilgi> _ogretmenVeOgrenciVeriler;

        public OgretmenVeOgrenciServis()
        {
            _ogretmenVeOgrenciVeriler = new Dictionary<int, OgretmenVeOgrenciBilgi>();
        }

        public string NotGir(OgretmenVeOgrenciBilgi veri)
        {
            if (!_ogretmenVeOgrenciVeriler.ContainsKey(veri.Id))
            {
                _ogretmenVeOgrenciVeriler.Add(veri.Id, veri);
                return "Kayıt başarılı";
            }
            else
                return veri.Id + " Numaralı kayıt bulunmaktadır!";
        }

        public Dictionary<int, OgretmenVeOgrenciBilgi> NotGoster()
        {
            return _ogretmenVeOgrenciVeriler;
        }

        public int NotSil(int id)
        {
            
            return _ogretmenVeOgrenciVeriler.RemoveAll((key, value) => key == id);
        }

        public OgretmenVeOgrenciBilgi SeciliNotGoster(int id)
        {
            return _ogretmenVeOgrenciVeriler.Where(x => x.Key == id).Select(n => n.Value).FirstOrDefault();
        }

        public string SubeninTumunuSil(string sube)
        {
            return _ogretmenVeOgrenciVeriler.SubeSil(value => value.OgrenciSube == sube);
        }

        public string BilgiGuncelle(OgretmenVeOgrenciBilgi veri)
        {
            if (_ogretmenVeOgrenciVeriler.ContainsKey(veri.Id))
            {
                _ogretmenVeOgrenciVeriler[veri.Id] = veri;
                return veri.Id + " Nolu id guncellendi";
            }
            else
            {
                return veri.Id + " Nolu id bulunamadı!";
            }
        }


    }
    public static class Extension
    {
        public static int RemoveAll<K, V>(this IDictionary<K, V> dict,Func<K,V,bool> match)
        {
            var dicKey = dict.Keys.ToArray().Where(key => match(key, dict[key])).Select(n=>n).FirstOrDefault();
            if(dicKey != null)
            {
                dict.Remove(dicKey);
                return 1;
            }
            return 0;
        }

        public static string SubeSil<K, V>(this IDictionary<K, V> dict, Func< V, bool> match)
        {
            string silinenIdler= "Silinen id numaraları : ";
            var list = dict.Keys.ToArray().Where(key => match(dict[key])).Select(n=>n);
            foreach (var key in list)
            {
                silinenIdler += dict.Where(x => x.Key.Equals(key)).Select(n => n.Key).FirstOrDefault() + ",";
                dict.Remove(key);
            }
            return silinenIdler;
        }
    }
}
