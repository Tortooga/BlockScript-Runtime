using System.Text;
using BlockScript;

//Lossless Encoding and decoding of all types into int32 for memory storage

public static class TypeEncoder
{
    public static int EncodeChar(char val)
    {
        return (int)val;
    }
    public static int EncodeBool(bool val)
    {
        if (val) return 1;
        return 0;
    }
    public static int EncodeFloat(float val)
    {
        return BitConverter.SingleToInt32Bits(val);
    }

    public static int Encode(ObjectType type, object val)
    {
        //When called, type assumed to be validated
        switch (type)
        {
            case ObjectType.IntType:        return (int)val;
            case ObjectType.BoolType:       return EncodeBool((bool)val);
            case ObjectType.CharType:       return EncodeChar((char)val);
            case ObjectType.FloatType:      return EncodeFloat((float)val);
              
            default:                        return 0; //Impossible
        }
    }
}