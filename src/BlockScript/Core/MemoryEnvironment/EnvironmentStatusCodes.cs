namespace BlockScript;

public enum DefineVarStatusCode
{
    //success
    Success,

    //Identifier Issues
    InvalidIdentifierLength,
    InvalidIdentifierBody,
    InvalidIdentifierStart,
    ReservedKeyword,
    IdentifierAlreadyUsed,

    //Memory Issues
    OutOfMemory,
    
    //Type Issues
    TypeCouldNotBeInferred,
    InvalidInitialiser
}