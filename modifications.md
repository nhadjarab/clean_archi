# refacto 

- Code difficile à lire car nom de variables non explicite => renommer les variables.
- tout le code dans un seul fichier => mauvaise pratique.
- Number of Clients n'est pas calculé.


## 1. renommage varialbes 
    - line1 : headerLine
    - otherLines: dataLines
    - number1: numberOfSales
    - number2: totalItemsSold
    - number3: totalSalesAmount
    - number4: averageAmountPerSale
    - number5: averageItemPrice

2. extraction des constantes.

3. extraction du Parser dans sa propre classe 
4. ajout des classe SaleReport et saleDTO 
5. implémentation du desgin pattern command.

6. Ce qui n'a pas été fait mais ça aurait été possible est d'externaliser l'affichage. Dans ce projet, on affiche sur console mais on aurait pu
implémenter une interface qui s'occupera de l'affichage. ainsi on pourra afficher sur une console, une socket ou tout simplement un fichier. 


7. On aurait pu utiliser des libraires C# déjà existates pour la lecture du CSV ou pour la gestion des arguement (paramètres).