# TddWashingMachine

# Waschmaschine

## Hinweise

Bitte so behandeln, als ginge es um eine richtige physische Waschmaschine, die

## Anforderungen

+ Starten durch "Start" Knopf
+ Wenn Tür offen kann nicht gestartet werden
    - Fehlermeldung als 1s Blinken der "Tür offen" Lampe
+ Während Programm ausgeführt wird muss Tür verschlossen sein
+ Wenn Wasser in Maschine muss Tür verschlossen sein (Wasser kann nur durch entsprechendes Programm in Maschine gelangen)
+ Standard Waschgang besteht aus
    - Wasser einlassen
		- Durchmischen(Drehen der Trommel mit niedriger Geschwindigkeit)
		- Wasser abpumpen
		- Schleudern(Drehen der Trommel mit hoher Geschwindigkeit)
+ Die Maschine darf in keinen Zustand gelangen, der eine weitere zweckmäßige Verwendung verhindert bzw. schwierig macht

### Abgrenzungen

+ Ein laufendes Programm muss nicht unterbrochen werden können
	
Inputs
  + Ereignisse
    - Startknopf gedrückt
    - Programmwahl geändert
  + Werte
    - Tür offen
    - Wasserstand
      * leer
      * voll
    - Programmwahl
Outputs
  + Indikatoren
    - Tür offen
    - Tür verschlossen
    - Fertig
  + Steuerung
    - Türschloss
    - Wasserzufuhr
    - Entleerungspumpe
    - Trommelmotor
      * an/aus
      * schnell/langsam

## vorläufiges Modell

