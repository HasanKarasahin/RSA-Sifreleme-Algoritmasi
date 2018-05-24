using System;
using System.Collections.Generic;

namespace _040518_RSA
{
    class RSASifreleme
    {
       Form1 gui;
       public RSASifreleme(Form1 gui)
        {
            this.gui = gui;
            anahtarUretimi();
        }
        int e = 5, d = 29, n,lclear,lcipher;
        void anahtarUretimi()
        {
            int p, q, nu;
            p = 3;q = 37;
            n = p * q;
            nu = (p - 1) * (q - 1);
            //e = eBul(nu, new Random().Next(999, nu));
            //d = dBul(nu, e);

            lclear = n.ToString().Length - 1;
            lcipher = n.ToString().Length;
        }
        public String Sifreleme(String acikMetin)
        {
            int  tempSayac = 0;
            String ASCII = "", ASCIItemp = "", sifrelenenMetin = "";
            String[] lclearArray;
            foreach (Char harf in acikMetin)
            {
                ASCIItemp = Convert.ToInt32(harf).ToString();
                if (ASCIItemp.Length < 3)
                {
                    ASCIItemp = ("0" + ASCIItemp);
                }
                ASCII += ASCIItemp;
            }

            int kalan;
            Double bolum = Math.DivRem(ASCII.Length, lclear, out kalan), sonuc;
            if (kalan > 0)
                kalan = 1;
            sonuc = Math.Ceiling(Convert.ToDouble(bolum + kalan));

            lclearArray = new String[Convert.ToInt32(sonuc)];

            gui.txt_ascii.Text += ASCII.ToString();

            for (int i = 0; i < lclearArray.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (tempSayac >= ASCII.Length)
                        lclearArray[i] += "0";
                    else
                        lclearArray[i] += ASCII[tempSayac];
                    tempSayac++;
                }
            }
            foreach (String deger in lclearArray)
            {
                gui.txt_ascii0.Text += deger;
                String temp = sifreleFormul(Convert.ToInt32(deger)).ToString();
                gui.txt_sifrelemeSonuc.Text += temp;
                sifrelenenMetin += kural(temp,lcipher);
            }
            return sifrelenenMetin;
        }
        public String Desifreleme(String sifreliMetin)
        {
            int kalan, tempSayac = 0;
            Double bolum = Math.DivRem(sifreliMetin.Length, lcipher, out kalan), sonuc;
            if (kalan>0) kalan = 1;
            sonuc = Math.Ceiling(Convert.ToDouble(bolum + kalan));

            Double diziBoyutu = (sonuc);//ondalıklı sayıları yukarı yuvarlama metodu eklenecek.
            String cozulenMetinASCII = "", cozulenMetin = "";
            String[] lcipherArray = new String[Convert.ToInt32(diziBoyutu)];
            for (int i = 0; i < sifreliMetin.Length; i++)
            {
                if (!(i%lcipher!=0 || i==0))
                    tempSayac++;
                lcipherArray[tempSayac] += sifreliMetin[i];
            }

            foreach (String deger in lcipherArray)
            {
                cozulenMetinASCII += kural(optimizasyon(Convert.ToInt32(deger), d).ToString(), lclear);
                gui.txt_a_cozumSonuc.Text += kural(optimizasyon(Convert.ToInt32(deger), d).ToString(), lclear);
            }

            bolum = Math.DivRem(cozulenMetinASCII.Length, lcipher, out kalan);
            if (kalan > 0)
                kalan = 1;
            sonuc = Math.Ceiling(Convert.ToDouble(bolum + kalan));

            String[] ASCIIarray = new String[Convert.ToInt32(sonuc)];
            int asciiSayac = 0;
            for (int i = 0; i < cozulenMetinASCII.Length; i++)
            {
                    if (!(i % 3 != 0 || i == 0))
                        asciiSayac++;
                    ASCIIarray[asciiSayac] += cozulenMetinASCII[i];
            }
            for (int i = 0; i < ASCIIarray.Length; i++)
                cozulenMetin += asciiTostring(ASCIIarray[i]);
            return cozulenMetin;
        }
        String asciiTostring(String deger)
        {
            String tempS="";
            gui.txt_a_cozulmus_ascii.Text += deger + ",,";
            tempS += Convert.ToChar(Convert.ToInt32(deger));
            return tempS;
        }
        double sifreleFormul(int deger)
        {
                //String sonuc = (Math.Pow(deger, e) % n).ToString(), temp = "";
                String temp = "";
                String sonuc =optimizasyon(deger,e).ToString();

                if (sonuc.Length != lcipher)
                    for (int i = 0; i < lcipher - sonuc.Length; i++)
                        temp += "0";
                return Convert.ToDouble(temp + sonuc);
        }
        private String kural(String deger,int l)
        {
            String temp = "";
            if (deger.Length != l)
                for (int i = 0; i < l - deger.Length; i++)
                    temp += "0";
            return temp + deger;
        }
        Double optimizasyon(int deger,double sayi)
        {
            int ust = 0;
            List<Double> usler = new List<Double>();
            while (sayi > 0)
            {
                if (Math.Pow(2, ust) > sayi)
                {
                    usler.Add(Math.Pow(2, --ust));
                    sayi = sayi - Math.Pow(2, ust);
                    ust = 0;
                }
                else
                    ust++;
            }
            return (carpim(deger, usler)) % n;
        }
        Double carpim(int deger,List<Double> usler)
        {
            Double depo = 1, adet, kullanilacak;
            for (int i = 0; i < usler.Count; i++)
            {
                if (usler[i] >= 4)   // us 4 den buyuk ise gir.
                {
                    adet = usler[i] / 4;       // buyuk olan ussun icinde kac adet 4 var. 
                    kullanilacak = ((Math.Pow(deger, 4)) % n); // tek bir tane sonuc cikartıp adet ile us alıcaz.           
                    depo *= ((Math.Pow(kullanilacak, adet) % n) % n);
                }
                else
                    depo *= ((Math.Pow(deger, usler[i])) % n);
            }
            return depo;
        }
        private int eBul(int nu1, int testE)
        {
            int tempNu = nu1, temp, kalan, tutulanE = testE;
            while (true)
            {
                if (nu1 == 1 || testE == 1)
                    return tutulanE;
                else if (nu1 == 0 || testE == 0)
                {
                    Random rast = new Random();
                    testE = rast.Next(1, tempNu + 1);
                    tutulanE = testE;
                    nu1 = tempNu;
                }
                else
                {
                    temp = nu1 / testE;
                    kalan = nu1 - temp * testE;
                    nu1 = testE;
                    testE = kalan;
                }
            }
        }
        private int dBul(int nu1, int e)
        {
            Random rast = new Random();
            int d = rast.Next(999, nu1), sonuc;
            while (true)
            {
                sonuc = d * e;
                if (sonuc % nu1 == 1)
                    return d;
                else
                    d = rast.Next(999, nu1);
            }
        }
    }
}
