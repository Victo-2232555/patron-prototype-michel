using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PrototypeCafe;

/// <summary>Menu qui peut fournir une copie de son état.</summary>
public sealed class Menu : IPrototype<Menu>
{
    private readonly List<string> _supplements;

    public string Taille { get; set; }
    public string TypeCafe { get; }
    public string Beigne { get; }

    // La vue en lecture seule protège la liste interne.
    public IReadOnlyList<string> Supplements => _supplements.AsReadOnly();

    public Menu(string taille, string typeCafe, string beigne)
    {
        Taille = taille;
        TypeCafe = typeCafe;
        Beigne = beigne;
        _supplements = new List<string>();
    }

    // Constructeur de copie : source est le menu à dupliquer.
    private Menu(Menu source)
    {
        Taille = source.Taille;
        TypeCafe = source.TypeCafe;
        Beigne = source.Beigne;

        // Nouvelle liste. Ses éléments sont des textes immuables.
        _supplements = new List<string>(source._supplements);
    }

    public Menu Copier()
    {
        // this désigne l'objet qui reçoit l'appel à Copier().
        return new Menu(this);
    }

    public void AjouterSupplement(string supplement)
    {
        _supplements.Add(supplement);
    }

    public override string ToString()
    {
        string options = _supplements.Count == 0
            ? "aucun"
            : string.Join(", ", _supplements);

        return $"{Taille}, café {TypeCafe}, beigne {Beigne}"
            + $", suppléments : {options}";
    }
}

