namespace RegexExplorer {
    public interface IStringSafeSerialize {
        string StringSafeSerialize();
        object StringSafeDeserialize(string separatedProperties);
    }
}