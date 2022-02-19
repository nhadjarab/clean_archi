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

- extraction des constantes.

- extraction du Parser dans sa propre classe 
- ajout des classe SaleReport et saleDTO
- implémentation du desgin pattern command. il ne reste que l'implémenation de la commande `report`
