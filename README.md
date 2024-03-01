# FightingHeroes
 Heroes fighting in the arena

Az arénában N darab hős küzd, akik lehetnek íjászok, lovasok és kardosok. Minden hős rendelkezik egy azonosítóval és életerővel, valamint a következő szabályok szerint támadnak és védekeznek:
Íjász támad 
lovast: 40% eséllyel a lovas meghal, 60%-ban kivédi
kardost: kardos meghal 
íjászt: védekező meghal
Kardos támad 
lovast: nem történik semmi
kardost: védekező meghal 
íjászt: íjász meghal
Lovas támad
lovast: védekező meghal
kardost: lovas meghal 
íjászt: íjász meghal

A csata körökre van lebontva, minden körben véletlenszerűen kiválasztásra kerül egy támadó és egy védekező. A kimaradt hősök pihennek, és életerejük 10-zel nő, de nem mehet a maximum fölé.
A harcban résztvevő hősök életereje a felére csökken, ha ez kisebb, mint a kezdeti életerő negyede, akkor meghalnak. Kezdeti életerők: íjász - 100, lovas - 150, kardos - 120.
A csata addig tart, amíg maximum 1 hős marad életben.
Készíts egy olyan web API-t, amely a fenti szabályokat figyelembe véve hősöket csatáztat egymással, és ellátva van unit tesztekkel. Az alábbi endpointokat szükséges implementálni:
Random hősgenerátor
input: harcosok száma
return: aréna azonosító
Csata
input: aréna azonosító
return: History, ami leírja a körök számát, valamint a körökben ki támadott meg kit, és hogyan változott az életerejük.
