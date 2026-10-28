using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeCafe;

/// <summary>Contrat de copie. T est le type de l'objet retourné.</summary>
public interface IPrototype<T>
{
    T Copier();
}
