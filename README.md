# RSA Sifreleme Algoritmasi

## Anahtar Üretimi : 
	
	1-) p ve q yeterince buyuk asal sayıdır.	
	2-) n=p\*q ve Q=(p-1)*(q-1) </br>
	3-) 1<e<Q ve ebob(e,Q)=1 şartlarına uyan e belirlenir. </br>
	4-) 1<d<Q ve e.d ≡ 1 (mod Q) şartlarını saglayan d belirlenir </br>

	| Genel Anahtarlar | Özel Anahtar  |
	| :-------------:  | :------------:|
	|      n,e         | 	d	   |

## Sifreleme
	
	c=m^e mod n

## Desifreleme

	m=c^d mod n
