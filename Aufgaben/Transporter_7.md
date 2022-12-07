#Transporter 7

## User Story 1

Über einen Menüpunkt im Consolenprogramm kann man seine gekauften LKWs anzeigen. Ebenso will ich als Geschäftsführer
meine angestellten Fahrer anzeigen.
Hat ein LKW keinen Fahrer, so kann man ihm einen verfügbaren Fahrer zuweisen.

### Akzeptanzkriterien

- Einem LKW kann ein Fahrer zugewiesen werden
- Ein LKW hat 0 oder 1 Fahrer
- Es kann ein LKW ausgewählt und der Fahrer angezeigt werden. Ist keiner zugewiesen wird dies entsprechend markiert.
- Dem LKW kann der Fahrer entfernt werden insofern dieser Verfügbar ist.
- Es gibt ein Menüpunkt zur übersicht der gekauften LKWs, Fahrer und Ausschreibungen.

## User Story 2

Nachdem der LKW einen Fahrer hat, kann ich diesen bewegen. Hierfür muss ich eine Zielstadt auswählen, zu der der LKW
fahren soll. Ich kann mir den Status des LKWs anzeigen. Er ist entweder frei, unterwegs, wird bewegt oder auf dem
Rückweg.

### Akzeptanzkriterien

- Ein LKW kann von einem Ort zu einem anderen bewegt werden
- Ein LKW kann nur bewegt werden, wenn dieser frei ist.
- Ein LKW hat einen Status: frei, gebucht, wird bewegt, auf dem Rückweg.

## User Story 3

### Akzeptanzkriterien

- Einem LKW kann eine Ausschreibung zugeteilt werden
- Ein LKW hat 1 oder 0 Ausschreibungen zugeteilt
- Um eine Ausschreibung zuteilen zu können muss der LKW am Standort der Ausschreibung sein
- Die Kapazität des LKWs muss >= der der Ausschreibung sein
- Der LKW Typ muss dem benötigten Typ der Ausschreibung gleich sein.
