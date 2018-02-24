# NetDevPLWebsite project

Strona dostępna jest pod adresem [http://netdevelopers.pl](http://netdevelopers.pl)

## Status

[![Build status](https://ci.appveyor.com/api/projects/status/eyu2c3t7k0cj1orc?svg=true)](https://ci.appveyor.com/project/pawelklimczyk/netdevplwebsite)


## Idea
Projekt ten jest eksperymentem mającym na celu próbę stworzenia przez programistów portalu informacyjnego dla polskich programistów .NET.
Jak każdy ewoluujący system także ten projekt nie ma ściśle określonych celów. Wraz z rozwojem projektu jedne funkcje będą dodawane, inne refaktoryzowane, a jeszcze inne usuwane.

## Zasady
1. Nazewnictwo i komentarze w kodzie programu muszą być po angielsku.
2. Przechodzące testy.
3. Automatyzacja wszystkiego jest jak najbardziej porządana.
4. Programujemy funkcjonalność w duchu quazi-DDD. Np. funkcjonalność "Blogs" nie powinna być rozbita na osobne biblioteki Web/Services/(etc)/Domain a raczej być w jednej, np. NetDevPL.Blogs. Pomijam tutaj Eventy i inne AggregateRooty :)

## Uczestnictwo w projekcie
1. Każdy kto chce może uczestniczyć w rozwoju projektu. Wystarczy zrobić forka, a później pull requesta ze swoim kodem.
2. Jeżeli chcesz dodać swojego bloga do listy, etc. patrz pkt 1.
3. W początkowej fazie projektu sugeruję ~~jakąś komunikacje~~ komunikację na slacku [devspl.slack.com](http://devspl.slack.com) (kanał **#netdeveloperswebsite**) żeby skoordynować kodowanie.

## Strona techniczna
* Strona działa na Linuxie pod Mono + nginx
* Framework [NancyFX](https://github.com/NancyFx/Nancy/wiki/Documentation)
* AppVeyor (auto deployment)
* Środowisko developerskie: Visual Studio 2015
* Strona do działania wymaga [MongoDB](https://www.mongodb.com/download-center#community). MongoDB wystarczy uruchomić z domyślną konfiguracją. Możesz zrobić to za pomocą Dockera używając polecenia `docker run --name netdeveloperspl -d -p 27017:27017 mongo`
* Aby uruchomić projekt lokalnie na Windowsie należy wykonać następującą komendę w linii poleceń:
- - Windows EN: `netsh http add urlacl url="http://+:8888/"  user=Everyone`
- - Windows PL: `netsh http add urlacl url="http://+:8888/" user="Wszyscy"`


