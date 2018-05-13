# RSA Sifreleme Algoritmasi

## Çalışması:

Anahtar Üretimi : 

1-) n=p\*q ve Q=(p-1)*(q-1) </br>
2-) 1<e<Q ve ebob(e,Q)=1 şartlarına uyan e belirlenir. </br>
3-) 1<d<Q ve e.d ≡ 1 (mod Q) şartlarını saglayan d belirlenir </br>

| Genel Anahtarlar | Özel Anahtar  |
| :-------------:  | :------------:|
|      n,e         | 		d	   |


<h1> Hasan Karaşahin </h1>

*
\*
/*


Yeterince büyük iki adet asal sayı seçilir: Bu sayılar örneğimizde p ve q olsunlar.
n=pq hesaplanır. Buradaki n sayısı iki asal sayının çarpımıdır ve hem umumî hem de hususî şifreler için taban (modulus) olarak kabul eder.
Totient fonksiyonu hesaplanır. Bu örnek için çarpanların ikisi de asal sayı olduğu için φ(n) = (p-1)(q-1) olarak bulunur.
Hesaplanan totient fonksiyonu değeri (φ(n) ) ile aralarında asal olan öyle bir e sayısı alınır ki 1 < e < φ(n) olmalıdır. Bu seçilen e sayısı umumî anahtar olarak ilan edilebilir.
d gibi bir sayı hesaplanır ki bu sayı için şu denklik geçerli olmalıdır : de ≡ 1 mod ( φ(n) ). Bu d değeri hususî şifre olarak saklanır. Bu sayının hesaplanması sırasında uzatılmış öklit (extended euclid) algoritmasından faydalanılır.
