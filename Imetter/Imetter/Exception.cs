using System;

namespace Imetter
{
    class InvalidFileNameCharacterException : Exception
    {
        public InvalidFileNameCharacterException(char inCharacter)
            : base($"\'{inCharacter}\' is bad character for file name.")
        { }
    }
}
