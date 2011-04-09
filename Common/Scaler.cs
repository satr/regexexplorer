using System.Drawing;

namespace RegexExplorer {
    public class Scaler {
        private static decimal DEFAULT_RATE = 1.5m;

        private float[] _scaleSizes = new float[5];
        private int _currentScaleIndex = 0;
        private Font _font;

        public Scaler(Font font) : this(font, DEFAULT_RATE) {
        }

        public Scaler(Font font, decimal scaleStepRate) {
            _font = font;
            _scaleSizes[0] = font.Size;
            for (int i = 1; i < _scaleSizes.Length; i++)
                _scaleSizes[i] = _scaleSizes[i - 1]*(float) (scaleStepRate);
        }

        public Font currentFont {
            get { return fontFor(_currentScaleIndex); }
        }

        public Font nextFont {
            get {
                return
                    (_currentScaleIndex < _scaleSizes.Length - 1)
                        ? fontFor(++_currentScaleIndex) : fontFor(_currentScaleIndex);
            }
        }

        public Font prevFont {
            get { return (_currentScaleIndex > 0) ? fontFor(--_currentScaleIndex) : fontFor(_currentScaleIndex); }
        }

        private Font fontFor(int index) {
            return new Font(_font.FontFamily, _scaleSizes[index]);
        }

        public int currentScaleIndex {
            get { return _currentScaleIndex; }
            set { _currentScaleIndex = value; }
        }
    }
}