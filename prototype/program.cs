using System;

namespace PrototypeCafe;

public static class Programme
{
    public static void Main(string[] args)
    {
        // Une seule instance modèle, déjà configurée.
        var menuDeBase = new Menu("Moyen", "filtre", "chocolat");

        Menu commandeMichel = PreparerCommande(menuDeBase, "lait");
        Menu commandeMelodie = PreparerCommande(menuDeBase, "sucre");

        Console.WriteLine("Base    : " + menuDeBase);
        Console.WriteLine("Michel  : " + commandeMichel);
        Console.WriteLine("Melodie: " + commandeMelodie);
        Console.WriteLine();
        Console.WriteLine("Base et Michel : objets distincts = "
            + !ReferenceEquals(menuDeBase, commandeMichel));
    }

    // Le client demande la copie à travers le contrat.
    public static Menu PreparerCommande(IPrototype<Menu> prototype, string supplement)
    {
        Menu commande = prototype.Copier();
        commande.AjouterSupplement(supplement);
        return commande;
    }
}