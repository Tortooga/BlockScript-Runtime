namespace BlockScript
{
    static class IdentifierConstants
    {
        //ONLY FOR HOST LANGUAGE VALIDATION. INTERPRETED LANGUAGE HAS A DIFFERENT CHAR SYSTEM

        public static readonly char[] ValidIdentifierCharacters =
        {
            //LowerCase
            'a','b','c','d','e','f','g','h','i','j','k','l','m',
            'n','o','p','q','r','s','t','u','v','w','x','y','z',

            //UpperCase
            'A','B','C','D','E','F','G','H','I','J','K','L','M',
            'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',

            //Special
            '_',

            //Numbers
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        public static readonly char[] ValidIdentifierStartCharacters =
        {
            'a','b','c','d','e','f','g','h','i','j','k','l','m',
            'n','o','p','q','r','s','t','u','v','w','x','y','z',

            //UpperCase
            'A','B','C','D','E','F','G','H','I','J','K','L','M',
            'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
        };
    }
}