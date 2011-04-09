using RegexExplorer;

namespace RegexExplorer {
    public abstract class MsgsBase : Lang {
        protected MsgsBase(): base() {
        }

        new public static Msgs Res {
            get { return (Msgs) LangBase.Res; }
        }
    }
}