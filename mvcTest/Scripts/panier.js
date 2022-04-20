const BtnproduitItem = document.querySelectorAll("#items");
const panier = document.querySelector("#panier");
const nomProduit = document.querySelectorAll("#nomProduit");
const categoryProduit = document.querySelectorAll("#categoryProduit");
const prixProduit = document.querySelectorAll("#prixProduit");
const commande = document.querySelector("#commande");
const containItems = document.querySelector("#contain-items");
const total = document.querySelector("#total");
const valeur = document.querySelector("#valeur");

const nom = document.querySelector("#nom");
const category = document.querySelector("#category");
const prix = document.querySelector("#prix");
const qte = document.querySelector("#qte");
const valider = document.querySelector("#valider");


let nbPanier = 0;
let totalPrix = 0;

for (let i = 0; i < BtnproduitItem.length; i++) {
    BtnproduitItem[i].addEventListener("click", function (e) {
        nbPanier++;
        panier.textContent = nbPanier;
        commande.style.display = 'block';
        commande.style.position = "sticky";
        commande.style.top = "0";
        nom.innerHTML += nomProduit[i].textContent + "<br/>";
        category.innerHTML += categoryProduit[i].textContent + "<br/>";
        prix.innerHTML += prixProduit[i].textContent + "<br/>";
        totalPrix += parseFloat(prixProduit[i].textContent);
        total.textContent = "Total : " + totalPrix + " Ar";
        valeur.value = nom.innerHTML + " " + category.innerHTML + " " + prix.innerHTML + " " + total.textContent;
        e.preventDefault();
    })
}


