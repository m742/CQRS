using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ClassLibrary.Entities
{
    public abstract class Entities : IEquatable<Entities> // inibe a possibilidade de 
    { // instanciar a classe
        public Guid Id { get; private set; } // perfomace do guid
        // comparado com int é diferente.
        
        public Entities() // executado toda vez
        {// que a classe é instanciada
            Id = Guid.NewGuid();
        }

        public bool Equals([AllowNull] Entities other) // compara GUID
        { // graças a IEquetable
            return Id == other.Id;
        }

    }
}
