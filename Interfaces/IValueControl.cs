namespace RegexExplorer {
    public interface IValueControl {
        object Value { set; get; }
        void Clear();
    }
}