Infinite Runner stworzony przez Szymon Hałucha. 
Czas tworzenia około 5 godzin.

# Opis rozgrywki
Gra nie zawiera grafik oraz dźwięków (uznałem że lepiej skupić się na prezentacji mojego kodu), gracz reprezentowany jest przez białe kółko, poruszanie odbywa się za pomocą myszki lewo-prawo. Gracz musi unikać szarych kwadratów, które reprezentują przeszkody. Za każdą sekundę przeżycia gracz dostaje 1 punkt. Gra kończy się w momencie, gdy gracz uderzy w przeszkodę. Dostępne są też powerupy, które pojawiają się losowo na planszy, spadają w dół i jeśli gracz je złapie, to dostaje tarczę, która chroni gracza przed przeszkodami przez 8 sekund. PowerUp tarczy reprezentowany jest przez niebieski kwadrat.

# Opis mechanik programistycznych

## Scriptable Object Architecture
Do projektu zaimplementowałem własną paczkę do Scriptable Object Architecture, pozwala ona na uniknięcie kodu spagetti, które szybko się pojawia w projektach Unity (za dużo singletonów).

## State Machine
Dla gracza stworzyłem prosty state machine, który posiada trzy stany: Normal, Shield oraz Disabled. Normal jest stanem, w którym gracz może się poruszać, Shield jest stanem, w którym gracz posiada tarczę i może się poruszać, a Disabled jest stanem, w którym gracz nie może się poruszać, występuje on na koniec rozgrywki. State Machine jest zaimplementowany w taki sposób, żeby łatwo można było dodawać nowe stany.

## Object Pooling
Do projektu zaimplementowałem także prosty system poolingu dla przeszkód oraz powerupów. Dzięki temu nie tworzymy za każdym razem nowych obiektów, tylko je reużytkujemy.

## Component Based Design
W projekcie wykorzystałem także prosty system komponentów dla gracza, który pozwala na łatwe dodawanie nowych komponentów do obiektu gracza.

## UI
Do projektu dodałem także prosty UI, który pokazuje aktualny wynik gracza, podejście wykorzystane do stworzenia interfejsu użytkownika to Event Driven UI.