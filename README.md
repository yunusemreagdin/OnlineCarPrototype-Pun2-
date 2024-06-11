# BUİLD
[Build Link](https://drive.google.com/drive/folders/1nZoRbxdF-84vRp6X4Yk2jwtvwKlSDAIa?usp=sharing) 

``TestNetworkTransform.exe`` ile uygulamayı çalıştırabilirsiniz.

# TODOS
- [X] Envanter system.
- [X] Trade system.
- [X] Inspect system.
- [X] Item system.
- [X] Interaction system. 
- [X] Online system.
- [X] UI.

# CRUCIAL BUGS
- [ ] Pazarlık sadece 2 kullanıcı arasında geçebilir kullanıcı kontrolü yapılmadı.B sebepten dolayı 2 kullanıcı yanyanayken başka bir kullanıcı gelirse bug oluşur.

# CRUCIAL FİXED BUGS
- [X] RCC paketinin online sistemi ile benim yaptığım envanter,trade sistemleri birbirleriyle uyumlu çalışmıyordu, RCC paketinin Pun2 scriptlerine ekleme/çıkarma yaparak sorunu çözdüm.
- [X] Oyuna extra olarak RCC paketinin instantiate ettiği araba prefablarinin yerine kendi kodlarımı yazarak Player spawn ettim ve Player üzerinden işlemlere devam ettim.Bunu yapmamın en büyük sebebi scriptleri araba nesnesinin içinde tutmanın mantıksız olmasıdır.
