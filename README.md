## Homework
Ohjelman on tehty käyttäen asp.net wep api ja entity framework

## Kannan luonti:

Luo homework niminen tietokanta ja luo siihen tarvittavat taulut ajamalla tietokanta skripti taulujenLuonti.sql

## Ohjelman käynnistäminen:

Avaa visual studio projektti Homework.sln

Käy muuttamassa tiedostosta Web.config connectionStringinstä data source vastaamaan sinun tietokanta instanssin nimiä.

Sitten ohjelma pitäisi olla käyttövalmis.

## Testaaminen

Rest-serverin toimintaa kannattaa testata Postman -nimesellä ohjelmalla, jonka voi ladata chrome web storesta.

# Esimerki komentoja
 
DELETE  /api/DeletePlanet/3 --poista planetan id perustella
GET     /api/GetPlanet/2 --hakee planetaan tiedot id perustella
GET /api/GetPlanets --palauttaa kaikki planetat
POST /api/PostPlanet bodyn raw teksiksi {"Name":"unknown"} ja lähetys muodoksi JSON --lisää unkown nimisen planeetan
PUT /api/PutPlanet/4 bodyn raw teksiksi {"ID":4,"Name":"Yoda's land" } ja lähetys muodoksi JSON -- muokkaa lajia, jonka ID on 4


DELETE  /api/DeleteSpecies/3 --poista lajin id perustella
GET     /api/GetSpecies/2 --hakee lajin tiedot id perustella
GET /api/GetSpecies --palauttaa kaikki lajit
POST /api/PostSpecies bodyn raw teksiksi {"Name":"testi", "Planet_ID":4} ja lähetys muodoksi JSON --lisää testi nimisen lajin joka asuu planeetalla jonka ID on 4
PUT /api/PutSpecies/4 bodyn raw teksiksi {"ID":4, Name":"Yoda's species", "Planet_ID" : 4 } ja lähetys muodoksi JSON -- muokkaa lajia, jonka ID on 4
