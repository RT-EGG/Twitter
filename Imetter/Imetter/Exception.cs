using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imetter
{
    class InvalidFileNameCharacterException : Exception
    {
        public InvalidFileNameCharacterException(char inCharacter)
            : base($"\'{inCharacter}\' is bad character for file name.")
        { }
    }
}
